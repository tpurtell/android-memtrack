namespace MemTrack
{
    partial class MemTrackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this._MemoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._RecordButton = new System.Windows.Forms.Button();
            this._SaveButton = new System.Windows.Forms.Button();
            this._SaveImageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._PackageText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._FrequencySpinner = new System.Windows.Forms.NumericUpDown();
            this._DirtyCheck = new System.Windows.Forms.CheckBox();
            this._TrackActivities = new System.Windows.Forms.CheckBox();
            this._NotFoundLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._DeviceText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._MemoryChart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._FrequencySpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // _MemoryChart
            // 
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Seconds";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.Title = "Memory (MB)";
            chartArea2.Name = "ChartArea1";
            this._MemoryChart.ChartAreas.Add(chartArea2);
            this._MemoryChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this._MemoryChart.Legends.Add(legend2);
            this._MemoryChart.Location = new System.Drawing.Point(3, 3);
            this._MemoryChart.Name = "_MemoryChart";
            this._MemoryChart.Size = new System.Drawing.Size(767, 544);
            this._MemoryChart.TabIndex = 0;
            this._MemoryChart.Text = "chart1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._MemoryChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(905, 550);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this._RecordButton);
            this.flowLayoutPanel1.Controls.Add(this._SaveButton);
            this.flowLayoutPanel1.Controls.Add(this._SaveImageButton);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this._PackageText);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._FrequencySpinner);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this._DeviceText);
            this.flowLayoutPanel1.Controls.Add(this._DirtyCheck);
            this.flowLayoutPanel1.Controls.Add(this._TrackActivities);
            this.flowLayoutPanel1.Controls.Add(this._NotFoundLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(776, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(126, 544);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // _RecordButton
            // 
            this._RecordButton.Location = new System.Drawing.Point(3, 3);
            this._RecordButton.Name = "_RecordButton";
            this._RecordButton.Size = new System.Drawing.Size(120, 23);
            this._RecordButton.TabIndex = 0;
            this._RecordButton.Text = "Record";
            this._RecordButton.UseVisualStyleBackColor = true;
            this._RecordButton.Click += new System.EventHandler(this._RecordButton_Click);
            // 
            // _SaveButton
            // 
            this._SaveButton.Location = new System.Drawing.Point(3, 32);
            this._SaveButton.Name = "_SaveButton";
            this._SaveButton.Size = new System.Drawing.Size(120, 23);
            this._SaveButton.TabIndex = 1;
            this._SaveButton.Text = "Save";
            this._SaveButton.UseVisualStyleBackColor = true;
            this._SaveButton.Click += new System.EventHandler(this._SaveButton_Click);
            // 
            // _SaveImageButton
            // 
            this._SaveImageButton.Location = new System.Drawing.Point(3, 61);
            this._SaveImageButton.Name = "_SaveImageButton";
            this._SaveImageButton.Size = new System.Drawing.Size(120, 23);
            this._SaveImageButton.TabIndex = 9;
            this._SaveImageButton.Text = "Save Image";
            this._SaveImageButton.UseVisualStyleBackColor = true;
            this._SaveImageButton.Click += new System.EventHandler(this._SaveImageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Package";
            // 
            // _PackageText
            // 
            this._PackageText.Location = new System.Drawing.Point(3, 103);
            this._PackageText.Name = "_PackageText";
            this._PackageText.Size = new System.Drawing.Size(120, 20);
            this._PackageText.TabIndex = 3;
            this._PackageText.TextChanged += new System.EventHandler(this._PackageText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Frequency (s)";
            // 
            // _FrequencySpinner
            // 
            this._FrequencySpinner.Location = new System.Drawing.Point(3, 142);
            this._FrequencySpinner.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this._FrequencySpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._FrequencySpinner.Name = "_FrequencySpinner";
            this._FrequencySpinner.Size = new System.Drawing.Size(120, 20);
            this._FrequencySpinner.TabIndex = 5;
            this._FrequencySpinner.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _DirtyCheck
            // 
            this._DirtyCheck.AutoSize = true;
            this._DirtyCheck.Location = new System.Drawing.Point(3, 207);
            this._DirtyCheck.Name = "_DirtyCheck";
            this._DirtyCheck.Size = new System.Drawing.Size(71, 17);
            this._DirtyCheck.TabIndex = 6;
            this._DirtyCheck.Text = "Dirty Only";
            this._DirtyCheck.UseVisualStyleBackColor = true;
            this._DirtyCheck.CheckedChanged += new System.EventHandler(this._DirtyCheck_CheckedChanged);
            // 
            // _TrackActivities
            // 
            this._TrackActivities.AutoSize = true;
            this._TrackActivities.Checked = true;
            this._TrackActivities.CheckState = System.Windows.Forms.CheckState.Checked;
            this._TrackActivities.Location = new System.Drawing.Point(3, 230);
            this._TrackActivities.Name = "_TrackActivities";
            this._TrackActivities.Size = new System.Drawing.Size(99, 17);
            this._TrackActivities.TabIndex = 8;
            this._TrackActivities.Text = "Track Activities";
            this._TrackActivities.UseVisualStyleBackColor = true;
            // 
            // _NotFoundLabel
            // 
            this._NotFoundLabel.AutoSize = true;
            this._NotFoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._NotFoundLabel.ForeColor = System.Drawing.Color.Crimson;
            this._NotFoundLabel.Location = new System.Drawing.Point(3, 250);
            this._NotFoundLabel.Name = "_NotFoundLabel";
            this._NotFoundLabel.Size = new System.Drawing.Size(111, 13);
            this._NotFoundLabel.TabIndex = 7;
            this._NotFoundLabel.Text = "No Process Found";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Device ID";
            // 
            // _DeviceText
            // 
            this._DeviceText.Location = new System.Drawing.Point(3, 181);
            this._DeviceText.Name = "_DeviceText";
            this._DeviceText.Size = new System.Drawing.Size(120, 20);
            this._DeviceText.TabIndex = 11;
            this._DeviceText.TextChanged += new System.EventHandler(this._DeviceText_TextChanged);
            // 
            // MemTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MemTrackForm";
            this.Text = "Android MemTrack";
            ((System.ComponentModel.ISupportInitialize)(this._MemoryChart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._FrequencySpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart _MemoryChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _RecordButton;
        private System.Windows.Forms.Button _SaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _PackageText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _FrequencySpinner;
        private System.Windows.Forms.CheckBox _DirtyCheck;
        private System.Windows.Forms.Label _NotFoundLabel;
        private System.Windows.Forms.CheckBox _TrackActivities;
        private System.Windows.Forms.Button _SaveImageButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _DeviceText;
    }
}

