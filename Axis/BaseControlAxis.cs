using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TriggerBigImage.Axis
{
    public class BaseControlAxis
    {
        public static int Max = 100;
        private PictureBox _pb;
        private int origx;
        private int origy;
        private int XLength;
        private int YLength;
        private int count;
        private Graphics g;
        private List<double> _list;
        private List<double> _showList;
        private double span_x;
        private double span_Y;
        public void InitPos(int x,int y ,int xLength,int yLength,int num,ref PictureBox pb){
           
            _list = new List<double>();
            _pb = pb;
            origx = x;
            origy = y;
            XLength = xLength+5;
            count = num;
            YLength = yLength+5;
            g = pb.CreateGraphics();
            _showList = new List<double>();
            span_x = xLength / num;
            _pb.Refresh();

            //DrawLine(0, 0, 100, 100);
        }


        public void InitalCoord() {


            DrawLine(origx, origy, origx+XLength, origy);
            DrawLine(origx, origy, origx, origy-YLength);
            //Arrows -X
            DrawLine(origx + XLength, origy, origx + XLength-5, origy-5);
            DrawLine(origx + XLength, origy, origx +XLength - 5, origy + 5);
            //Arrows -Y
            DrawLine(origx, origy - YLength, origx-5, origy - YLength+5);
            DrawLine(origx, origy - YLength, origx +5, origy - YLength + 5);


        }
       public void DrawLine(int x,int y,int ex,int ey) {
        
            
            g.DrawLine(new Pen(Brushes.Red),new Point(x,y),new Point(ex,ey));
            
        }

       public void ShowData()
       {

           if (_pb.InvokeRequired && Max>_list.Count) {

               DrawDelegate sw = new DrawDelegate(showDataAsyc);
               _pb.Invoke(sw);

           }
       
       }


      delegate void DrawDelegate();
       void showDataAsyc() {

          
           g = _pb.CreateGraphics();
           _pb.Refresh();
           InitalCoord();
           double max = GetMax();
           double min = GetMin();
           if (max - min == 0) {

               span_Y = 0.5;
           }else
           span_Y = (YLength - 5) / (max - min);


           int index = 0;

           if (_showList.Count > 2)
           {
               PointF[] points = new PointF[_showList.Count];
               foreach (double da in _showList)
               {



                   double y = (da - min) * span_Y;
                   double x = (index + 1) * span_x;

                   points[index].X = (float)origx + (float)x;
                   points[index].Y = (float)origy - (float)y;
                   index++;
               }
               g.DrawLines(new Pen(Brushes.Blue), points);
           }
       }

       public void AddData(double x) {

           _list.Add(x);
           if (_showList.Count < count+1)
           {

               _showList.Add(x);
           }
           else {

               _showList.Add(x);
               _showList.RemoveAt(0);
           }
       }

       private  double GetMax() {

          return _showList.Max();
       }

       private double GetMin()
       {

           return _showList.Min();
       }

       public void ExportExcel() {

           Utils.Utils.List2Excel(_list);
       }
       public void Refesh() {

           _list.Clear();
           _showList.Clear();
       }

    }
}
