using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriggerBigImage.Utils
{
    public class Utils
    {
        public static void List2Excel(List<double> list) {

            //建立Excel对象
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            xlApp.Visible = true;//是否打开该Excel文件

           // 填充数据
            for (int c = 0; c < list.Count; c++)
            {

                worksheet.Cells[c + 1, 1] = list[c].ToString();
              
            }

            string name = FileManager.SaveDilag();

            if (!String.IsNullOrEmpty(name)) {
                worksheet.SaveAs(name);
                //xlApp.SaveWorkspace(name);

            } else 
            { 
                System.Windows.Forms.MessageBox.Show("名字输入不合法"); 
            }
        }

    }
}
