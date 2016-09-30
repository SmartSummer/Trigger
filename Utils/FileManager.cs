using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TriggerBigImage.Utils
{
   public class FileManager
    {

       public static void Save(ConfigPage configClass,string path) {

           XmlUtil.Serializer(configClass.GetType(), configClass, path);
       }

       public static string SaveDilag() {

           SaveFileDialog sfd = new SaveFileDialog();
           sfd.InitialDirectory = "E:\\";
           sfd.Filter = "xls文件(*.xls)|*.xls";
           if (sfd.ShowDialog() == DialogResult.OK)
           {
              return  sfd.FileName;
           }

           return null;

       }
    }
}
