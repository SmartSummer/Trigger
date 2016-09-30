using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BX_BaumerMutileCamera.BX_Baumer;
using 迈创Example.Maxri;
using System.Collections;
using TriggerBigImage.Utils;
using System.Windows.Forms.DataVisualization.Charting;
using TriggerBigImage.Axis;
using System.Threading;

namespace TriggerBigImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                ////bca = new BaseControlAxis();
                ////int w = this.pictureBox1.Width;
                ////int h = this.pictureBox1.Height;
                ////bca.InitPos(20, h - 40, w - 20 - 20, h - 40 - 20, 100, ref this.pictureBox1);
                ////InitalAll();

            }
            catch (Exception e)
            {
                this.Rect_Button.Enabled = false;
                MessageBox.Show("" + e.ToString());
            }


        }


        public   double _widthScale;
        public   double _heightScale;
        protected override void OnClosing(CancelEventArgs e)
        {

            try
            {
                if (_bx_Baumer.isOpen == true)
                {
                    if (_bx_Baumer.FlagOpenArray[0] > 0)
                    {
                        _bx_Baumer.Stop(0);

                    }
                    //_bx_Baumer.Close(0);
                }
            }
            catch (Exception Error)
            {


            }
            System.Environment.Exit(System.Environment.ExitCode);
            //System.Environment.ExitCode;
            GC.Collect();
            GC.WaitForPendingFinalizers();


        }

        #region 初始化操作

        void InitalAll()
        {

            initalinstance();
            _bx_Baumer.FlagOpenArray[0] = -1;
            if (_bx_Baumer.mDeviceList.Count > 0)
            {
                initalCallBack();
                //InitalData();
                InitalCamera();
                InitScale();
                _bx_Baumer.isOpen = true;

                

                MessageBox.Show("相机打开成功");
            }
            else
            {

                this.Rect_Button.Enabled = false;

                MessageBox.Show("相机未找到找到");
            }
        }

        void InitScale() {

            RangleValue _WidRangValue = _bx_Baumer.GetRangleValue("Width", 0);
            RangleValue _HeiRangValue = _bx_Baumer.GetRangleValue("Height", 0);


            _widthScale = double.Parse( _WidRangValue.max) / BX_ShowImage.Width;
            _heightScale = double.Parse(_HeiRangValue.max) / BX_ShowImage.Height;


        }
        void InitalCamera()
        {

            _bx_Baumer.FlagOpenArray[0] = 1;
            _bx_Baumer.mDeviceList[0].initalStream();
            _bx_Baumer.mDeviceList[0].startDetect();
        }
        void initalCallBack()
        {

            GetImageBufferCall = new getImageInfor(ImageCallback);
            _bx_Baumer.mDeviceList[0].setDeleglte(GetImageBufferCall);
        }
        void initalinstance()
        {

            _bx_Baumer = new BX_Baumer();

            _bx_Baumer.initSystem();

        }

        void defaultConfig()
        {
            _config = new ConfigPage();

            _config.Width = "656";
            _config.Height = "494";
            _config.OffsetX = "0";
            _config.OffsetY = "0";
            _config.ExposeTime = "656";
            _config.ImageCount = "10";

            _config.save = false;

        }

        void setBinding()
        {

  
            imageOperator = new ImageOperator();
            imageOperator.InitBitmapInfo(int.Parse(_config.Width), int.Parse(_config.Height), 8, 1, int.Parse(_config.ImageCount));

            ////_BindSource.DataSource = typeof(ConfigPage);
            ////_BindSource.Add(_config);



            this.BX_Width.DataBindings.Add("Text", _config, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            this.BX_Height.DataBindings.Add("Text", _config, "Height", false, DataSourceUpdateMode.OnPropertyChanged);
            this.BX_ImageCount.DataBindings.Add("Text", _config, "ImageCount", false, DataSourceUpdateMode.OnPropertyChanged);
            this.BX_OffsetX.DataBindings.Add("Text", _config, "OffsetX", false, DataSourceUpdateMode.OnPropertyChanged);
            this.BX_OffsetY.DataBindings.Add("Text", _config, "OffsetY", false, DataSourceUpdateMode.OnPropertyChanged);
            this.BX_ExposeTimeText.DataBindings.Add("Text", _config, "ExposeTime", false, DataSourceUpdateMode.OnPropertyChanged);
            this.IsSave.DataBindings.Add("Checked", _config, "save", false, DataSourceUpdateMode.OnPropertyChanged);

                
        }
        void InitalData()
        {

            _BindSource = new BindingSource();

            try
            {
                _config = (ConfigPage)XmlUtil.Deserialize(typeof(ConfigPage), Path);

                if (_config == null)
                {

                    try
                    {


                        RangleValue _WidRangValue = _bx_Baumer.GetRangleValue("Width", 0);
                        RangleValue _HeiRangValue = _bx_Baumer.GetRangleValue("Height", 0);
                        RangleValue _exposeTime = _bx_Baumer.GetRangleValue("ExposureTime", 0);
                        RangleValue _offsetX = _bx_Baumer.GetRangleValue("OffsetX", 0);
                        RangleValue _offsetY = _bx_Baumer.GetRangleValue("OffsetY", 0);



                        if (!String.IsNullOrEmpty(_WidRangValue.value))
                        {
                            _config = new ConfigPage();
                            _config.MaxWidth = long.Parse(_WidRangValue.max);
                            _config.MaxHeight = long.Parse(_HeiRangValue.max);

                            _config.Width = _WidRangValue.value;
                            _config.Height = _HeiRangValue.value;
                            _config.ExposeTime = _HeiRangValue.value;
                            _config.OffsetX = _offsetX.value;
                            _config.OffsetY = _offsetY.value;
                            _config.ImageCount = "10";
                        }
                        else
                        {

                            defaultConfig();
                        }


                    }

                    catch (Exception ee)
                    {

                        defaultConfig();
                       // this.Rect_Button.Enabled = false;
                    }


                }
                else
                {

                    RangleValue _WidRangValue = _bx_Baumer.GetRangleValue("Width", 0);
                    RangleValue _HeiRangValue = _bx_Baumer.GetRangleValue("Height", 0);
                    _config.MaxWidth = long.Parse(_WidRangValue.max);
                    _config.MaxHeight = long.Parse(_HeiRangValue.max);

                    _bx_Baumer.SetNodeValue("Width", 0, long.Parse(_config.Width));
                    _bx_Baumer.SetNodeValue("Height", 0, long.Parse(_config.Height));
                    _bx_Baumer.SetNodeValue("ExposureTime", 0, double.Parse(_config.ExposeTime));
                }


                setBinding();

            }
            catch (Exception e)
            {


            }


        }

        #endregion


        string foldPath;
        private void Camera_Open_Click(object sender, EventArgs e)
        {


            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            ////if (_bx_Baumer.isOpen == true)
            ////{
            ////    if (_bx_Baumer.FlagOpenArray[0] > 0)
            ////    {

            ////        MessageBox.Show("相机已经打开");
            ////        return;
            ////    }


            ////    _bx_Baumer.mDeviceList[0].startDetect();
            ////    _bx_Baumer.FlagOpenArray[0] = 1;
            ////    MessageBox.Show("相机打开成功");

            ////}
            ////else
            ////{

            ////    InitalAll();
            ////}

        }

        private void ImageCallback(BX_ImageInfo imageInfo)
        {


            Bitmap bmp = ImageOperator.ConvertBuffer2Bitmap(imageInfo.ImageBuffer, (int)imageInfo.SizeWidth, (int)imageInfo.SizeHeight);

            
            if (bmp != null)
            {
                ////if (_config.save == true)
                ////{
                ////    imageOperator.ExpandBuffer(ref imageInfo.ImageBuffer);
                ////}

                this.BX_ShowImage.Image = bmp;

                
                if (isRectReady == true) {


                    if (this.BX_ShowImage.InvokeRequired)
                    {

                        DrawRect dr = new DrawRect(PictureBoxDraw.DrawRect);
                        BX_ShowImage.Invoke(dr,this.BX_ShowImage, _startPoint, _endPoint, new Pen(Brushes.Blue));


                        double value = ImageOperator.GetRectValueMean(imageInfo.ImageBuffer, (int)imageInfo.SizeWidth, (int)imageInfo.SizeHeight, _startPoint.X, _startPoint.Y, _endPoint.X, _endPoint.Y);
                        
                        if (isCount == true)
                        {
                            bca.AddData(value);
                            bca.ShowData();
                         
                        }
                        PictureBoxDraw.DrawRect(ref this.BX_ShowImage, _startPoint, _endPoint, new Pen(Brushes.Blue));
                    }
                }
            }

        }
        delegate  void DrawRect(ref PictureBox pb, Point start, Point end, Pen p);
        private BX_Baumer _bx_Baumer;
        private event getImageInfor GetImageBufferCall;
        private BindingSource _BindSource;
        private ConfigPage _config;
        private ImageOperator imageOperator;
        private static readonly string Path = System.Environment.CurrentDirectory + "\\config.xml";

        private void BX_Setting_Click(object sender, EventArgs e)
        {
           
            try
            {

                if (_bx_Baumer.FlagOpenArray[0] < 1)
                {

                    MessageBox.Show("相机未正确打开");
                    return;
                }

                long _widValue = long.Parse(_config.Width);
                long _heiValue = long.Parse(_config.Height);
                long offstX = long.Parse(_config.OffsetX);
                long offstY = long.Parse(_config.OffsetY);
                double exposeTime = double.Parse(_config.ExposeTime);

                if (_widValue + offstX < _config.MaxWidth + 1 && _heiValue + offstY < _config.MaxHeight + 1)
                {

                    _bx_Baumer.SetNodeValue("Width", 0, _widValue);
                    _bx_Baumer.SetNodeValue("OffsetX", 0, offstX);

                    _bx_Baumer.SetNodeValue("Height", 0, _heiValue);
                    _bx_Baumer.SetNodeValue("OffsetY", 0, offstY);
                    try
                    {
                        _bx_Baumer.SetNodeValue("ExposureTime", 0, double.Parse(_config.ExposeTime));
                    }
                    catch (Exception eee)
                    {

                        MessageBox.Show("曝光时间不对");
                    }
                    imageOperator.UpBMPWH((int)_widValue, (int)_heiValue);
                    XmlUtil.Serializer(_config.GetType(), _config, Path);

                    MessageBox.Show("设置成功");

                }
                else
                {

                    MessageBox.Show("高度或宽度越界");
                }




            }
            catch (Exception ee)
            {

                MessageBox.Show("设置失败");
            }

        }

        private void Camera_Trigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bx_Baumer.FlagOpenArray[0] < 1)
                {

                    MessageBox.Show("相机未正确打开");
                    return;
                }
                _bx_Baumer.mDeviceList[0].setTriggerMode(ETRIGGERMODE.HARDWARE);

            }
            catch (Exception ee)
            {

            }
        }

        private void BX_Close_Click(object sender, EventArgs e)
        {
            try
            {
          
            if (_bx_Baumer.FlagOpenArray[0] < 1)
            {
                return;
            }
            _bx_Baumer.Stop(0);
            MessageBox.Show("关闭成功");
            }
        catch (Exception ee)
        {

        }
        }

        private void BX_Continue_Click(object sender, EventArgs e)
        {

            try
            {
                if (_bx_Baumer.FlagOpenArray[0] < 1)
                {

                    MessageBox.Show("相机未正确打开");
                    return;
                }
                _bx_Baumer.mDeviceList[0].setTriggerMode(ETRIGGERMODE.CONTINUE);
            }
            catch (Exception ee) { 
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _config.ImageCount = this.BX_ImageCount.Text.ToString().Trim();

                imageOperator.UpDataCount(int.Parse(BX_ImageCount.Text.ToString().Trim()));
                XmlUtil.Serializer(_config.GetType(), _config, Path);
            }
            catch (Exception ee)
            {

                MessageBox.Show("输入不合法");
            }
        }

        private void Rect_Button_Click(object sender, EventArgs e)
        {

        }


        #region 鼠标事件

        private void BX_ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
                isDown = true;
                isRectReady = false;
                _startPoint = e.Location;
     

        }
        private void BX_ImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if ( isDown == true)
            {

                _endPoint = e.Location;
                JudeBorder();
                PictureBoxDraw.DrawRect(ref this.BX_ShowImage, _startPoint, _endPoint, new Pen(Brushes.Blue));
            }
            isDown = false;
          
        }

        private void BX_ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ( isDown == true)
            {
                _endPoint = e.Location;
                JudeBorder();
                PictureBoxDraw.DrawRect(ref this.BX_ShowImage, _startPoint, _endPoint, new Pen(Brushes.Blue));
                isRectReady = true;
            }
        }

        private void JudeBorder()
        {


            if (_endPoint.X > BX_ShowImage.Size.Width)
            {

                _endPoint.X = BX_ShowImage.Size.Width - 1;
            }

            if (_endPoint.Y > BX_ShowImage.Size.Height)
            {

                _endPoint.Y = BX_ShowImage.Size.Height - 1;
            }
        }
        private Point _startPoint;
        private Point _endPoint;
        private bool isDown;
        private bool isRectReady;
        #endregion

        private void Export_Click(object sender, EventArgs e)
        {
            isCount = false;
            Axis_Count.Text = "统计";
            bca.ExportExcel();
            bca.Refesh();
        }

        private BaseControlAxis bca;
        public void InitializeChart()
        {
            #region 设置图表的属性
            //图表的背景色
            myChart.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            myChart.BackGradientStyle = GradientStyle.TopBottom;
            //图表的边框颜色、
            myChart.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            myChart.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            myChart.BorderlineWidth = 2;
            //图表边框的皮肤
            myChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion

            #region 设置图表的Title
            Title title = new Title();
            //标题内容
            title.Text = "多曲线图演示";
            //标题的字体
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            //标题字体颜色
            title.ForeColor = Color.FromArgb(26, 59, 105);
            //标题阴影颜色
            title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            //标题阴影偏移量
            title.ShadowOffset = 3;

            myChart.Titles.Add(title);
            #endregion

            #region 设置图表区属性
            //图表区的名字
            ChartArea chartArea = new ChartArea("Default");
            //背景色
            chartArea.BackColor = Color.FromArgb(64, 165, 191, 228);
            //背景渐变方式
            chartArea.BackGradientStyle = GradientStyle.TopBottom;
            //渐变和阴影的辅助背景色
            chartArea.BackSecondaryColor = Color.White;
            //边框颜色
            chartArea.BorderColor = Color.FromArgb(64, 64, 64, 64);
            //阴影颜色
            chartArea.ShadowColor = Color.Transparent;

            //设置X轴和Y轴线条的颜色和宽度
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineWidth = 1;
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.LineWidth = 1;

            //设置X轴和Y轴的标题
            chartArea.AxisX.Title = "横坐标标题";
            chartArea.AxisY.Title = "纵坐标标题";

            //设置图表区网格横纵线条的颜色和宽度
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineWidth = 1;

            myChart.ChartAreas.Add(chartArea);
            #endregion

            #region 图例及图例的位置
            Legend legend = new Legend();
            legend.Alignment = StringAlignment.Center;
            legend.Docking = Docking.Bottom;

            this.myChart.Legends.Add(legend);
            #endregion
        }

        public void InitalChartData() {


            float[][] data = new float[3][];
            //第一条数据
            data[0] = new float[10] { 1.3f, 2.5f, 2.1f, 3.3f, 2.8f, 3.9f, 4.3f, 3.6f, 4.2f, 3.6f };
            //第二条数据
            data[1] = new float[12] { -2f, -1.3f, 0.1f, 0.5f, -1.5f, 0.7f, 1f, 1.4f, 1.9f, 2f, 2.6f, 3.1f };
            //第三条数据
            data[2] = new float[10] { 7.8f, 9.2f, 6.5f, 8.3f, 9.0f, 5.9f, 6.3f, 7.2f, 8.8f, 9.8f };

            for (int i = 0; i < data.Length; i++)
            {
                //横坐标时间
                DateTime dt = DateTime.Now.Date;
                Series series = this.SetSeriesStyle(i);
                for (int j = 0; j < data[i].Length; j++)
                {
                    series.Points.AddXY(dt, data[i][j]);
                    dt = dt.AddDays(1);
                }
                this.myChart.Series.Add(series);
            }
        }


        //设置Series样式
        private Series SetSeriesStyle(int i)
        {
            Series series = new Series(string.Format("第{0}条数据", i + 1));

            //Series的类型
            series.ChartType = SeriesChartType.Line;
            //Series的边框颜色
            series.BorderColor = Color.FromArgb(180, 26, 59, 105);
            //线条宽度
            series.BorderWidth = 3;
            //线条阴影颜色
            series.ShadowColor = Color.Black;
            //阴影宽度
            series.ShadowOffset = 2;
            //是否显示数据说明
            series.IsVisibleInLegend = true;
            //线条上数据点上是否有数据显示
            series.IsValueShownAsLabel = false;
            //线条上的数据点标志类型
            series.MarkerStyle = MarkerStyle.Circle;
            //线条数据点的大小
            series.MarkerSize = 8;
            //线条颜色
            switch (i)
            {
                case 0:
                    series.Color = Color.FromArgb(220, 65, 140, 240);
                    break;
                case 1:
                    series.Color = Color.FromArgb(220, 224, 64, 10);
                    break;
                case 2:
                    series.Color = Color.FromArgb(220, 120, 150, 20);
                    break;
            }
            return series;
        }


        private bool isCount;
        private void Axis_Count_Click(object sender, EventArgs e)
        {

            BaseControlAxis.Max = int.Parse(Text_CountNum.Text.ToString());
        
            if (isCount == false)
            {

                Axis_Count.Text = "停止";    
                isCount = true;
            }
            else {

                isCount = false;
                Axis_Count.Text = "统计";
            }
        }

        private void ImageChanged(object sender, EventArgs e)
        {
           
        }


    }
}
