namespace TriggerBigImage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BX_ShowImage = new System.Windows.Forms.PictureBox();
            this.table1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Axis_Count = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Text_CountNum = new System.Windows.Forms.TextBox();
            this.Rect_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BX_ExposeTimeText = new System.Windows.Forms.TextBox();
            this.IsSave = new System.Windows.Forms.CheckBox();
            this.BX_Close = new System.Windows.Forms.Button();
            this.BX_Continue = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BX_OffsetY = new System.Windows.Forms.TextBox();
            this.BX_OffsetXLabel = new System.Windows.Forms.Label();
            this.BX_OffsetX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BX_Setting = new System.Windows.Forms.Button();
            this.BX_Height = new System.Windows.Forms.TextBox();
            this.BX_Width = new System.Windows.Forms.TextBox();
            this.Camera_Trigger = new System.Windows.Forms.Button();
            this.Camera_Open = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BX_ImageCount_Button = new System.Windows.Forms.Button();
            this.BX_ImageCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.myChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BX_ShowImage)).BeginInit();
            this.table1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BX_ShowImage
            // 
            this.BX_ShowImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BX_ShowImage.Location = new System.Drawing.Point(12, 26);
            this.BX_ShowImage.Name = "BX_ShowImage";
            this.BX_ShowImage.Size = new System.Drawing.Size(709, 426);
            this.BX_ShowImage.TabIndex = 0;
            this.BX_ShowImage.TabStop = false;
            this.BX_ShowImage.BackgroundImageChanged += new System.EventHandler(this.ImageChanged);
            this.BX_ShowImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BX_ImageBox_MouseDown);
            this.BX_ShowImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BX_ImageBox_MouseMove);
            this.BX_ShowImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BX_ImageBox_MouseUp);
            // 
            // table1
            // 
            this.table1.Controls.Add(this.tabPage1);
            this.table1.Controls.Add(this.tabPage2);
            this.table1.Location = new System.Drawing.Point(727, 26);
            this.table1.Name = "table1";
            this.table1.SelectedIndex = 0;
            this.table1.Size = new System.Drawing.Size(180, 426);
            this.table1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(172, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Axis_Count);
            this.groupBox1.Controls.Add(this.Export);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Text_CountNum);
            this.groupBox1.Controls.Add(this.Rect_Button);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BX_ExposeTimeText);
            this.groupBox1.Controls.Add(this.IsSave);
            this.groupBox1.Controls.Add(this.BX_Close);
            this.groupBox1.Controls.Add(this.BX_Continue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BX_OffsetY);
            this.groupBox1.Controls.Add(this.BX_OffsetXLabel);
            this.groupBox1.Controls.Add(this.BX_OffsetX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BX_Setting);
            this.groupBox1.Controls.Add(this.BX_Height);
            this.groupBox1.Controls.Add(this.BX_Width);
            this.groupBox1.Controls.Add(this.Camera_Trigger);
            this.groupBox1.Controls.Add(this.Camera_Open);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机控制";
            // 
            // Axis_Count
            // 
            this.Axis_Count.Location = new System.Drawing.Point(7, 194);
            this.Axis_Count.Name = "Axis_Count";
            this.Axis_Count.Size = new System.Drawing.Size(75, 23);
            this.Axis_Count.TabIndex = 20;
            this.Axis_Count.Text = "统计";
            this.Axis_Count.UseVisualStyleBackColor = true;
            this.Axis_Count.Click += new System.EventHandler(this.Axis_Count_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(7, 299);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 19;
            this.Export.Text = "导出Excel";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "统计个数";
            // 
            // Text_CountNum
            // 
            this.Text_CountNum.Location = new System.Drawing.Point(7, 158);
            this.Text_CountNum.Name = "Text_CountNum";
            this.Text_CountNum.Size = new System.Drawing.Size(100, 21);
            this.Text_CountNum.TabIndex = 17;
            this.Text_CountNum.Text = "1000";
            // 
            // Rect_Button
            // 
            this.Rect_Button.Location = new System.Drawing.Point(7, 109);
            this.Rect_Button.Name = "Rect_Button";
            this.Rect_Button.Size = new System.Drawing.Size(75, 23);
            this.Rect_Button.TabIndex = 16;
            this.Rect_Button.Text = "画框";
            this.Rect_Button.UseVisualStyleBackColor = true;
            this.Rect_Button.Click += new System.EventHandler(this.Rect_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "曝光";
            this.label4.Visible = false;
            // 
            // BX_ExposeTimeText
            // 
            this.BX_ExposeTimeText.Location = new System.Drawing.Point(16, 262);
            this.BX_ExposeTimeText.Name = "BX_ExposeTimeText";
            this.BX_ExposeTimeText.Size = new System.Drawing.Size(100, 21);
            this.BX_ExposeTimeText.TabIndex = 14;
            this.BX_ExposeTimeText.Visible = false;
            // 
            // IsSave
            // 
            this.IsSave.AutoSize = true;
            this.IsSave.Location = new System.Drawing.Point(103, 349);
            this.IsSave.Name = "IsSave";
            this.IsSave.Size = new System.Drawing.Size(48, 16);
            this.IsSave.TabIndex = 13;
            this.IsSave.Text = "保存";
            this.IsSave.UseVisualStyleBackColor = true;
            this.IsSave.Visible = false;
            // 
            // BX_Close
            // 
            this.BX_Close.Location = new System.Drawing.Point(87, 70);
            this.BX_Close.Name = "BX_Close";
            this.BX_Close.Size = new System.Drawing.Size(71, 23);
            this.BX_Close.TabIndex = 12;
            this.BX_Close.Text = "关闭";
            this.BX_Close.UseVisualStyleBackColor = true;
            this.BX_Close.Click += new System.EventHandler(this.BX_Close_Click);
            // 
            // BX_Continue
            // 
            this.BX_Continue.Location = new System.Drawing.Point(83, 21);
            this.BX_Continue.Name = "BX_Continue";
            this.BX_Continue.Size = new System.Drawing.Size(75, 23);
            this.BX_Continue.TabIndex = 11;
            this.BX_Continue.Text = "连续";
            this.BX_Continue.UseVisualStyleBackColor = true;
            this.BX_Continue.Click += new System.EventHandler(this.BX_Continue_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y偏移";
            this.label5.Visible = false;
            // 
            // BX_OffsetY
            // 
            this.BX_OffsetY.Location = new System.Drawing.Point(16, 226);
            this.BX_OffsetY.Name = "BX_OffsetY";
            this.BX_OffsetY.Size = new System.Drawing.Size(100, 21);
            this.BX_OffsetY.TabIndex = 9;
            this.BX_OffsetY.Visible = false;
            // 
            // BX_OffsetXLabel
            // 
            this.BX_OffsetXLabel.AutoSize = true;
            this.BX_OffsetXLabel.Location = new System.Drawing.Point(123, 199);
            this.BX_OffsetXLabel.Name = "BX_OffsetXLabel";
            this.BX_OffsetXLabel.Size = new System.Drawing.Size(35, 12);
            this.BX_OffsetXLabel.TabIndex = 8;
            this.BX_OffsetXLabel.Text = "X偏移";
            this.BX_OffsetXLabel.Visible = false;
            // 
            // BX_OffsetX
            // 
            this.BX_OffsetX.Location = new System.Drawing.Point(16, 199);
            this.BX_OffsetX.Name = "BX_OffsetX";
            this.BX_OffsetX.Size = new System.Drawing.Size(100, 21);
            this.BX_OffsetX.TabIndex = 7;
            this.BX_OffsetX.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "高度";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "宽度";
            this.label1.Visible = false;
            // 
            // BX_Setting
            // 
            this.BX_Setting.Location = new System.Drawing.Point(7, 345);
            this.BX_Setting.Name = "BX_Setting";
            this.BX_Setting.Size = new System.Drawing.Size(75, 23);
            this.BX_Setting.TabIndex = 4;
            this.BX_Setting.Text = "设置";
            this.BX_Setting.UseVisualStyleBackColor = true;
            this.BX_Setting.Visible = false;
            this.BX_Setting.Click += new System.EventHandler(this.BX_Setting_Click);
            // 
            // BX_Height
            // 
            this.BX_Height.Location = new System.Drawing.Point(16, 158);
            this.BX_Height.Name = "BX_Height";
            this.BX_Height.Size = new System.Drawing.Size(100, 21);
            this.BX_Height.TabIndex = 3;
            this.BX_Height.Visible = false;
            // 
            // BX_Width
            // 
            this.BX_Width.Location = new System.Drawing.Point(16, 120);
            this.BX_Width.Name = "BX_Width";
            this.BX_Width.Size = new System.Drawing.Size(100, 21);
            this.BX_Width.TabIndex = 2;
            this.BX_Width.Visible = false;
            // 
            // Camera_Trigger
            // 
            this.Camera_Trigger.Location = new System.Drawing.Point(7, 70);
            this.Camera_Trigger.Name = "Camera_Trigger";
            this.Camera_Trigger.Size = new System.Drawing.Size(75, 23);
            this.Camera_Trigger.TabIndex = 1;
            this.Camera_Trigger.Text = "硬触发";
            this.Camera_Trigger.UseVisualStyleBackColor = true;
            this.Camera_Trigger.Click += new System.EventHandler(this.Camera_Trigger_Click);
            // 
            // Camera_Open
            // 
            this.Camera_Open.Location = new System.Drawing.Point(7, 21);
            this.Camera_Open.Name = "Camera_Open";
            this.Camera_Open.Size = new System.Drawing.Size(75, 23);
            this.Camera_Open.TabIndex = 0;
            this.Camera_Open.Text = "打开";
            this.Camera_Open.UseVisualStyleBackColor = true;
            this.Camera_Open.Click += new System.EventHandler(this.Camera_Open_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(172, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "参数控制";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BX_ImageCount_Button);
            this.groupBox2.Controls.Add(this.BX_ImageCount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(0, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 388);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数";
            // 
            // BX_ImageCount_Button
            // 
            this.BX_ImageCount_Button.Location = new System.Drawing.Point(6, 76);
            this.BX_ImageCount_Button.Name = "BX_ImageCount_Button";
            this.BX_ImageCount_Button.Size = new System.Drawing.Size(75, 23);
            this.BX_ImageCount_Button.TabIndex = 2;
            this.BX_ImageCount_Button.Text = "确定";
            this.BX_ImageCount_Button.UseVisualStyleBackColor = true;
            this.BX_ImageCount_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // BX_ImageCount
            // 
            this.BX_ImageCount.Location = new System.Drawing.Point(59, 35);
            this.BX_ImageCount.Name = "BX_ImageCount";
            this.BX_ImageCount.Size = new System.Drawing.Size(100, 21);
            this.BX_ImageCount.TabIndex = 1;
            this.BX_ImageCount.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "个数";
            // 
            // myChart
            // 
            chartArea1.Name = "ChartArea1";
            this.myChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.myChart.Legends.Add(legend1);
            this.myChart.Location = new System.Drawing.Point(913, 54);
            this.myChart.Name = "myChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.myChart.Series.Add(series1);
            this.myChart.Size = new System.Drawing.Size(361, 10);
            this.myChart.TabIndex = 2;
            this.myChart.Text = "MyChart";
            this.myChart.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(913, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 440);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 440);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myChart);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.BX_ShowImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BX_ShowImage)).EndInit();
            this.table1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BX_ShowImage;
        private System.Windows.Forms.TabControl table1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BX_Setting;
        private System.Windows.Forms.TextBox BX_Height;
        private System.Windows.Forms.TextBox BX_Width;
        private System.Windows.Forms.Button Camera_Trigger;
        private System.Windows.Forms.Button Camera_Open;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BX_ImageCount_Button;
        private System.Windows.Forms.TextBox BX_ImageCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BX_OffsetY;
        private System.Windows.Forms.Label BX_OffsetXLabel;
        private System.Windows.Forms.TextBox BX_OffsetX;
        private System.Windows.Forms.Button BX_Continue;
        private System.Windows.Forms.Button BX_Close;
        private System.Windows.Forms.CheckBox IsSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BX_ExposeTimeText;
        private System.Windows.Forms.Button Rect_Button;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Text_CountNum;
        private System.Windows.Forms.DataVisualization.Charting.Chart myChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Axis_Count;
    }
}

