using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/// <summary>
/// 语音工具
/// </summary>
public static class Speech
{
    #region iFlytek

    /* APPID 于讯飞开发者控制台创建应用申请所得 */
    const string mAppID = "appid = 5cce98d3";

    /// <summary>
    /// 科大讯飞语音识别
    /// </summary>
    /// <param name="clipBuffer">音频数据</param>
    /// <returns>识别后的字符串结果</returns>
    public static string Asr(byte[] clipBuffer)
    {
        /* 首先调用登录接口
         * 登录成功返回0,否则为错误代码 */
        int res = MSCDLL.MSPLogin(null, null, mAppID);
        if (res != 0)
        {
            Debug.Log($"login failed. error code: {res}");
            return null;
        }

        /* 调用开启一次语音识别的接口
         * 接收返回的句柄,后续调用写入音频、获取结果等接口需要使用
         * 调用成功error code为0,否则为错误代码 
         * 备注:
         *  第二个参数为 开始一次语音识别的参数列表 可以再进行具体的封装
         *  例如 language参数 封装枚举 switch中文 为zh_cn    switch英文 为en_us
         *  具体参照科大讯飞官网SDK文档 */
        IntPtr sessionID = MSCDLL.QISRSessionBegin(null,
            "sub=iat,domain=iat,language=zh_cn,accent=mandarin,sample_rate=16000,result_type=plain,result_encoding= utf-8", ref res);
        if (res != 0)
        {
            Debug.Log($"begin failed. error code: {res}");
            OnErrorEvent();
            return null;
        }

        /* 用于记录端点状态 */
        EpStatus epStatus = EpStatus.MSP_EP_LOOKING_FOR_SPEECH;
        /* 用于记录识别状态 */
        RecogStatus recognizeStatus = RecogStatus.MSP_REC_STATUS_SUCCESS;

        /* 调用音频写入接口 将需要识别的音频数据传入
         * 写入成功返回0,否则为错误代码 */
        res = MSCDLL.QISRAudioWrite(sessionID, clipBuffer, (uint)clipBuffer.Length, AudioStatus.MSP_AUDIO_SAMPLE_CONTINUE, ref epStatus, ref recognizeStatus);
        if (res != 0)
        {
            Debug.Log($"write failed. error code: {res}");
            MSCDLL.QISRSessionEnd(sessionID, "error");
            OnErrorEvent();
            return null;
        }
        res = MSCDLL.QISRAudioWrite(sessionID, null, 0, AudioStatus.MSP_AUDIO_SAMPLE_LAST, ref epStatus, ref recognizeStatus);
        if (res != 0)
        {
            Debug.Log($"write failed. error code: {res}");
            MSCDLL.QISRSessionEnd(sessionID, "error");
            OnErrorEvent();
            return null;
        }

        /* 用于存储识别结果 */
        StringBuilder sb = new StringBuilder();
        /* 用于累加识别结果的长度 */
        int length = 0;

        /* 音频写入后 反复调用获取识别结果的接口直到获取完毕 */
        while (recognizeStatus != RecogStatus.MSP_REC_STATUS_COMPLETE)
        {
            IntPtr curtRslt = MSCDLL.QISRGetResult(sessionID, ref recognizeStatus, 0, ref res);
            if (res != 0)
            {
                Debug.Log($"get result failed. error code: {res}");
                MSCDLL.QISRSessionEnd(sessionID, "error");
                OnErrorEvent();
                return null;
            }
            /* 当前部分识别结果不为空 将其存入sb*/
            if (null != curtRslt)
            {
                length += curtRslt.ToString().Length;
                if (length > 4096)
                {
                    Debug.Log($"size not enough: {length} > 4096");
                    MSCDLL.QISRSessionEnd(sessionID, "error");
                    OnErrorEvent();
                    return sb.ToString();
                }
                sb.Append(Marshal.PtrToStringAnsi(curtRslt));
            }
            Thread.Sleep(150);
        }

        /* 获取完全部识别结果后 结束本次语音识别 */
        res = MSCDLL.QISRSessionEnd(sessionID, "ao li gei !");
        if (res != 0) Debug.Log($"end failed. error code: {res}");

        /* 最终退出登录 返回识别结果*/
        res = MSCDLL.MSPLogout();
        if (res != 0) Debug.Log($"logout failed. error code {res}");
        return sb.ToString();
    }
    /// <summary>
    /// 科大讯飞语音识别
    /// </summary>
    /// <param name="path">音频文件所在路径</param>
    /// <returns>识别后的字符串结果</returns>
    public static string Asr(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("path can not be null.");
            return null;
        }
        byte[] clipBuffer;
        try
        {
            clipBuffer = File.ReadAllBytes(path);
        }
        catch (Exception e)
        {
            Debug.Log($"exception: {e.Message}");
            return null;
        }
        return Asr(clipBuffer);
    }
    /// <summary>
    /// 科大讯飞语音识别
    /// </summary>
    /// <param name="clip">需要识别的AudioClip</param>
    /// <returns>识别后的字符串结果</returns>
    public static string Asr(AudioClip clip)
    {
        byte[] clipBuffer = clip.Convert2PCM16();
        return Asr(clipBuffer);
    }

    /// <summary>
    /// 科大讯飞语音合成
    /// </summary>
    /// <param name="content">需要合成音频的文本内容</param>
    /// <returns>合成后的音频</returns>
    public static AudioClip Tts(string content, TtsVoice voice = TtsVoice.XuJiu)
    {
        /* 首先调用登录接口
         * 登录成功返回0,否则为错误代码 */
        int res = MSCDLL.MSPLogin(null, null, mAppID);
        if (res != 0)
        {
            Debug.Log($"login failed. error code: {res}");
            return null;
        }

        /* 调用开启一次语音合成的接口
         * 接收返回后的句柄,后续调用写入文本等接口需要使用
         * 调用成功error code为0,否则为错误代码
         * 备注:
         *  第一个参数为 开启一次语音合成的参数列表
         *  具体参照科大讯飞官网SDK文档 */
        string voicer = "";
        switch (voice)
        {
            case TtsVoice.XiaoYan:
                voicer = "xiaoyan";
                break;
            case TtsVoice.XuJiu:
                voicer = "aisjiuxu";
                break;
            case TtsVoice.XiaoPing:
                voicer = "aisxping";
                break;
            case TtsVoice.XiaoJing:
                voicer = "aisjinger";
                break;
            case TtsVoice.XuXiaoBao:
                voicer = "aisbabyxu";
                break;
            default:
                break;
        }
        IntPtr sessionID = MSCDLL.QTTSSessionBegin($"engine_type = cloud, voice_name = {voicer}, text_encoding = utf8, sample_rate = 16000", ref res);
        if (res != 0)
        {
            Debug.Log($"begin failed. error code: {res}");
            OnErrorEvent();
            return null;
        }

        /* 调用写入文本的接口 将需要合成内容传入
         * 调用成功返回0,否则为错误代码 */
        res = MSCDLL.QTTSTextPut(sessionID, content, (uint)Encoding.UTF8.GetByteCount(content), string.Empty);
        if (res != 0)
        {
            Debug.Log($"put text failed. error code: {res}");
            OnErrorEvent();
            return null;
        }

        /* 用于记录长度 */
        uint audioLength = 0;
        /* 用于记录合成状态 */
        SynthStatus synthStatus = SynthStatus.MSP_TTS_FLAG_STILL_HAVE_DATA;

        List<byte[]> bytesList = new List<byte[]>();

        /* 文本写入后 调用获取合成音频的接口
         * 获取成功error code为0,否则为错误代码
         * 需反复调用 直到合成状态为结束 或出现错误代码 */
        try
        {
            while (true)
            {
                IntPtr intPtr = MSCDLL.QTTSAudioGet(sessionID, ref audioLength, ref synthStatus, ref res);
                byte[] byteArray = new byte[(int)audioLength];
                if (audioLength > 0) Marshal.Copy(intPtr, byteArray, 0, (int)audioLength);

                bytesList.Add(byteArray);

                Thread.Sleep(150);
                if (synthStatus == SynthStatus.MSP_TTS_FLAG_DATA_END || res != 0)
                    break;
            }
        }
        catch (Exception e)
        {
            OnErrorEvent();
            Debug.Log($"error: {e.Message}");
            return null;
        }

        int size = 0;
        for (int i = 0; i < bytesList.Count; i++)
        {
            size += bytesList[i].Length;
        }

        var header = GetWaveHeader(size);
        byte[] array = header.Convert2Bytes();
        bytesList.Insert(0, array);
        size += array.Length;

        byte[] bytes = new byte[size];

        size = 0;
        for (int i = 0; i < bytesList.Count; i++)
        {
            bytesList[i].CopyTo(bytes, size);
            size += bytesList[i].Length;
        }
        AudioClip clip = bytes.Convert2Wav();


        res = MSCDLL.QTTSSessionEnd(sessionID, "ao li gei !");
        if (res != 0)
        {
            Debug.Log($"end failed. error code: {res}");
            OnErrorEvent();
            return clip;
        }

        res = MSCDLL.MSPLogout();
        if (res != 0)
        {
            Debug.Log($"logout failed. error code: {res}");
            return clip;
        }
        return clip;
    }
    /// <summary>
    /// 科大讯飞语音合成
    /// </summary>
    /// <param name="content">需要合成的内容</param>
    /// <param name="path">将合成后的音频写入指定的路径</param>
    /// <returns>调用成功返回true 发生异常返回false</returns>
    public static bool Tts(string content, string path)
    {
        /* 首先调用登录接口
         * 登录成功返回0,否则为错误代码 */
        int res = MSCDLL.MSPLogin(null, null, mAppID);
        if (res != 0)
        {
            Debug.Log($"login failed. error code: {res}");
            return false;
        }

        /* 调用开启一次语音合成的接口
         * 接收返回后的句柄,后续调用写入文本等接口需要使用
         * 调用成功error code为0,否则为错误代码
         * 备注:
         *  第一个参数为 开启一次语音合成的参数列表
         *  具体参照科大讯飞官网SDK文档 */
        IntPtr sessionID = MSCDLL.QTTSSessionBegin("engine_type = cloud, voice = xiaoyan, text_encoding = utf8, sample_rate = 16000", ref res);
        if (res != 0)
        {
            Debug.Log($"begin failed. error code: {res}");
            OnErrorEvent();
            return false;
        }

        /* 调用写入文本的接口 将需要合成内容传入
         * 调用成功返回0,否则为错误代码 */
        res = MSCDLL.QTTSTextPut(sessionID, content, (uint)Encoding.UTF8.GetByteCount(content), string.Empty);
        if (res != 0)
        {
            Debug.Log($"put text failed. error code: {res}");
            OnErrorEvent();
            return false;
        }

        /* 用于记录长度 */
        uint audioLength = 0;
        /* 用于记录合成状态 */
        SynthStatus synthStatus = SynthStatus.MSP_TTS_FLAG_STILL_HAVE_DATA;
        /* 开启一个流 */
        MemoryStream ms = new MemoryStream();
        ms.Write(new byte[44], 0, 44);


        /* 文本写入后 调用获取合成音频的接口
         * 获取成功error code为0,否则为错误代码
         * 需反复调用 直到合成状态为结束 或出现错误代码 */
        try
        {
            while (true)
            {
                IntPtr intPtr = MSCDLL.QTTSAudioGet(sessionID, ref audioLength, ref synthStatus, ref res);
                byte[] byteArray = new byte[(int)audioLength];
                if (audioLength > 0) Marshal.Copy(intPtr, byteArray, 0, (int)audioLength);
                ms.Write(byteArray, 0, (int)audioLength);
                Thread.Sleep(150);
                if (synthStatus == SynthStatus.MSP_TTS_FLAG_DATA_END || res != 0)
                    break;
            }
        }
        catch (Exception e)
        {
            OnErrorEvent();
            Debug.Log($"error: {e.Message}");
            return false;
        }


        var header = GetWaveHeader((int)ms.Length);
        byte[] array = header.Convert2Bytes();
        ms.Position = 0L;
        ms.Write(array, 0, array.Length);
        ms.Position = 0L;

        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        ms.WriteTo(fs);
        ms.Close();
        fs.Close();

        res = MSCDLL.QTTSSessionEnd(sessionID, "ao li gei !");
        if (res != 0)
        {
            Debug.Log($"end failed. error code: {res}");
            OnErrorEvent();
            return false;
        }

        res = MSCDLL.MSPLogout();
        if (res != 0)
        {
            Debug.Log($"logout failed. error code: {res}");
            return false;
        }
        return true;
    }

    #region
    /* 发生异常后调用退出登录接口 */
    static void OnErrorEvent()
    {
        int res = MSCDLL.MSPLogout();
        if (res != 0)
        {
            Debug.Log($"logout failed. error code: {res}");
        }
    }

    /* 语音音频头 初始化赋值 */
    static WaveHeader GetWaveHeader(int dataLen)
    {
        return new WaveHeader
        {
            RIFFID = 1179011410,
            FileSize = dataLen - 8,
            RIFFType = 1163280727,
            FMTID = 544501094,
            FMTSize = 16,
            FMTTag = 1,
            FMTChannel = 1,
            FMTSamplesPerSec = 16000,
            AvgBytesPerSec = 32000,
            BlockAlign = 2,
            BitsPerSample = 16,
            DataID = 1635017060,
            DataSize = dataLen - 44
        };
    }
    #endregion

    #endregion
}