/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：StringAndZip
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：解压缩 加解密工具类
******************************************************************************/

using System;
using System.IO;
using System.IO.Compression;

public static class StringAndZip
{
    /// <summary>
    /// 字符串压缩
    /// </summary>
    /// <param name="rawString">需要压缩的字符串</param>
    /// <returns>压缩后的字符串</returns>
    public static string StringToZip(string rawString)
    {
        if (string.IsNullOrEmpty(rawString) || rawString.Length == 0)
        {
            return "";
        }
        else
        {
            byte[] rawData = System.Text.Encoding.UTF8.GetBytes(rawString.ToString());
            byte[] zippedData = Compress(rawData);
            return (string)(Convert.ToBase64String(zippedData));
        }
    }

    /// <summary>
    /// 字符串解压
    /// </summary>
    /// <param name="zippedString">压缩后的字符串</param>
    /// <returns>原始未压缩字符串</returns>
    public static string ZipToString(string zippedString)
    {
        if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
        {
            return "";
        }
        else
        {
            byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
            return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
        }
    }

    /// <summary>
    /// 压缩
    /// </summary>
    /// <param name="rawData"></param>
    /// <returns></returns>
    private static byte[] Compress(byte[] rawData)
    {
        MemoryStream ms = new MemoryStream();
        GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
        compressedzipStream.Write(rawData, 0, rawData.Length);
        compressedzipStream.Close();
        return ms.ToArray();
    }

    /// <summary>
    /// 解压
    /// </summary>
    /// <param name="zippedData"></param>
    /// <returns></returns>
    private static byte[] Decompress(byte[] zippedData)
    {
        MemoryStream ms = new MemoryStream(zippedData);
        GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
        MemoryStream outBuffer = new MemoryStream();
        byte[] block = new byte[1024];
        while (true)
        {
            int bytesRead = compressedzipStream.Read(block, 0, block.Length);
            if (bytesRead <= 0)
                break;
            else
                outBuffer.Write(block, 0, bytesRead);
        }
        compressedzipStream.Close();
        return outBuffer.ToArray();
    }
}
