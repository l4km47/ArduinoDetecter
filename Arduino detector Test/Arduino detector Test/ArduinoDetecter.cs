using System;
using System.Management;

namespace DetectA_U
{
    public static class ArduinoDetecter
    {
        public static string detectAUport()
        {
            ManagementScope scope = new ManagementScope();
            SelectQuery query = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(scope, query);
            string result;
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        string text = managementObject["Description"].ToString();
                        string text2 = managementObject["DeviceID"].ToString();
                        if (text.Contains("Arduino"))
                        {
                            result = text + " (" + text2 + ")";
                            return result;
                        }
                    }
                }
            }
            catch (ManagementException var_6_A1)
            {
            }
            result = null;
            return result;
        }
    }
}
