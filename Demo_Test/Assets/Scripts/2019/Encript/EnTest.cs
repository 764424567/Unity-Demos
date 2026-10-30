using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class EnTest
{
    /// <summary>
    /// 获取设备硬件码
    /// </summary>
    /// <returns></returns>
    public void Token()
    {
        string HDid = GetHDid();
        //string mac = GetMoAddress();
        //string cpu = GetCpuID();
        Debug.Log(HDid);
        //Debug.Log(mac);
        //Debug.Log(cpu);
        ////应该总有一个能获取到吧！！
        //if (HDid != null || cpu != null)
        //{
        //    string temp = HDid + cpu + mac;
        //    return GetMD5String(temp);
        //}
        //else
        //{
        //    return null;
        //}
    }


    public string GetCpuID()
    {
        try
        {
            //获取CPU序列号代码
            string cpuInfo = "";//cpu序列号
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            moc = null;
            mc = null;
            return cpuInfo;
        }
        catch
        {
            return "unknow";
        }
    }

    /// <summary>
    /// 获取硬盘ID  
    /// </summary>
    /// <returns></returns>
    public static string GetHDid()
    {
        try
        {
            //查询得到系统盘所在硬盘的ID = 0。然后我们通过该ID，查询该硬盘信息。
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT DiskIndex FROM Win32_DiskPartition WHERE Bootable = TRUE");
            foreach (ManagementObject mooo in searcher.Get())
            {
                int index = Convert.ToInt32(mooo.Properties["DiskIndex"].Value);
                ManagementObjectSearcher searcher_model = new ManagementObjectSearcher("SELECT Model FROM Win32_DiskDrive WHERE Index = " + index);
                ManagementObjectCollection moc1 = searcher_model.Get();
                foreach (ManagementObject mo in moc1)
                {
                    string modelname = (string)mo.Properties["Model"].Value;
                    return modelname;
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    ///   <summary> 
    ///   获取网卡硬件地址 
    ///   </summary> 
    ///   <returns> string </returns> 
    public string GetMoAddress()
    {
        try
        {
            string MoAddress = null;
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        MoAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                }
            }
            return MoAddress;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    /// <summary>
    /// 通过字符串获取MD5值，返回32位字符串。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetMD5String(string text)
    {
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(text));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString().ToLower();
    }
}