using Microsoft.Win32;
using System.Collections;
using UnityEngine;

public class Encript4 : MonoBehaviour
{
    public GameObject m_PanelEncrypted;
    string md5 = "";

    void Start()
    {
        StartCoroutine(GetData());
        //验证本地的加密字符串是否正确
        Verification_MD5(md5);
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

    public IEnumerator GetData()
    {
        WWW www = new WWW("http://127.0.0.1/Test.php?md5="+SystemInfo.deviceUniqueIdentifier);
        yield return www;
        if (www.error != null)
        {
            yield return null;
        }
        else
        {
            md5 = www.text;
        }
    }
}