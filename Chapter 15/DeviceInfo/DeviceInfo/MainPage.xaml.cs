using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;

namespace DeviceInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGetDeviceInfo_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            strMsg += GetDeviceInfo("DeviceManufacturer");
            strMsg += GetDeviceInfo("DeviceName");
            strMsg += GetDeviceInfo("DeviceFirmwareVersion");
            strMsg += GetDeviceInfo("DeviceHardwareVersion");
            strMsg += GetDeviceInfo("DeviceTotalMemory");
            strMsg += GetDeviceInfo("DeviceManufacturer");
            strMsg += GetDeviceInfo("ApplicationCurrentMemoryUsage");
            strMsg += GetDeviceInfo("ApplicationPeakMemoryUsage");

            txtDeviceInfo.Text = strMsg;
        }

        private string GetDeviceInfo(string strPropertyName)
        {
            string strValue;
            strValue = strPropertyName + " : ";
            strValue += DeviceExtendedProperties.GetValue(strPropertyName).ToString();
            strValue += "\n";
            return strValue;
        }
    }
}