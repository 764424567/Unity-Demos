using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Encript3 : MonoBehaviour
{
    public GameObject m_PanelEncrypted;

    void Start()
    {
        string s2 = GetMD5String(SystemInfo.deviceUniqueIdentifier);
        //验证本地的加密字符串是否正确
        Verification_MD5(s2);
    }

    //验证本地的md5正确与否
    public void Verification_MD5(string ValidateMD5)
    {
        RegistryKey RootKey, RegKey;
        RootKey = Registry.CurrentUser.OpenSubKey("UserSetting", true);
        //打开子项：HKEY_CURRENT_USER\UserSetting\Encrypted
        if ((RegKey = RootKey.OpenSubKey("Encrypted", true)) == null)//如果文件不存在，就显示要激活的界面
        {
            m_PanelEncrypted.SetActive(true);
        }
        //异常捕捉，如果出现程序异常，比如闪退
        try
        {
            object encrypted = RegKey.GetValue("EncryptedString");        //读取键值
            if (encrypted.ToString() == ValidateMD5)
            {
                m_PanelEncrypted.SetActive(false);
            }
            else
            {
                m_PanelEncrypted.SetActive(true);
            }
        }
        catch
        {
            print("异常状况");
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

    //激活程序
    public void Activation()
    {
        string md5 = GetMD5String(SystemInfo.deviceUniqueIdentifier);
        // 创建键值对
        RegistryKey RootKey, RegKeyRoot,RegKey;
        //项名为：HKEY_CURRENT_USER
        RootKey = Registry.CurrentUser;
        if ((RegKeyRoot = RootKey.OpenSubKey("UserSetting",true))== null)
        {
            RootKey.CreateSubKey("UserSetting");
            RegKeyRoot = RootKey.OpenSubKey("UserSetting", true);
        }
        //打开子项：HKEY_CURRENT_USER\Software\TestToControlUseTime
        if ((RegKey = RegKeyRoot.OpenSubKey("Encrypted", true)) == null)
        {
            RegKeyRoot.CreateSubKey("Encrypted");               //不存在，则创建子项
            RegKey = RegKeyRoot.OpenSubKey("Encrypted", true);  //打开键值
            RegKey.SetValue("EncryptedString", (object)md5);         //创建键值
            return;
        }
        else
        {
            RegKey.SetValue("EncryptedString", (object)md5);
            return;
        }
    }
}