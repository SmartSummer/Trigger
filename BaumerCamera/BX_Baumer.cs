using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX_BaumerMutileCamera.BX_Baumer
{
    public class BX_Baumer
    {
        public bool isOpen { get; set; }
        public void initSystem()
        {
            try
            {
                systemList = BGAPI2.SystemList.Instance;
                systemList.Refresh();

                mDeviceList = new List<ManagerDevice>();

                if (systemList.Count > 0)
                {
                          
                    foreach (KeyValuePair<string, BGAPI2.System> dst_pair in systemList)
                    {

                        string sSystemID = dst_pair.Key;


                        mSystem = systemList[sSystemID];
                        mSystem.Open();

                        interfaceList = mSystem.Interfaces;
                        interfaceList.Refresh(100);
                        //  MessageBox.Show("interfaceList.Count" + interfaceList.Count);
                        if (interfaceList.Count > 0)
                        {
                            foreach (KeyValuePair<string, BGAPI2.Interface> dst_pairI in interfaceList)
                            {
                                string sInterfaceID = dst_pairI.Key;

                                // MessageBox.Show("interface");
                                mInterface = interfaceList[sInterfaceID];
                                mInterface.Open();
                                deviceList = mInterface.Devices;
                                deviceList.Refresh(100);


                                // MessageBox.Show("deviceList.Count" + deviceList.Count);
                                if (deviceList.Count > 0)
                                {

                                    FlagOpenArray = new int[deviceList.Count];

                                    foreach (KeyValuePair<string, BGAPI2.Device> dst_pairD in deviceList)
                                    {
                                       string sDeviceID = dst_pairD.Key;
                                        //   MessageBox.Show("initdevice");
                                       BGAPI2.Device tDevice = deviceList[sDeviceID];
                                        tDevice.Open();
                                        tDevice.RemoteNodeList["TriggerMode"].Value = "Off";
                                        int value = (int)((long)(tDevice.RemoteNodeList["GevCurrentIPAddress"].Value) & 0x000000ff);

                                        ManagerDevice md = new ManagerDevice();

                                        md.setDeviceDesct(ref tDevice, ref value);

                                        mDeviceList.Add(md);
                                        //IndexT = 0;

                                    }
                                }
                            }
                        }

                    }

                }

            }
            catch (Exception e)
            {


            }
        }

        public RangleValue GetRangleValue(string NodeName,int index)
        {

            RangleValue rv = new RangleValue();

            if (index < mDeviceList.Count)
            {
                rv = mDeviceList[index].BX_getNodeRange(NodeName);
            }
            return rv;
        }

        public bool SetNodeValue(string NodeName, int index,object Value)
        {

           

            if (index < mDeviceList.Count)
            {
               return mDeviceList[index].BX_SetNodeValue(NodeName, Value);
            }
            return false;
        }

        public void Stop(int index) {

            mDeviceList[index].BX_Stop();
            FlagOpenArray[index] = -1;
        }
        public void Close(int index) {

            mDeviceList[index].BX_Close();
        }



        #region 私有变量
        private BGAPI2.SystemList systemList;
        private BGAPI2.System mSystem;
        private BGAPI2.InterfaceList interfaceList;
        private BGAPI2.Interface mInterface;
        private BGAPI2.DeviceList deviceList;
        public List<ManagerDevice> mDeviceList;
        public int[] FlagOpenArray;
        #endregion

    }
}
