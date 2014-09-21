using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemTrack
{
    public partial class MemTrackForm : Form
    {
        public class MemPoint
        {
            public double When { get; set; }
            public double Pss { get; set; }
            public double Dirty { get; set; }
            public string Extras { get; set; }
        }

        public class Category
        {
            public string Name;
            public Regex Regex;
            public List<MemPoint> Samples = new List<MemPoint>(); 
        }
        public MemTrackForm()
        {
            InitializeComponent();

            _Categories.Add(new Category { Name = "TOTAL", Regex = _ReTotal });
            _Categories.Add(new Category { Name = "Native", Regex = _ReNativeHeap });
            _Categories.Add(new Category { Name = "Dalvik", Regex = _ReDalvikHeap });
            _Categories.Add(new Category { Name = "Other", Regex = _ReOtherDev });
            _Categories.Add(new Category { Name = "SO", Regex = _ReSoMemmap });
            _Categories.Add(new Category { Name = "Unknown", Regex = _ReUnknown });
            _Categories.Add(new Category { Name = "APK", Regex = _ReApkMemmap });

            foreach(var c in _Categories)
            {
                var s = new Series(c.Name);
                s.ChartType = SeriesChartType.Line;
                s.SmartLabelStyle = new SmartLabelStyle {Enabled = true};
                _MemoryChart.Series.Add(s);
            }
        }

        private Task _Recording;
        private CancellationTokenSource _CancellationSource;

        private bool IsRecording
        {
            get { return _Recording != null; }
        }

        private async Task ToggleRecord()
        {
            if (IsRecording)
            {
                var existing = _Recording;
                _CancellationSource.Cancel();
                await existing;
                if (existing == _Recording)
                    _Recording = null;
                return;
            }
            if (_PackageText.Text.Trim().Length == 0)
            {
                MessageBox.Show("Must specify package name");
                return;
            }
            Clear();
            _PackageText.Enabled = false;
            _TrackActivities.Enabled = false;
            _RecordButton.Text = "Stop";
            _Start = DateTime.Now;
            _Recording = StartRecording();            
        }

        private static Regex _ReNativeHeap = new Regex(@"Native Heap\s+(\d+)\s+(\d+)");
        private static Regex _ReDalvikHeap = new Regex(@"Dalvik Heap\s+(\d+)\s+(\d+)");
        private static Regex _ReDalvikOther = new Regex(@"Dalvik Other\s+(\d+)\s+(\d+)");
        private static Regex _ReStack = new Regex(@"Stack\s+(\d+)\s+(\d+)");
        private static Regex _ReOtherDev = new Regex(@"Other dev\s+(\d+)\s+(\d+)");
        private static Regex _ReSoMemmap = new Regex(@".so mmap\s+(\d+)\s+(\d+)");
        private static Regex _ReJarMemmap = new Regex(@".jar mmap\s+(\d+)\s+(\d+)");
        private static Regex _ReApkMemmap = new Regex(@".apk mmap\s+(\d+)\s+(\d+)");
        private static Regex _ReTtfMemmap = new Regex(@".ttf mmap\s+(\d+)\s+(\d+)");
        private static Regex _ReDexMemmap = new Regex(@".dex mmap\s+(\d+)\s+(\d+)");
        private static Regex _ReOtherMemmap = new Regex(@"Other mmap\s+(\d+)\s+(\d+)");
        private static Regex _ReUnknown = new Regex(@"Unknown\s+(\d+)\s+(\d+)");
        private static Regex _ReTotal = new Regex(@"TOTAL\s+(\d+)\s+(\d+)");
        private List<Category> _Categories = new List<Category>();
        private DateTime _Start;
        private List<string> _Activities = new List<string>();
        private bool _Resumed;

        private static Regex _ReResumedActivity = new Regex(@"mResumedActivity:\s*ActivityRecord\s*\{\s*[a-fA-F0-9]+\s*[a-zA-Z0-9]+\s*(\S+)");

        void Clear()
        {
            foreach (var c in _Categories)
                c.Samples.Clear();
            _Activities.Clear();
        }

        private string DeviceSelector
        {
            get { return _DeviceText.Text.Trim().Length > 0 ? string.Format("-s {0}", _DeviceText.Text) : ""; }
        }
        async Task StartRecordingActivities()
        {
            try
            {
                var last = default(string);
                for (;;)
                {
                    var p = new Process();
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.FileName = AdbPath;
                    p.StartInfo.Arguments = string.Format("{1} shell dumpsys activity package {0}", _PackageText.Text, DeviceSelector);
                    p.Start();
                    var output = await p.StandardOutput.ReadToEndAsync();
                    var m = _ReResumedActivity.Match(output);
                    var resumed = default(string);
                    if (m.Success)
                    {
                        resumed = m.Groups[1].Value;
                        //if (resumed.StartsWith(_PackageText.Text))
                        //    resumed = resumed.Substring(_PackageText.Text.Length + 1);
                        //keep it even shorter
                        if (resumed.LastIndexOf(".") != -1)
                            resumed = resumed.Substring(resumed.LastIndexOf(".") + 1);
                    }
                    if (resumed != null)
                        _Resumed |= true;
                    if (resumed != null && resumed != last)
                        _Activities.Add(resumed);
                    last = resumed;
                }
            }
            catch (OperationCanceledException e)
            {
            }

        }

        async Task StartRecording()
        {
            try
            {
                _CancellationSource = new CancellationTokenSource();
                if(_TrackActivities.Checked)
                    StartRecordingActivities();
                var last_resumed = false;
                for (;;)
                {
                    var p = new Process();
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.FileName = AdbPath;
                    p.StartInfo.Arguments = string.Format("{1} shell dumpsys meminfo {0}", _PackageText.Text, DeviceSelector);
                    p.Start();
                    var output = await p.StandardOutput.ReadToEndAsync();
                    var when = (DateTime.Now - _Start).TotalSeconds;

                    var last = _Categories[0].Samples.Count;

                    var extras = default(string);
                    var items = new List<string>();
                    if (last_resumed != _Resumed)
                    {
                        items.Add(_Resumed ? "FG" : "BG");
                        last_resumed = _Resumed;
                    }
                    _Resumed = false;
                    foreach (var a in _Activities)
                        items.Add(a);
                    _Activities.Clear();
                    if (items.Count > 0)
                        extras = string.Join("\n", items);

                    foreach (var c in _Categories)
                    {
                        var m = c.Regex.Match(output);
                        if (!m.Success)
                            break;

                        var pt = new MemPoint
                        {
                            When = when,
                            Pss = double.Parse(m.Groups[1].Value) / 1000,
                            Dirty = double.Parse(m.Groups[2].Value) / 1000,
                            Extras = c.Name == "TOTAL" ? extras : default(string),
                        };
                        c.Samples.Add(pt);
                        Console.WriteLine("{0} {1} {2} {3}", c.Name, pt.When, pt.Pss, pt.Dirty);

                    }
                    _NotFoundLabel.Visible = _Categories[0].Samples.Count == last;
                    RefreshData();
                    await Task.Delay(TimeSpan.FromSeconds((int)_FrequencySpinner.Value), _CancellationSource.Token);
                }
            }
            catch (OperationCanceledException e)
            {
                
            }
            finally
            {
                _PackageText.Enabled = true;
                _TrackActivities.Enabled = true;
                _RecordButton.Text = "Record";
                _Recording = null;
            }
        }
        private string AdbPath { 
            get {
                int plat = (int)Environment.OSVersion.Platform;
                if ((plat == 4) || (plat == 128))
                    return Environment.ExpandEnvironmentVariables("%HOME%/Library/Developer/Xamarin/android-sdk-mac_x86/platform-tools/adb");
                else
                    return "adb.exe";
            }
        }

        private async Task<bool> CheckAlive()
        {
            var p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = AdbPath;
            p.StartInfo.Arguments = string.Format("{1} shell dumpsys meminfo {0}", _PackageText.Text, DeviceSelector);
            p.Start();
            var output = await p.StandardOutput.ReadToEndAsync();
            return output.Contains("TOTAL");
        }

        public void RefreshData()
        {
            var i = 0;
            foreach (var s in _MemoryChart.Series)
                s.Points.DataBind(_Categories[i++].Samples, "When", _DirtyCheck.Checked ? "Dirty" : "Pss", "Label=Extras");
        }
        private async void _PackageText_TextChanged(object sender, EventArgs e)
        {
            await CheckForProcess();
        }

        private void _DirtyCheck_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private async void _RecordButton_Click(object sender, EventArgs e)
        {
            await ToggleRecord();
        }

        private void _SaveImageButton_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "PNG image (*.png)|*.png";
            dlg.RestoreDirectory = true;
            var r = dlg.ShowDialog(this);
            if (r != DialogResult.OK)
                return;
            var b = new Bitmap(_MemoryChart.Width, _MemoryChart.Height);
            _MemoryChart.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));
            using (var f = dlg.OpenFile())
            {
                b.Save(f, ImageFormat.Png);
            }
        }

        private void _SaveButton_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Tab delimited table (*.tsv)|*.tsv";
            dlg.RestoreDirectory = true;
            var r = dlg.ShowDialog(this);
            if (r != DialogResult.OK)
                return;
            using (var f = new StreamWriter(dlg.OpenFile()))
            {
                f.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "Name", "When", "Pss", "Dirty", "Extras");
                foreach (var c in _Categories)
                {
                    foreach (var s in c.Samples)
                    {
                        f.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", c.Name, s.When, s.Pss, s.Dirty, (s.Extras ??"").Replace("\n", ","));
                    }
                }
            }
        }

        private async void _DeviceText_TextChanged(object sender, EventArgs e)
        {
            await CheckForProcess();
        }

        private async Task CheckForProcess()
        {
            _NotFoundLabel.Visible = _PackageText.Text.Trim().Length == 0 || !await CheckAlive();
        }

    }
}
