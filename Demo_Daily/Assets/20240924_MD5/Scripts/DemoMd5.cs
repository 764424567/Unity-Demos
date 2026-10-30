using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DemoMd5 : MonoBehaviour
{
    void Start()
    {
        string str = "123456";
        Debug.Log(Encrypt_MD5(str,true,true));

        string enStr = "YOUR_ENCRYPTED_TOKEN_PAYLOAD";
        Debug.Log(Encrypt_Token(enStr));
    }

    //解析Token
    public string Encrypt_Token(string msg, string key = "waterHammer")
    {
        msg = "";
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-=+";
        char ch = msg[0];
        int nh = chars.IndexOf(ch);
        string mdKey = Encrypt_MD5(key + ch);
        mdKey = mdKey.Substring(nh % 8, nh % 8 + 7);
        msg = msg.Substring(1);
        string temp = "";
        int j = 0;
        int k = 0;
        for (int i = 0; i < msg.Length; i++)
        {
            k = k == mdKey.Length ? 0 : k;
            j = chars.IndexOf(msg[i]) - nh - (int)(mdKey[k++]);
            while (j < 0)
            {
                j += 64;
            }
            temp += chars[j];
        }
        return (Encoding.Default.GetString(Convert.FromBase64String(temp)));
    }

    //MD5解密
    public string Encrypt_MD5(string _encryptContent)
    {
        string content_Normal = _encryptContent;
        string content_Encrypt = "";
        MD5 md5 = MD5.Create();

        byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(content_Normal));

        for (int i = 0; i < s.Length; i++)
        {
            content_Encrypt = content_Encrypt + s[i].ToString("x2");
        }
        return content_Encrypt;
    }

    /// <summary>
    /// 返回MD5加密字符串
    /// </summary>
    /// <param name="_hash">加密串</param>
    /// <param name="isHex">是否是16进制</param>
    /// <param name="isUpper">是否大写</param>
    /// <returns></returns>
    public string Encrypt_MD5(string _hash, bool isHex, bool isUpper = true)
    {
        if (isHex)
        {
            MD5 md5 = MD5.Create();
            byte[] t = md5.ComputeHash(Encoding.UTF8.GetBytes(_hash));
            string t2 = BitConverter.ToString(t, 4, 8);
            t2 = t2.Replace("-", "");
            if (isUpper)
            {
                t2 = t2.ToUpper();
            }
            else
            {
                t2 = t2.ToLower();
            }
            return t2;
        }
        else
        {
            MD5 md5 = MD5.Create();
            byte[] t = md5.ComputeHash(Encoding.UTF8.GetBytes(_hash));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < t.Length; i++)
            {
                stringBuilder.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            string t2 = stringBuilder.ToString();
            if (isUpper)
            {
                t2 = t2.ToUpper();
            }
            else
            {
                t2 = t2.ToLower();
            }
            return t2;
        }
    }
}