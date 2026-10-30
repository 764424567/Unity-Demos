using System;
using System.Security.Cryptography;
using System.Text;

namespace AssemblyCSharp
{
    public class Encryption
    {
        //构造函数
        public Encryption()
        {

        }

        //内容加密
        public string encryptionContent(string ContentInfo, string strkey)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(strkey);
            RijndaelManaged encryption = new RijndaelManaged();
            encryption.Key = keyArray;
            encryption.Mode = CipherMode.ECB;
            encryption.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = encryption.CreateEncryptor();
            byte[] _EncryptArray = UTF8Encoding.UTF8.GetBytes(ContentInfo);
            byte[] resultArray = cTransform.TransformFinalBlock(_EncryptArray, 0, _EncryptArray.Length);
            return System.Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        //内容解密
        public string decipheringContent(string encryptionContent, string strkey)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(strkey);
            RijndaelManaged decipher = new RijndaelManaged();
            decipher.Key = keyArray;
            decipher.Mode = CipherMode.ECB;
            decipher.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = decipher.CreateDecryptor();
            byte[] _EncryptArray = System.Convert.FromBase64String(encryptionContent);
            byte[] resultArray = cTransform.TransformFinalBlock(_EncryptArray, 0, _EncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}

