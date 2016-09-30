using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGAPI2;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BX_BaumerMutileCamera.BX_Baumer
{


    public class ManagerDevice
    {
        public void setDeviceDesct(ref Device device, ref string value) {
          
            this._device = device;
            this._descript = value;
        }


        public void setDeviceDesct(ref Device device, ref int value)
        {

            this._device = device;
            this._value = value;
        }


        public Device getCurrentDevice() {

            return _device;
        }


        public void initalStream()
        {
            try
            {
                // MessageBox.Show("mDevice:= " + mDevice.Length) 
                datastreamList = _device.DataStreams;
                datastreamList.Refresh();
                //MessageBox.Show(datastreamList.Count + " datastreamList.Count");
                foreach (KeyValuePair<string, BGAPI2.DataStream> dst_pair in datastreamList)
                {

                    dst_pair.Value.Open();
                    string sDataStreamID = dst_pair.Key;
                    // MessageBox.Show("datastream");
                    mDataStream = datastreamList[sDataStreamID];
                    bufferList = mDataStream.BufferList;

                    // 4 buffers using internal buffer mode
                    for (int i = 0; i < 4; i++)
                    {
                        mBuffer = new BGAPI2.Buffer();
                        bufferList.Add(mBuffer);
                    }
                    foreach (KeyValuePair<string, BGAPI2.Buffer> buf_pair in bufferList)
                    {
                        buf_pair.Value.QueueBuffer();
                    }

                    //   MessageBox.Show(datastreamList.Count + "   mDataStream.RegisterNewBufferEvent(BGAPI2.Events.EventMode.EVENT_HANDLER);");
                    mDataStream.RegisterNewBufferEvent(BGAPI2.Events.EventMode.EVENT_HANDLER);
                    mDataStream.NewBufferEvent += new BGAPI2.Events.DataStreamEventControl.NewBufferEventHandler(mDataStream_NewBufferEvent);

                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("****注册回调函数失败****   请检查相机驱动，配置ip:" + "e:" + e.ToString());
            }

            ////string path = Environment.CurrentDirectory + "\\Result\\";
            ////if (!System.IO.Directory.Exists(path))    //路径不存在就创建
            ////{
            ////    System.IO.Directory.CreateDirectory(path);
            ////}

            ////string logName = "camera_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
          //  infolog1.InitInfoOut_TriggerControl(path + logName, true);
        }
      
        private void mDataStream_NewBufferEvent(object sender, BGAPI2.Events.NewBufferEventArgs mDSEvent)
        {
            try
            {
                BGAPI2.Buffer mBufferFilled = null;
                mBufferFilled = mDSEvent.BufferObj;
                if (mBufferFilled == null)
                {
                   // a1++;
                   // infolog1.putoutCommInfo("a1 = " + a1.ToString());
                }
                else if (mBufferFilled.IsIncomplete == true)
                {
                   // a2++;
                  //  infolog1.putoutCommInfo("a2 = " + a2.ToString());

                    // queue buffer again
                    mBufferFilled.QueueBuffer();
                }
                else
                {
                   // a3++;
                    //infolog1.putoutCommInfo("a3 = " + a3.ToString());

                   
                 //   mBufferFilled.QueueBuffer();

                    imageInfo.ImageSize = (uint)mBufferFilled.SizeFilled;
                    imageInfo.SizeWidth = (uint)mBufferFilled.Width;
                    imageInfo.SizeHeight = (uint)mBufferFilled.Height;
                    imageInfo.ImagePoint = mBufferFilled.MemPtr;
                    imageInfo.ImageBuffer = new byte[imageInfo.ImageSize];
                    Marshal.Copy(mBufferFilled.MemPtr, imageInfo.ImageBuffer, 0, (int)(imageInfo.ImageSize));
                    try
                    {
                        getImage(imageInfo);
                    }
                    catch (Exception e)
                    {
                       //MessageBox.Show("e.errror:= " + e.ToString());
                    }
                    mBufferFilled.QueueBuffer();
                }

            }
            catch (BGAPI2.Exceptions.IException ex)
            {
                // System.Windows.Forms.MessageBox.Show("调用回调失败 ，原因是： " + ex.ToString());
            }


        }

        private void fun(object device, object DS)
        {
            Device d = (Device)device;
            DataStream ds = (DataStream)DS;

            ds.RegisterNewBufferEvent(BGAPI2.Events.EventMode.EVENT_HANDLER);
            ds.NewBufferEvent += new BGAPI2.Events.DataStreamEventControl.NewBufferEventHandler(mDataStream_NewBufferEvent);

            ds.StartAcquisition();
            d.RemoteNodeList["AcquisitionStart"].Execute();
        }
        

        public void setDeleglte(getImageInfor deleCallback) {

            getImage = new getImageInfor(deleCallback);
        
        }
        
        public void startDetect() 
        {

            mDataStream.StartAcquisition();
            _device.RemoteNodeList["AcquisitionStart"].Execute();

  
        }

        /// <summary>
        /// 设置触发模式
        /// </summary>
        /// <param name="emode"></param>
        internal void setTriggerMode(ETRIGGERMODE emode)
        {
            try
            {
                if (emode == ETRIGGERMODE.SOFTWARE)
                {
                    _device.RemoteNodeList["TriggerSource"].Value = "Software";  //"SoftwareTrigger";
                    _device.RemoteNodeList["TriggerMode"].Value = "On";
                }
                else if (emode == ETRIGGERMODE.HARDWARE)
                {
                    _device.RemoteNodeList["TriggerSource"].Value = "Line0";
                    _device.RemoteNodeList["TriggerMode"].Value = "On";
                }
                else if (emode == ETRIGGERMODE.CONTINUE)
                {
                    _device.RemoteNodeList["TriggerMode"].Value = "Off";
                }
            }
            catch(Exception ex)
            {
            }
        }

        /// <summary>
        /// 软触发
        /// </summary>
        internal void softwareTrigger()
        {
            if (_device == null)
            {
                return;
            }
            try
            {
                _device.RemoteNodeList["TriggerSoftware"].Execute();
            }
            catch (Exception ex)
            {

            }
        }


        private event getImageInfor getImage;
        private int _value;
        private string _descript;
        private Device _device;
        private BX_ImageInfo imageInfo;
        private BGAPI2.DataStreamList datastreamList;
        private BGAPI2.DataStream mDataStream;
        private BGAPI2.BufferList bufferList;
        private BGAPI2.Buffer mBuffer;
       // InfoOut.InfoOut_TriggerControl infolog1 = new InfoOut.InfoOut_TriggerControl();

        int a1 = 0;
        int a2 = 0;
        int a3 = 0;

        public RangleValue BX_getNodeRange(string nodeName)
        {

            RangleValue ret = new RangleValue();
            if (_device != null)
            {
                try
                {  
                    ////double dcurrent = (double)_device.RemoteNodeList[nodeName].Value;
                    ////double dmin = (double)_device.RemoteNodeList[nodeName].Min;
                    ////double dmax = (double)_device.RemoteNodeList[nodeName].Max;
                    ////double dinc = (double)_device.RemoteNodeList[nodeName].Inc;
 
                    ret.value = _device.RemoteNodeList[nodeName].Value.ToString();
                    ret.min = _device.RemoteNodeList[nodeName].Min.ToString();
                    ret.max = _device.RemoteNodeList[nodeName].Max.ToString();
                    ret.inc = _device.RemoteNodeList[nodeName].Inc.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return ret;
        }

        public bool BX_SetNodeValue(string nodeName, object value) {


            if (_device != null)

            {
                string fExposureTimeMin =_device.RemoteNodeList[nodeName].Min.ToString();
                string fExposureTimeMax = _device.RemoteNodeList[nodeName].Max.ToString();

                try
                {



                    _device.RemoteNodeList[nodeName].Value = value;
                    return true;
                    
                    
                }
                catch (Exception e)
                {

                    MessageBox.Show("属性区间在 " + fExposureTimeMin + " 到 " + fExposureTimeMax + " 之间");
                }
            }
            else
            {

                MessageBox.Show("mDevice is null ");
            }


            return false;
        }

     
        public void BX_Stop() {

            if (_device.RemoteNodeList.GetNodePresent("AcquisitionAbort") == true)
            {
                _device.RemoteNodeList["AcquisitionAbort"].Execute();
               
            }
            _device.RemoteNodeList["AcquisitionStop"].Execute();
            mDataStream.StopAcquisition();
            


            
        }
        public void BX_Close() {

            try
            {
                bufferList.DiscardAllBuffers();
                while (bufferList.Count > 0)
                {
                    mBuffer = (BGAPI2.Buffer)bufferList.Values.First();
                    bufferList.RevokeBuffer(mBuffer);
                }

                mDataStream.NewBufferEvent -= new BGAPI2.Events.DataStreamEventControl.NewBufferEventHandler(mDataStream_NewBufferEvent);
              //  mDataStream.UnregisterNewBufferEvent();
                mDataStream.Close();
               // _device.Close();
            }
            catch (Exception e) {

                MessageBox.Show("error:= " + e.ToString());
            }
        }


    }
}
