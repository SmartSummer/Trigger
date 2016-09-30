using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace 迈创Example.Maxri
{
    public class ImageOperator
    {

        private byte[] _bufferCurrent;
        private Bitmap _bmp;
        private int _Width;
        private int _Height;
        private int _bitDepth;
        private int _Chanle;
        private int _BufferCount;
        private int Num;



        public void UpDataCount(int num = 8)
        {
            Num = num;
            _bufferCurrent = null;
            _bufferCurrent = new byte[_Width * _Height * Num];
            _BufferCount = 0;
        }

        public void UpBMPWH( int Width, int Height)
        {
            _Width = Width;
            _Height = Height;
            _bufferCurrent = null;
            _bufferCurrent = new byte[_Width * _Height * Num];
            _BufferCount = 0;
        }
        public void InitBitmapInfo(int Width, int Height, int BitDepth, int chanle, int buffCount)
        {
            _Width = Width;
            _Height = Height;
            _Chanle = chanle;
            _bitDepth = BitDepth;
            Num = buffCount;
            _BufferCount = 0;
            _bufferCurrent = new byte[_Width * _Height * Num];
        }

  

        public void ExpandBuffer(ref byte[] Src, string Path = "D:/image/image/")
        {
            int start = _BufferCount * _Width * _Height;

         
            Array.Copy(Src, 0, _bufferCurrent, start, Src.Length);
            _BufferCount++;

            if (_BufferCount == Num)
            {
                Bitmap bmp = BytesTo8Bmp(1);

                if (!Directory.Exists(Path)) {
                    Directory.CreateDirectory(Path);
                }
                string name = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_"
                    + DateTime.Now.Millisecond.ToString();

                if(bmp!=null)
                bmp.Save(Path + name + ".bmp");
                
                _BufferCount = 0;
            }
        }

        public Bitmap BytesTo8Bmp(int Direction)
        {


            try
            {
                int imgSize = _bufferCurrent.Length;


                Bitmap bmp = null;
                BitmapData bData = null;
                switch (Direction)
                {

                    case 0:
                        bmp = new Bitmap(_Width * (_BufferCount), _Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        bData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, _Width, _Height * (_BufferCount)), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        break;
                    case 1:
                        bmp = new Bitmap(_Width * (_BufferCount), _Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        bData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, _Width * (_BufferCount), _Height), ImageLockMode.ReadWrite,
                                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        break;


                }


                // Copy the bytes to the bitmap object

                if (bmp != null)
                {
                    System.Runtime.InteropServices.Marshal.Copy(_bufferCurrent, 0, bData.Scan0, imgSize);
                    ColorPalette myMonoColorPalette = null;
                    if (myMonoColorPalette == null)
                    {
                        Bitmap monoBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        myMonoColorPalette = monoBitmap.Palette;
                        for (int i = 0; i < 256; i++)
                            myMonoColorPalette.Entries[i] = System.Drawing.Color.FromArgb(i, i, i);
                    }
                    bmp.Palette = myMonoColorPalette;
                    bmp.UnlockBits(bData);
                }
                return bmp;
            }
            catch (Exception e) {

                return null;
            }

        }


        public static Bitmap ConvertBuffer2Bitmap(byte[] buffer, int width, int height) {

            try
            {
                Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                BitmapData bData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, width, height),
                                        ImageLockMode.ReadWrite, // ImageLockMode.ReadWrite,
                                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                // Copy the bytes to the bitmap object
                System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bData.Scan0, buffer.Length);
                ColorPalette myMonoColorPalette = null;

                if (myMonoColorPalette == null)
                {
                    Bitmap monoBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    myMonoColorPalette = monoBitmap.Palette;
                    for (int i = 0; i < 256; i++)
                        myMonoColorPalette.Entries[i] = System.Drawing.Color.FromArgb(i, i, i);
                }

                bmp.Palette = myMonoColorPalette;
                bmp.UnlockBits(bData);
                return bmp;
            }
            catch (Exception e) {

                return null;
            }
     
        }


        public static double GetRectValueMean(byte[] buffer, int width, int height, int sx, int sy, int endx, int endy)
        {

            double value = 0.0;
         
            for(int i = sx;i<endx;i++){
            
                for(int j = sy;j<endy;j++){
                
                value = value + buffer[j * width + i];

                }
            }
            value = value / ((endx - sx) * (endy - sy));

            return value;
        }
    }
}
