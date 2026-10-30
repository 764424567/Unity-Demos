using System;
using System.Runtime.InteropServices;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class MSCDLL
{
    #region msp_cmn.h 通用接口
    /// <summary>
    /// 初始化msc 用户登录  user login. 
    /// 使用其他接口前必须先调用MSPLogin,可以在应用程序启动时调用
    /// </summary>
    /// <param name="usr">user name. 此参数保留 传入NULL即可</param>
    /// <param name="pwd">password. 此参数保留 传入NULL即可</param>
    /// <param name="parameters">parameters when user login. 每个参数和参数值通过key=value的形式组成参数对,如果有多个参数对,再用逗号进行拼接</param>
    ///     通用 appid 应用ID: 于讯飞开放平台申请SDK成功后获取到的appid
    ///     离线 engine_start 离线引擎启动: 启用离线引擎 支持参数: ivw:唤醒 asr:识别
    ///     离线 [xxx]_res_path 离线引擎资源路径: 设置ivw asr引擎离线资源路径 
    ///             详细格式: fo|[path]|[offset]|[length]|xx|xx 
    ///             单个资源路径示例: ivw_res_path=fo|res/ivw/wakeupresource.jet
    ///             多个资源路径示例: asr_res_path=fo|res/asr/common.jet;fo|res/asr/sms.jet
    /// <returns>return 0 if sucess, otherwise return error code. 成功返回MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int MSPLogin(string usr, string pwd, string parameters);
    /// <summary>
    /// 退出登录  user logout.
    /// 本接口和MSPLogin配合使用 确保其他接口调用结束之后调用MSPLogout,否则结果不可预期
    /// </summary>
    /// <returns>如果函数调用成功返回MSP_SUCCESS,否则返回错误代码 return 0 if sucess, otherwise return error code.</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int MSPLogout();
    /// <summary>
    /// 用户数据上传  upload data such as user config, custom grammar, etc. 
    /// </summary>
    /// <param name="dataName">数据名称字符串  should be unique to diff other data.</param>
    /// <param name="data">待上传数据缓冲区的起始地址  the data buffer pointer, data could be binary.</param>
    /// <param name="dataLen">数据长度(如果是字符串,则不包含'\0')  length of data.</param>
    /// <param name="_params">parameters about uploading data.</param>
    ///     在线 sub = uup,dtt = userword 上传用户词表
    ///     在线 sub = uup,dtt = contact 上传联系人
    /// <param name="errorCode">return 0 if success, otherwise return error code.</param>
    /// <returns>data id returned by server, used for special command.</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr MSPUploadData(string dataName, IntPtr data, uint dataLen, string _params, ref int errorCode);
    /// <summary>
    /// write data to msc, such as data to be uploaded, searching text, etc.
    /// </summary>
    /// <param name="data">the data buffer pointer, data could be binary.</param>
    /// <param name="dataLen">length of data.</param>
    /// <param name="dataStatus">data status, 2: first or continuous, 4: last.</param>
    /// <returns>return 0 if success, otherwise return error code.</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int MSPAppendData(IntPtr data, uint dataLen, uint dataStatus);
    /// <summary>
    /// download data such as user config, etc.
    /// </summary>
    /// <param name="_params">parameters about data to be downloaded.</param>
    /// <param name="dataLen">length of received data.</param>
    /// <param name="errorCode">return 0 if success, otherwise return error code.</param>
    /// <returns>received data buffer pointer, data could be binary, null if failed or data does not exsit.</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr MSPDownloadData(string _params, ref uint dataLen, ref int errorCode);
    /// <summary>
    /// set param of msc.  参数设置接口、离线引擎初始化接口 
    /// </summary>
    /// <param name="paramName">param name.</param>
    ///     离线 engine_start   启动离线引擎
    ///     离线 engine_destroy 销毁离线引擎
    /// <param name="paramValue">param value. 参数值</param>
    /// <returns>return 0 if success, otherwise return errcode. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int MSPSetParam(string paramName, string paramValue);
    /// <summary>
    /// get param of msc.  获取msc的设置信息
    /// </summary>
    /// <param name="paramName">param name. 参数名,一次调用只支持查询一个参数</param>
    ///     在线 upflow   上行数据量
    ///     在线 downflow 下行数据量
    /// <param name="paramValue">param value.</param>
    ///     输入: buffer首地址
    ///     输出: 向该buffer写入获取到的信息
    /// <param name="valueLen">param value (buffer) length.</param>
    ///     输入: buffer的大小
    ///     输出: 信息实际长度(不含'\0')
    /// <returns>return 0 if success, otherwise return errcode. 函数调用成功返回MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int MSPGetParam(string paramName, ref byte[] paramValue, ref uint valueLen);
    /// <summary>
    /// get version of msc or local engine. 获取msc或本地引擎版本信息
    /// </summary>
    /// <param name="verName">version name, could be "msc", "aitalk", "aisound", "ivw". 参数名,一次调用只支持查询一个参数</param>
    ///     离线 ver_msc msc版本号
    ///     离线 ver_asr 离线识别版本号,目前不支持
    ///     离线 ver_tts 离线合成版本号
    ///     离线 ver_ivw 离线唤醒版本号
    /// <param name="errorCode">return 0 if success, otherwise return error code. 如果函数调用成功返回MSP_SUCCESS,否则返回错误代码</param>
    /// <returns>return version value if success, null if fail.  成功返回缓冲区指针,失败或数据不存在返回NULL</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr MSPGetVersion(string verName, ref int errorCode);
    #endregion

    #region qisr.h 语音识别
    /// <summary>
    /// create a recognizer session to recognize audio data. 开始一次语音识别
    /// </summary>
    /// <param name="grammarList">garmmars list, inline grammar support only one. 此参数保留,传入NULL即可</param>
    /// <param name="_params">parameters when the session created.</param>
    ///     通用  engine_type     引擎类型                      cloud在线引擎 local离线引擎
    ///     在线  sub             本次识别请求的类型            iat语音听写 asr命令词识别
    ///     在线  language        语言                          zh_cn简体中文 en_us英文
    ///     在线  domain          领域                          iat语音听写
    ///     在线  accent          语言区域                      mandarin普通话
    ///     通用  sample_rate     音频采样率                    16000 8000
    ///     通用  asr_threshold   识别门限                      离线语法识别结果门限值,设置只返回置信度得分大于此门限值的结果 0-100
    ///     离线  asr_denoise     是否开启降噪功能              0不开启 1开启
    ///     离线  asr_res_path    离线识别资源路径              离线识别资源所在路径
    ///     离线  grm_build_path  离线语法生成路径              构建离线语法所生成数据的保存路径(文件夹)
    ///     通用  result_type     结果格式                      plain json
    ///     通用  text_encoding   文本编码格式                  表示参数中携带的文本编码格式
    ///     离线  local_grammar   离线语法id                    构建离线语法后获得的语法ID
    ///     通用  ptt             添加标点符号(sub=iat时有效)   0:无标点符号;1:有标点符号
    ///     在线  aue             音频编码格式和压缩等级        编码算法:raw;speex;speex-wb;ico 编码等级: raw不进行压缩 speex系列0-10
    ///     通用  result_encoding 识别结果字符串所用编码格式    plain:UTF-8,GB2312 json:UTF-8
    ///     通用  vad_enable      VAD功能开关                   是否启用VAD 默认为开启VAD 0(或false)为关闭
    ///     通用  vad_bos         允许头部静音的最长时间        目前未开启该功能
    ///     通用  vad_eos         允许尾部静音的最长时间        0-10000毫秒 默认为2000
    /// <param name="errorCode">return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</param>
    /// <returns>return session id of current session, null is failed. 函数调用成功返回字符串格式的sessionID,失败返回NULL sessionID是本次识别的句柄</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr QISRSessionBegin(string grammarList, string _params, ref int errorCode);
    /// <summary>
    /// writing binary audio data to recognizer. 写入本次识别的音频
    /// </summary>
    /// <param name="sessionID">the session id returned by recog_begin. 由QISRSessionBegin返回的句柄</param>
    /// <param name="waveData">binary data of waveform. 音频数据缓冲区起始地址</param>
    /// <param name="waveLen">waveform data size in bytes. 音频数据长度,单位字节</param>
    /// <param name="audioStatus">audio status. 用来告知msc音频发送是否完成</param>
    /// <param name="epStatus">ep status. 端点检测(End-point detected)器所处的状态</param>
    /// <param name="recogStatus">recognition status. 识别器返回的状态,提醒用户及时开始\停止获取识别结果</param>
    ///     本接口需不断调用,直到音频全部写入为止 上传音频时,需更新audioStatus的值 具体来说:
    ///         当写入首块音频时,将audioStatus置为MSP_AUDIO_SAMPLE_FIRST
    ///         当写入最后一块音频时,将audioStatus置为MSP_AUDIO_SAMPLE_LAST
    ///         其余情况下,将audioStatus置为MSP_AUDIO_SAMPLE_CONTINUE
    ///     同时,需定时检查两个变量: epStatus和recogStatus 具体来说:
    ///         当epStatus显示已检测到后端点时,MSC已不再接收音频,应及时停止音频写入
    ///         当rsltStatus显示有识别结果返回时,即可从MSC缓存中获取结果
    /// <returns>return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QISRAudioWrite(IntPtr sessionID, byte[] waveData, uint waveLen, AudioStatus audioStatus, ref EpStatus epStatus, ref RecogStatus recogStatus);
    /// <summary>
    /// get recognize result in specified format. 获取识别结果
    /// </summary>
    /// <param name="sessionID">session id returned by session begin. 由QISRSessionBegin返回的句柄</param>
    /// <param name="rsltStatus">status of recognition result, 识别结果的状态,其取值范围和含义请参考QISRAudioWrite 的参数recogStatus</param>
    /// <param name="waitTime">此参数做保留用</param>
    /// <param name="errorCode">return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</param>
    /// 当写入音频过程中已经有部分识别结果返回时,可以获取结果
    /// 在音频写入完毕后,用户需反复调用此接口,直到识别结果获取完毕(rlstStatus值为5)或返回错误码 
    /// 注意:如果某次成功调用后暂未获得识别结果,请将当前线程sleep一段时间,以防频繁调用浪费CPU资源
    /// <returns>return 0 if success, otherwise return error code. 函数执行成功且有识别结果时,返回结果字符串指针 其他情况(失败或无结果)返回NULL</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr QISRGetResult(IntPtr sessionID, ref RecogStatus rsltStatus, int waitTime, ref int errorCode);
    /// <summary>
    /// end the recognizer session, release all resource. 结束本次语音识别
    /// 本接口和QISRSessionBegin对应,调用此接口后,该句柄对应的相关资源(参数、语法、音频、实例等)都会被释放,用户不应再使用该句柄
    /// </summary>
    /// <param name="sessionID">session id string to end. 由QISRSessionBegin返回的句柄</param>
    /// <param name="hints">user hints to end session, hints will be logged to CallLog. 结束本次语音识别的原因描述,为用户自定义内容</param>
    /// <returns>return 0 if sucess, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QISRSessionEnd(IntPtr sessionID, string hints);
    /// <summary>
    /// get params related with msc. 获取当次语音识别信息,如上行流量、下行流量等
    /// </summary>
    /// <param name="sessionID">session id of related param, set null to got global param. 由QISRSessionbegin返回的句柄,如果为NULL,获取msc的设置信息</param>
    /// <param name="paramName">param name,could pass more than one param split by ','';'or'\n'. 参数名,一次调用只支持查询一个参数</param>
    ///     在线  sid         服务端会话ID 长度为32字节
    ///     在线  upflow      上行数据量
    ///     在线  downflow    下行数据量
    ///     通用  volume      最后一次写入的音频的音量
    /// <param name="paramValue">param value buffer, malloced by user.</param>
    ///     输入: buffer首地址
    ///     输出: 向该buffer写入获取到的信息
    /// <param name="valueLen">pass in length of value buffer, and return length of value string.</param>
    ///     输入: buffer的大小
    ///     输出: 信息实际长度(不含’\0’)
    /// <returns>return 0 if success, otherwise return errcode. 函数调用成功返回MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QISRGetParam(string sessionID, string paramName, ref byte[] paramValue, ref uint valueLen);
    #endregion

    #region qtts.h 语音合成
    /// <summary>
    /// create a tts session to synthesize data. 开始一次语音合成,分配语音合成资源
    /// </summary>
    /// <param name="_params">parameters when the session created. 传入的参数列表</param>
    ///     通用  engine_type     引擎类型                      cloud在线引擎 local离线引擎
    ///     通用  voice_name      发音人                        不同的发音人代表了不同的音色 如男声、女声、童声等
    ///     通用  speed           语速                          0-100 default50
    ///     通用  volume          音量                          0-100 dafault50
    ///     通用  pitch           语调                          0-100 default50
    ///     离线  tts_res_path    合成资源路径                  合成资源所在路径,支持fo 方式参数设置
    ///     通用  rdn             数字发音                      0数值优先 1完全数值 2完全字符串 3字符串优先
    ///     离线  rcn             1 的中文发音                  0表示发音为yao 1表示发音为yi
    ///     通用  text_encoding   文本编码格式(必传)            合成文本编码格式,支持参数,GB2312,GBK,BIG5,UNICODE,GB18030,UTF8
    ///     通用  sample_rate     合成音频采样率                合成音频采样率,支持参数,16000,8000,默认为16000
    ///     在线  background_sound背景音                        0无背景音乐   1有背景音乐
    ///     在线  aue             音频编码格式和压缩等级        编码算法:raw;speex;speex-wb;ico 编码等级: raw不进行压缩 speex系列0-10
    ///     在线  ttp             文本类型                      text普通格式文本 cssml格式文本
    ///     离线  speed_increase  语速增强                      1正常 2二倍语速 4四倍语速
    ///     离线  effect          合成音效                      0无音效 1忽远忽近 2回声 3机器人 4合唱 5水下 6混响 7阴阳怪气
    /// <param name="errorCode">return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</param>
    /// <returns>return the new session id if success, otherwise return null. 函数调用成功返回字符串格式的sessionID,失败返回NULL sessionID是本次合成的句柄</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr QTTSSessionBegin(string _params, ref int errorCode);
    /// <summary>
    /// writing text string to synthesizer. 写入要合成的文本
    /// </summary>
    /// <param name="sessionID">the session id returned by sesson begin. 由QTTSSessionBegin返回的句柄</param>
    /// <param name="textString">text buffer. 字符串指针 指向待合成的文本字符串</param>
    /// <param name="textLen">text size in bytes. 合成文本长度,最大支持8192个字节</param>
    /// <param name="_params">parameters when the session created. 本次合成所用的参数,只对本次合成的文本有效 目前为空</param>
    /// <returns>return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QTTSTextPut(IntPtr sessionID, string textString, uint textLen, string _params);
    /// <summary>
    /// synthesize text to audio, and return audio information. 获取合成音频
    /// </summary>
    /// <param name="sessionID">session id returned by session begin. 由QTTSSessionBegin返回的句柄</param>
    /// <param name="audioLen">synthesized audio size in bytes. 合成音频长度,单位字节</param>
    /// <param name="synthStatus">synthesizing status. 合成音频状态</param>
    /// <param name="errorCode">return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</param>
    /// 用户需要反复获取音频,直到音频获取完毕或函数调用失败
    /// 在重复获取音频时,如果暂未获得音频数据,需要将当前线程sleep一段时间,以防频繁调用浪费CPU资源
    /// <returns>return current synthesized audio data buffer, size returned by QTTSTextSynth. 函数调用成功且有音频数据时返回非空指针 调用失败或无音频数据时,返回NULL</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr QTTSAudioGet(IntPtr sessionID, ref uint audioLen, ref SynthStatus synthStatus, ref int errorCode);
    /// <summary>
    /// get synthesized audio data information.
    /// </summary>
    /// <param name="sessionID">session id returned by session begin.</param>
    /// <returns>return audio info string.</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr QTTSAudioInfo(IntPtr sessionID);
    /// <summary>
    /// end the recognizer session, release all resource. 结束本次语音合成
    /// 本接口和QTTSSessionBegin对应,调用此接口后,该句柄对应的相关资源(参数 合成文本 实例等)都会被释放,用户不应再使用该句柄
    /// </summary>
    /// <param name="sessionID">session id string to end. 由QTTSSessionBegin返回的句柄</param>
    /// <param name="hints">user hints to end session, hints will be logged to CallLog. 结束本次语音合成的原因描述,为用户自定义内容</param>
    /// <returns>return 0 if success, otherwise return error code. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QTTSSessionEnd(IntPtr sessionID, string hints);
    /// <summary>
    /// set params related with msc.
    /// </summary>
    /// <param name="sessionID">session id of related param, set null to got global param.</param>
    /// <param name="paramName">param name,could pass more than one param split by ','';'or'\n'.</param>
    /// <param name="paramValue">param value buffer, malloced by user.</param>
    /// <returns>return 0 if success, otherwise return errcode.</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QTTSSetParam(IntPtr sessionID, string paramName, byte[] paramValue);
    /// <summary>
    /// get params related with msc. 获取当前语音合成信息,如当前合成音频对应文本结束位置、上行流量、下行流量等
    /// </summary>
    /// <param name="sessionID">session id of related param, set NULL to got global param. 由QTTSSessionBegin返回的句柄,如果为NULL,获取msc的设置信息</param>
    /// <param name="paramName">param name,could pass more than one param split by ','';'or'\n'. 参数名,一次调用只支持查询一个参数</param>
    ///     在线  sid         服务端会话ID 长度为32字节
    ///     在线  upflow      上行数据量
    ///     在线  downflow    下行数据量
    ///     通用  ced         当前合成音频对应文本结束位置
    /// <param name="paramValue">param value buffer, malloced by user.</param>
    ///     输入: buffer首地址
    ///     输出: 向该buffer写入获取到的信息
    /// <param name="valueLen">pass in length of value buffer, and return length of value string</param>
    ///     输入: buffer的大小
    ///     输出: 信息实际长度(不含’\0’)
    /// <returns>return 0 if success, otherwise return errcode. 函数调用成功则其值为MSP_SUCCESS,否则返回错误代码</returns>
    [DllImport("msc_x64", CallingConvention = CallingConvention.StdCall)]
    public static extern int QTTSGetParam(IntPtr sessionID, string paramName, ref byte[] paramValue, ref uint valueLen);
    #endregion
}
public enum Errors
{
    MSP_SUCCESS = 0,
    MSP_ERROR_FAIL = -1,
    MSP_ERROR_EXCEPTION = -2,

    /* General errors 10100(0x2774) */
    MSP_ERROR_GENERAL = 10100,  /* 0x2774 */
    MSP_ERROR_OUT_OF_MEMORY = 10101,    /* 0x2775 */
    MSP_ERROR_FILE_NOT_FOUND = 10102,   /* 0x2776 */
    MSP_ERROR_NOT_SUPPORT = 10103,  /* 0x2777 */

    #region 10104
    /* 错误码解释:
     *      没有实现
     * 报错原因:
     *      当前服务不支持
     * 解决方案:
     *      服务不支持,没有实现该功能或接口,建议更换方式或调用的服务 */
    MSP_ERROR_NOT_IMPLEMENT = 10104,    /* 0x2778 */
    #endregion
    #region 10105
    /* 错误码解释:
     *      没有权限
     * 报错原因:
     *      未通过服务端校验
     * 解决方案:
     *      [SDK]可能是应用没有权限访问某项服务,需要检查应用是否通过审核或参数是否合法、完整,检查相应文件是否具有读写权限 */
    MSP_ERROR_ACCESS = 10105,   /* 0x2779 */
    #endregion
    #region 10106
    /* 错误码解释:
     *      无效的参数
     * 报错原因:
     *      可能的原因如下:
     *          · 参数名与文档不符
     *          · 参数值不在规定范围内
     * 解决方案:
     *      按照文档说明,输入正确的参数名称 */
    MSP_ERROR_INVALID_PARA = 10106,     /* 0x277A */
    #endregion
    #region 10107
    /* 错误码解释:
     *      无效的参数值
     * 报错原因:
     *      1.参数值错误
     *      2.离线资源没有正确导入(SDK)
     *      3.单次合成的交互次数超过最大限制
     * 解决方案:
     *      1.按照文档说明,检查参数值是否超过范围或不符合要求。
     *      2.导入资源到相应位置（SDK）
     *      3.图像文字识别报错可能是参数不在要求的范围内或者图片格式不符合要求。
     *      4.参数都看似正确的话,检查参数前是否有空格*/
    MSP_ERROR_INVALID_PARA_VALUE = 10107,   /* 0x277B */
    #endregion
    #region 10108
    /* 错误码解释:
     *      无效的句柄
     * 报错原因:
     *     某两个接口调用的时间间隔过长（比如:调sessionbegin接口之后,过了很长时间才调了writeaudio接口）
     * 解决方案:
     *      缩短这两个接口的调用时间间隔 */
    MSP_ERROR_INVALID_HANDLE = 10108,   /* 0x277C */
    #endregion
    #region 10109
    /* 错误码解释:
     *      无效的数据
     * 报错原因:
     *      1.上传数据无效,听写热词文件、命令词识别语法文件上传等
     *      2.评测业务:用户传送的文本长度大于规定字节（中文限制在180字节,英文限制在300字节）导致
     *      3.客户端上传的命令词语法,存在单词长度超过128字节。
     *      	客户端上传abnf时,语法内容不是以#ABNF 1.0 UTF-8;和#ABNF 1.0 gb2312;开头,目前只支持这两种格式的abnf语法上传。
     *      	携带的语法内容为空。
     *      	网络不给力,音频数据传不上去也会出现这个错误
     *      4.上传的音频过长或图片过大
     * 解决方案:
     *      1.查看编码是否符合需求,一定要是utf-8编码,查看内部语法编写是否符合需求
     *      2.将长文本拆分成多个短文本,分多次会话进行评测
     *      3.压缩音频或图片,不要超过上限（可查阅文档确认上限）*/
    MSP_ERROR_INVALID_DATA = 10109,     /* 0x277D */
    #endregion
    #region 10110
    /* 错误码解释:
     *      没有授权许可
     * 报错原因:
     *      没有授权许可或授权数已满 */
    MSP_ERROR_NO_LICENSE = 10110,   /* 0x277E */
    #endregion
    #region 10111
    /* 错误码解释:
     *      没有初始化
     * 报错原因:
     *      未调用MSPLogin接口
     * 解决方案:
     *      1. 调用MSPLogin接口。
     *      2. 已经调用MSPLogin接口,检查是否调用MSPLogout登出,如果是的话需要重新调用MSPLogin接口 */
    MSP_ERROR_NOT_INIT = 10111,     /* 0x277F */
    #endregion
    #region 10112
    /* 错误码解释:
     *      空句柄
     * 报错原因:
     *      使用了空句柄 */
    MSP_ERROR_NULL_HANDLE = 10112,  /* 0x2780 */
    #endregion
    #region 10113
    /* 错误码解释:
     *      溢出
     * 报错原因:
     *      上次会话和本次会话的时间间隔过短
     * 解决方案:
     *      上次会话结束后,不要立即开启下一次会话 */
    MSP_ERROR_OVERFLOW = 10113,     /* 0x2781 */
    #endregion
    #region 10114
    /* 错误码解释:
     *      会话超时
     * 报错原因:
     *      1. 网络问题,导致请求超时;
     * 解决方案:
     *      可能与当前网络质量有关,可以换个网络再测试一下,查看网络环境是否正常,查看是否使用的网络对请求域名或者端口有限制 */
    MSP_ERROR_TIME_OUT = 10114,     /* 0x2782 */
    #endregion
    #region 10115
    MSP_ERROR_OPEN_FILE = 10115,    /* 0x2783 */
    #endregion
    #region 10116
    /* 错误码解释:
     *      没有找到资源或者模型
     * 报错原因:
     *      离线资源路径设置有误或者人脸/声纹模型未创建成功
     * 解决方案:
     *      离线资源导入的时候使用绝对路径/人脸or声纹模型重新注册 */
    MSP_ERROR_NOT_FOUND = 10116,    /* 0x2784 */
    #endregion
    #region 10117
    /* 错误码解释:
     *      缓冲区不足
     * 报错原因:
     *      没有足够的缓冲区  一般是合成出现该问题,查看是否每次合成字数超出上线,每次合成的字数太多或在线8192字节要限制在60s
     * 解决方案:
     *      合成业务: 把文本拆分成每次合成在2048个字符以下 */
    MSP_ERROR_NO_ENOUGH_BUFFER = 10117,     /* 0x2785 */
    #endregion
    #region 10118
    /* 错误码解释:
     *      没有数据
     * 报错原因:
     *      没有数据
     * 解决方案:
     *      可能是因为一段时间没有说话就停止了录音,请检查代码中设置的 VAD_BOS 值是多少,默认的是 4000ms */
    MSP_ERROR_NO_DATA = 10118,  /* 0x2786 */
    #endregion
    #region 10119
    /* 错误码解释:
     *      没有更多的数据
     * 报错原因:
     *      音频的码率和精度与语音云支持的码率和精度不相符
     * 解决方案:
     *      SDK仅支持:采样率16k或者8k,采样精度16bit,单声道pcm或者wav格式的音频 */
    MSP_ERROR_NO_MORE_DATA = 10119,     /* 0x2787 */
    #endregion
    #region 10120
    /* 错误码解释:
     *      结果等待超时
     * 报错原因:
     *      网络状态差或者服务器处理缓慢 */
    MSP_ERROR_NO_RESPONSE_DATA = 10120,     /* 0x2788 */
    #endregion
    #region 10121
    /* 错误码解释:
     *      已经存在
     * 报错原因:
     *      声纹/人脸业务:模型或记录已存在
     * 解决方案:
     *      若需重新注册模型,需先删除现有的声纹/人脸模型,再注册 */
    MSP_ERROR_ALREADY_EXIST = 10121,    /* 0x2789 */
    #endregion
    #region 10122
    /* 错误码解释:
     *      加载模块失败
     * 报错原因:
     *      某业务组件加载失败
     * 解决方案:
     *      检查MSC库是否正常加载 */
    MSP_ERROR_LOAD_MODULE = 10122,  /* 0x278A */
    #endregion
    #region 10123-11207
    MSP_ERROR_BUSY = 10123,     /* 0x278B */
    MSP_ERROR_INVALID_CONFIG = 10124,   /* 0x278C */
    MSP_ERROR_VERSION_CHECK = 10125,    /* 0x278D */
    MSP_ERROR_CANCELED = 10126,     /* 0x278E */
    MSP_ERROR_INVALID_MEDIA_TYPE = 10127,   /* 0x278F */

    MSP_ERROR_CONFIG_INITIALIZE = 10128,    /* 0x2790 */
    MSP_ERROR_CREATE_HANDLE = 10129,    /* 0x2791 */
    MSP_ERROR_CODING_LIB_NOT_LOAD = 10130,  /* 0x2792 */
    MSP_ERROR_USER_CANCELLED = 10131,   /* 0x2793 */
    MSP_ERROR_INVALID_OPERATION = 10132,    /* 0x2794 */
    MSP_ERROR_MESSAGE_NOT_COMPLETE = 10133, /* 0x2795 */   /* flash */
    MSP_ERROR_NO_EID = 10134,   /* 0x2795 */
    MSP_ERROE_OVER_REQ = 10135,    /* 0x2797 */   /* client Redundancy request */
    MSP_ERROR_USER_ACTIVE_ABORT = 10136,    /* 0x2798 */   /* user abort */
    MSP_ERROR_BUSY_GRMBUILDING = 10137,    /* 0x2799 */
    MSP_ERROR_BUSY_LEXUPDATING = 10138,    /* 0x279A */
    MSP_ERROR_SESSION_RESET = 10139,    /* 0x279B */   /* msc主动终止会话,准备重传 */
    MSP_ERROR_BOS_TIMEOUT = 10140,    /* 0x279C */   /* VAD前端点超时 */
    MSP_ERROR_STREAM_FILTER = 10141,    /* 0X279D */   /* AIUI当前Stream被过滤 */
    MSP_ERROR_STREAM_CLEAR = 10142,    /* 0X279E */   /* AIUI当前Stream被清理 */

    /* Error codes of network 10200(0x27D8)*/
    MSP_ERROR_NET_GENERAL = 10200,  /* 0x27D8 */
    MSP_ERROR_NET_OPENSOCK = 10201,     /* 0x27D9 */   /* Open socket */
    MSP_ERROR_NET_CONNECTSOCK = 10202,  /* 0x27DA */   /* Connect socket */
    MSP_ERROR_NET_ACCEPTSOCK = 10203,   /* 0x27DB */   /* Accept socket */
    MSP_ERROR_NET_SENDSOCK = 10204,     /* 0x27DC */   /* Send socket data */
    MSP_ERROR_NET_RECVSOCK = 10205,     /* 0x27DD */   /* Recv socket data */
    MSP_ERROR_NET_INVALIDSOCK = 10206,  /* 0x27DE */   /* Invalid socket handle */
    MSP_ERROR_NET_BADADDRESS = 10207,   /* 0x27EF */   /* Bad network address */
    MSP_ERROR_NET_BINDSEQUENCE = 10208,     /* 0x27E0 */   /* Bind after listen/connect */
    MSP_ERROR_NET_NOTOPENSOCK = 10209,  /* 0x27E1 */   /* Socket is not opened */
    MSP_ERROR_NET_NOTBIND = 10210,  /* 0x27E2 */   /* Socket is not bind to an address */
    MSP_ERROR_NET_NOTLISTEN = 10211,    /* 0x27E3 */   /* Socket is not listening */
    MSP_ERROR_NET_CONNECTCLOSE = 10212,     /* 0x27E4 */   /* The other side of connection is closed */
    MSP_ERROR_NET_NOTDGRAMSOCK = 10213,     /* 0x27E5 */   /* The socket is not datagram type */
    MSP_ERROR_NET_DNS = 10214,  /* 0x27E6 */   /* domain name is invalid or dns server does not function well */
    MSP_ERROR_NET_INIT = 10215,     /* 0x27E7 */   /* ssl ctx create failed */

    /*nfl error*/
    MSP_ERROR_NFL_INNER_ERROR = 10216,    /* NFL inner error */
    MSP_ERROR_MSS_TIME_OUT = 10217,    /* MSS TIMEOUT */
    MSP_ERROT_CLIENT_TIME_OUT = 10218,    /* CLIENT TIMEOUT */
    MSP_ERROR_CLIENT_CLOSE = 10219,    /* CLIENT CLOSED CONNECTION */

    MSP_ERROR_CLIENT_AREA_CHANGE = 10220,
    MSP_ERROR_NET_SSL_HANDSHAKE = 10221,
    MSP_ERROR_NET_INVALID_ROOT_CERT = 10222,
    MSP_ERROR_NET_INVALID_CLIENT_CERT = 10223,
    MSP_ERROR_NET_INVALID_SERVER_CERT = 10224,
    MSP_ERROR_NET_INVALID_KEY = 10225,
    MSP_ERROR_NET_CERT_VERIFY_FAILED = 10226,
    MSP_ERROR_NET_WOULDBLOCK = 10227,
    MSP_ERROR_NET_NOTBLOCK = 10228,

    /* Error codes of mssp message 10300(0x283C) */
    MSP_ERROR_MSG_GENERAL = 10300,  /* 0x283C */
    MSP_ERROR_MSG_PARSE_ERROR = 10301,  /* 0x283D */
    MSP_ERROR_MSG_BUILD_ERROR = 10302,  /* 0x283E */
    MSP_ERROR_MSG_PARAM_ERROR = 10303,  /* 0x283F */
    MSP_ERROR_MSG_CONTENT_EMPTY = 10304,    /* 0x2840 */
    MSP_ERROR_MSG_INVALID_CONTENT_TYPE = 10305,     /* 0x2841 */
    MSP_ERROR_MSG_INVALID_CONTENT_LENGTH = 10306,   /* 0x2842 */
    MSP_ERROR_MSG_INVALID_CONTENT_ENCODE = 10307,   /* 0x2843 */
    MSP_ERROR_MSG_INVALID_KEY = 10308,  /* 0x2844 */
    MSP_ERROR_MSG_KEY_EMPTY = 10309,    /* 0x2845 */
    MSP_ERROR_MSG_SESSION_ID_EMPTY = 10310,     /* 0x2846 */   /* 会话ID为空 */
    MSP_ERROR_MSG_LOGIN_ID_EMPTY = 10311,   /* 0x2847 */   /* 音频序列ID为空 */
    MSP_ERROR_MSG_SYNC_ID_EMPTY = 10312,    /* 0x2848 */
    MSP_ERROR_MSG_APP_ID_EMPTY = 10313,     /* 0x2849 */
    MSP_ERROR_MSG_EXTERN_ID_EMPTY = 10314,  /* 0x284A */
    MSP_ERROR_MSG_INVALID_CMD = 10315,  /* 0x284B */
    MSP_ERROR_MSG_INVALID_SUBJECT = 10316,  /* 0x284C */
    MSP_ERROR_MSG_INVALID_VERSION = 10317,  /* 0x284D */
    MSP_ERROR_MSG_NO_CMD = 10318,   /* 0x284E */
    MSP_ERROR_MSG_NO_SUBJECT = 10319,   /* 0x284F */
    MSP_ERROR_MSG_NO_VERSION = 10320,   /* 0x2850 */
    MSP_ERROR_MSG_MSSP_EMPTY = 10321,   /* 0x2851 */
    MSP_ERROR_MSG_NEW_RESPONSE = 10322,     /* 0x2852 */
    MSP_ERROR_MSG_NEW_CONTENT = 10323,  /* 0x2853 */
    MSP_ERROR_MSG_INVALID_SESSION_ID = 10324,   /* 0x2854 */   /* 无效的会话ID(sid) */
    MSP_ERROR_MSG_INVALID_CONTENT = 10325,  /* 0x2855 */

    /* Error codes of DataBase 10400(0x28A0)*/
    MSP_ERROR_DB_GENERAL = 10400,   /* 0x28A0 */   /* 数据库异常 */
    MSP_ERROR_DB_EXCEPTION = 10401,     /* 0x28A1 */
    MSP_ERROR_DB_NO_RESULT = 10402,     /* 0x28A2 */   /* redis中没有找到会话ID(sid) */
    MSP_ERROR_DB_INVALID_USER = 10403,  /* 0x28A3 */
    MSP_ERROR_DB_INVALID_PWD = 10404,   /* 0x28A4 */
    MSP_ERROR_DB_CONNECT = 10405,   /* 0x28A5 */
    MSP_ERROR_DB_INVALID_SQL = 10406,   /* 0x28A6 */
    MSP_ERROR_DB_INVALID_APPID = 10407, /* 0x28A7 */
    MSP_ERROR_DB_NO_UID = 10408,

    /* Error codes of Resource 10500(0x2904)*/
    MSP_ERROR_RES_GENERAL = 10500,  /* 0x2904 */
    MSP_ERROR_RES_LOAD = 10501,     /* 0x2905 */   /* Load resource */
    MSP_ERROR_RES_FREE = 10502,     /* 0x2906 */   /* Free resource */
    MSP_ERROR_RES_MISSING = 10503,  /* 0x2907 */   /* Resource File Missing */
    MSP_ERROR_RES_INVALID_NAME = 10504,     /* 0x2908 */   /* Invalid resource file name */
    MSP_ERROR_RES_INVALID_ID = 10505,   /* 0x2909 */   /* Invalid resource ID */
    MSP_ERROR_RES_INVALID_IMG = 10506,  /* 0x290A */   /* Invalid resource image pointer */
    MSP_ERROR_RES_WRITE = 10507,    /* 0x290B */   /* Write read-only resource */
    MSP_ERROR_RES_LEAK = 10508,     /* 0x290C */   /* Resource leak out */
    MSP_ERROR_RES_HEAD = 10509,     /* 0x290D */   /* Resource head currupt */
    MSP_ERROR_RES_DATA = 10510,     /* 0x290E */   /* Resource data currupt */
    MSP_ERROR_RES_SKIP = 10511,     /* 0x290F */   /* Resource file skipped */

    /* Error codes of TTS 10600(0x2968)*/
    MSP_ERROR_TTS_GENERAL = 10600,  /* 0x2968 */
    MSP_ERROR_TTS_TEXTEND = 10601,  /* 0x2969 */  /* Meet text end */
    MSP_ERROR_TTS_TEXT_EMPTY = 10602,   /* 0x296A */  /* no synth text */
    MSP_ERROR_TTS_LTTS_ERROR = 10603,   /* 0x296B */

    /* Error codes of Recognizer 10700(0x29CC) */
    MSP_ERROR_REC_GENERAL = 10700,  /* 0x29CC */  /* 引擎异常 */
    MSP_ERROR_REC_INACTIVE = 10701,     /* 0x29CD */
    MSP_ERROR_REC_GRAMMAR_ERROR = 10702,    /* 0x29CE */
    MSP_ERROR_REC_NO_ACTIVE_GRAMMARS = 10703,   /* 0x29CF */
    MSP_ERROR_REC_DUPLICATE_GRAMMAR = 10704,    /* 0x29D0 */
    MSP_ERROR_REC_INVALID_MEDIA_TYPE = 10705,   /* 0x29D1 */
    MSP_ERROR_REC_INVALID_LANGUAGE = 10706,     /* 0x29D2 */
    MSP_ERROR_REC_URI_NOT_FOUND = 10707,    /* 0x29D3 */
    MSP_ERROR_REC_URI_TIMEOUT = 10708,  /* 0x29D4 */
    MSP_ERROR_REC_URI_FETCH_ERROR = 10709,  /* 0x29D5 */
    MSP_ERROR_REC_PROC_MOD = 10710, /* 0x29D6 */


    /* Error codes of Speech Detector 10800(0x2A30) */
    MSP_ERROR_EP_GENERAL = 10800,   /* 0x2A30 */
    MSP_ERROR_EP_NO_SESSION_NAME = 10801,   /* 0x2A31 */
    MSP_ERROR_EP_INACTIVE = 10802,  /* 0x2A32 */
    MSP_ERROR_EP_INITIALIZED = 10803,   /* 0x2A33 */

    /* Error codes of TUV */
    MSP_ERROR_TUV_GENERAL = 10900,  /* 0x2A94 */
    MSP_ERROR_TUV_GETHIDPARAM = 10901,  /* 0x2A95 */   /* Get Busin Param huanid*/
    MSP_ERROR_TUV_TOKEN = 10902,    /* 0x2A96 */   /* Get Token */
    MSP_ERROR_TUV_CFGFILE = 10903,  /* 0x2A97 */   /* Open cfg file */
    MSP_ERROR_TUV_RECV_CONTENT = 10904,     /* 0x2A98 */   /* received content is error */
    MSP_ERROR_TUV_VERFAIL = 10905,  /* 0x2A99 */   /* Verify failure */

    /* Error codes of IMTV */
    MSP_ERROR_LOGIN_SUCCESS = 11000,    /* 0x2AF8 */   /* 成功 */
    MSP_ERROR_LOGIN_NO_LICENSE = 11001,     /* 0x2AF9 */   /* 试用次数结束,用户需要付费 */
    MSP_ERROR_LOGIN_SESSIONID_INVALID = 11002,  /* 0x2AFA */   /* SessionId失效,需要重新登录通行证 */
    MSP_ERROR_LOGIN_SESSIONID_ERROR = 11003,    /* 0x2AFB */   /* SessionId为空,或者非法 */
    MSP_ERROR_LOGIN_UNLOGIN = 11004,    /* 0x2AFC */   /* 未登录通行证 */
    MSP_ERROR_LOGIN_INVALID_USER = 11005,   /* 0x2AFD */   /* 用户ID无效 */
    MSP_ERROR_LOGIN_INVALID_PWD = 11006,    /* 0x2AFE */   /* 用户密码无效 */
    MSP_ERROR_LOGIN_SYSTEM_ERROR = 11099,   /* 0x2B5B */   /* 系统错误 */

    /* Error codes of HCR */
    MSP_ERROR_HCR_GENERAL = 11100,
    MSP_ERROR_HCR_RESOURCE_NOT_EXIST = 11101,
    MSP_ERROR_HCR_CREATE = 11102,
    MSP_ERROR_HCR_DESTROY = 11103,
    MSP_ERROR_HCR_START = 11104,
    MSP_ERROR_HCR_APPEND_STROKES = 11105,
    MSP_ERROR_HCR_INIT = 11106,
    MSP_ERROR_HCR_POINT_DECODE = 11107,
    MSP_ERROR_HCR_DISPATCH = 11108,
    MSP_ERROR_HCR_GETRESULT = 11109,
    MSP_ERROR_HCR_RESOURCE = 11110,

    /* Error Codes using in local engine */
    MSP_ERROR_AUTH_NO_LICENSE = 11200,  /* 0x2BC0 */   /* 无授权 */
    MSP_ERROR_AUTH_NO_ENOUGH_LICENSE = 11201,   /* 0x2BC1 */   /* 授权不足 */
    MSP_ERROR_AUTH_INVALID_LICENSE = 11202, /* 0x2BC2 */   /* 无效的授权 */
    MSP_ERROR_AUTH_LICENSE_EXPIRED = 11203, /* 0x2BC3 */   /* 授权过期 */
    MSP_ERROR_AUTH_NEED_MORE_DATA = 11204,    /* 0x2BC4 */   /* 无设备信息 */
    MSP_ERROR_AUTH_LICENSE_TO_BE_EXPIRED = 11205,   /* 0x2BC5 */   /* 授权即将过期,警告性错误码 */
    MSP_ERROR_AUTH_INVALID_MACHINE_ID = 11206,    /* 0x2BC6 */   /* 无效的机器码 */
    MSP_ERROR_AUTH_LOCAL_ASR_FORBIDDEN = 11207,    /* 0x2BC7 */   /* 禁止使用本地识别引擎 */
    #endregion
    #region 11208
    /* 错误码解释:
     *      禁止使用本地合成引擎
     * 报错原因:
     *      禁止使用本地合成引擎,离线合成体验版超过限制
     * 解决方案:
     *      如需继续使用离线服务,请及时购买/续费 */
    MSP_ERROR_AUTH_LOCAL_TTS_FORBIDDEN = 11208,    /* 0x2BC8 */
    #endregion
    #region 11209
    /* 错误码解释:
     *      禁止使用本地唤醒引擎
     * 报错原因:
     *      禁止使用本地唤醒引擎,唤醒体验版超过限制
     * 解决方案:
     *      如需继续使用离线服务,请及时购买/续费 */
    MSP_ERROR_AUTH_LOCAL_IVW_FORBIDDEN = 11209,    /* 0x2BC9 */
    #endregion
    #region 11210
    /* 错误码解释:
     *      离线资源校验失败
     * 报错原因:
     *      appid和离线资源不匹配
     * 解决方案:
     *      检查离线资源和appid,确保两者相匹配 */
    MSP_ERROR_AUTH_APPID_NOT_MATCH = 11210, /* 0x2BCA */
    #endregion
    #region 11211
    /* 错误码解释:
     *      离线资源校验失败
     * 报错原因:
     *      用户ID与离线资源不匹配
     * 解决方案:
     *      检查离线资源和用户ID,确保两者相匹配 */
    MSP_ERROR_AUTH_UID_NOT_MATCH = 11211,   /* 0x2BCB */
    #endregion
    #region 11212
    /* 错误码解释:
     *      试用资源过期
     * 报错原因:
     *      离线体验版时间授权过期 */
    MSP_ERROR_AUTH_TRIAL_EXPIRED = 11212,   /* 0x2BCC */
    #endregion
    #region 11213
    MSP_ERROR_AUTH_LOCAL_IFD_FORBIDDEN = 11213,    /* 0x2BC9 */   /* 禁止使用本地人脸引擎 */
    #endregion
    #region 11300-11306
    /*Error Codes of Authorization*/
    MSP_ERROR_AUTH_DVC_NO_LICENSE = 11300,
    MSP_ERROR_AUTH_DVC_NO_ENOUGH_LICENSE = 11301,
    MSP_ERROR_AUTH_DVC_INVALID_LICENSE = 11302,
    MSP_ERROR_AUTH_DVC_LICENSE_EXPIRED = 11303,
    MSP_ERROR_AUTH_DVC_NEED_MORE_DATA = 11304,
    MSP_ERROR_AUTH_DVC_LICENSE_TO_BE_EXPIRED = 11305,
    MSP_ERROR_AUTH_DVC_EXCEED_LICENSE = 11306,
    #endregion
    #region 11401
    /* 错误码解释:
     *      用户的音频没声音或者声音太小
     * 报错原因:
     *      用户的音频没声音或者声音太小
     * 解决方案:
     *      检查是否有语音输入,或调大音量 */
    MSP_ERROR_ASE_EXCEP_SILENCE = 11401,
    #endregion
    #region 11402-11403
    MSP_ERROR_ASE_EXCEP_SNRATIO = 11402,
    MSP_ERROR_ASE_EXCEP_PAPERDATA = 11403,
    #endregion
    #region 11404
    /* 错误码解释:
     *      评测文本内容有误
     * 报错原因:
     *      1、评测文本内容超过引擎最大限制
     *      2、评测文本内容不符合文本规范 */
    MSP_ERROR_ASE_EXCEP_PAPERCONTENTS = 11404,
    #endregion
    #region 11405-11406
    MSP_ERROR_ASE_EXCEP_NOTMONO = 11405,
    MSP_ERROR_ASE_EXCEP_OTHERS = 11406,
    #endregion
    #region 11407
    /* 错误码解释:
     *      试卷格式有误
     * 报错原因:
     *      试卷格式有误 */
    MSP_ERROR_ASE_EXCEP_PAPERFMT = 11407,
    #endregion
    #region 11408
    /* 错误码解释:
     *      存在未登录词
     * 报错原因:
     *      存在未登录词,比如:80-year-old中带有"-",引擎会认为是减号
     * 解决方案:
     *      去除不合法的字符 */
    MSP_ERROR_ASE_EXCEP_ULISTWORD = 11408,
    #endregion
    #region 11500-11600
    MSP_ERROR_IOT_BASE = 11500,
    MSP_ERROR_IOT_PARAM_ERROR = 11501,      // param error
    MSP_ERROR_IOT_INVALID_SERVICE = 11502,      // invalid service for iot ProTranServer
    MSP_ERROR_IOT_INVALID_PRODUCTID = 11503,        // invalid productid for ProTranServer
    MSP_EEROR_IOT_INVALID_ATTR = 11504,     // invalid attr value for one product in ProTranServer
    MSP_ERROR_IOT_INVALID_PLATFORM = 11505,     // invalid platform for ProTranServer
    MSP_ERROR_IOT_DID_NOT_FOUND = 11506,        // not found device id in semantic
    MSP_ERROR_IVP_GENERAL = 11600,            //  内核异常
    #endregion
    #region 11601
    /* 错误码解释:
     *      注册时向引擎所写音频条数超过上限(9次)
     * 报错原因:
     *      注册时向引擎所写音频条数超过上限(9次)
     * 解决方案:
     *      注册有效次数rgn范围为2-9次,包括出错次数,最多不超过9次 */
    MSP_ERROR_IVP_EXTRA_RGN_SOPPORT = 11601,
    #endregion
    #region 11602
    /* 错误码解释:
     *      音频截幅
     * 报错原因:
     *      因信号波形的幅度太大,而超出系统的线性范围,如记录尖叫声的音频
     * 解决方案:
     *      更换注册或验证音频,声音太大,音量减小一点,或者说话远离手机一点 */
    MSP_ERROR_IVP_TRUNCATED = 11602,
    #endregion
    #region 11603
    /* 错误码解释:
     *      音频信噪比过低
     * 报错原因:
     *      音频信噪比过低
     * 解决方案:
     *      更换注册或验证音频,到安静的地方去录音 */
    MSP_ERROR_IVP_MUCH_NOISE = 11603,
    #endregion
    #region 11604
    /* 错误码解释:
     *      音频能量过低
     * 报错原因:
     *      音频能量过低
     * 解决方案:
     *      更换注册或验证音频,音量太小,音量增大一点,或者说话靠近手机一点 */
    MSP_ERROR_IVP_TOO_LOW = 11604,            //  音频能量过低
    #endregion
    #region 11605
    /* 错误码解释:
     *      无音频
     * 报错原因:
     *      无音频
     * 解决方案:
     *      更换注册或验证音频,音频缺失开头和结尾,录音开始后再说话,录音完停顿一秒再结束,保证开头结尾有一定的静音 */
    MSP_ERROR_IVP_ZERO_AUDIO = 11605,            //  无音频
    #endregion
    #region 11606
    /* 错误码解释:
     *      音频太短
     * 报错原因:
     *      声纹音频太短了
     * 解决方案:
     *      更换注册或验证音频,音频太短不足以提取有效音频特征,录音时候要接近正常语速,不要读太快 */
    MSP_ERROR_IVP_UTTER_TOO_SHORT = 11606,
    #endregion
    #region 11607
    /* 错误码解释:
     *      音频和文本不匹配
     * 报错原因:
     *      1.抢读(在按下录音键之前读)
     *      2.录音机的启动电流被录入表现在音频上是在音频首有冲击电流 
     *      3.确实不匹配"
     * 解决方案:
     *      更换音频或者修改密码文本,录音文本和录音不一致,可能是真的读错了,也可能能是读对了,但是发音不标准,有颤音,方言等,尽量读标准普通话,发音清晰 */
    MSP_ERROR_IVP_TEXT_NOT_MATCH = 11607,
    #endregion
    #region 11608
    /* 错误码解释:
     *      音频不够,注册自由说,而写入的音频又不够长时会报,告诉调用者继续传音频
     * 报错原因:
     *      音频不够,注册自由说,而写入的音频又不够长时会报,告诉调用者继续传音频
     * 解决方案:
     *      更换注册或验证音频,针对自由说,有效音频要超过20秒,录音时间一般不少于30秒 */
    MSP_ERROR_IVP_NO_ENOUGH_AUDIO = 11608,
    #endregion
    #region 11610
    MSP_ERROR_IVP_MODEL_NOT_FOUND_IN_HBASE = 11610,            //  模型在hbase中没找到
    #endregion
    /* Error codes of Face */

    MSP_ERROR_IFR_NOT_FACE_IMAGE = 11700,           //	【无人脸,对应的引擎错误码是20200 】      
    MSP_ERROR_FACE_IMAGE_FULL_LEFT = 11701,         //	【人脸向左,对应的引擎错误码是20201】
    MSP_ERROR_FACE_IMAGE_FULL_RIGHT = 11702,            //	【人脸向右,对应的引擎错误码是20202】
    MSP_ERROR_IMAGE_CLOCKWISE_WHIRL = 11703,            //	【顺时针旋转,对应的引擎错误码是20203】
    MSP_ERROR_IMAGE_COUNTET_CLOCKWISE_WHIRL = 11704,            //	【逆时针旋转,对应的引擎错误码是20204】
    MSP_ERROR_VALID_IMAGE_SIZE = 11705,         //	【图片大小异常 ,对应的引擎错误码是20205】
    MSP_ERROR_ILLUMINATION = 11706,         //	【光照异常,对应的引擎错误码是20206】
    MSP_ERROR_FACE_OCCULTATION = 11707,         //	【人脸被遮挡,对应的引擎错误码是20207】
    MSP_ERROR_FACE_INVALID_MODEL = 11708,           //	【非法模型数据,对应的引擎错误码是20208】
    MSP_ERROR_FUSION_INVALID_INPUT_TYPE = 11709,            //	【输入数据类型非法,对应的引擎错误码是20300】
    MSP_ERROR_FUSION_NO_ENOUGH_DATA = 11710,            //	【输入的数据不完整,对应的引擎错误码是20301】
    MSP_ERROR_FUSION_ENOUGH_DATA = 11711,           //	【输入的数据过多,对应的引擎错误码是20302】

    /*Error Codes of AIUI*/
    MSP_ERROR_AIUI_CID_EXPIRED = 11800,

    /* Error codes of http 12000(0x2EE0) */
    MSP_ERROR_HTTP_BASE = 12000,    /* 0x2EE0 */
    MSP_ERROR_HTTP_400 = 12400,
    MSP_ERROR_HTTP_401 = 12401,
    MSP_ERROR_HTTP_402 = 12402,
    MSP_ERROR_HTTP_403 = 12403,
    MSP_ERROR_HTTP_404 = 12404,
    MSP_ERROR_HTTP_405 = 12405,
    MSP_ERROR_HTTP_406 = 12406,
    MSP_ERROR_HTTP_407 = 12407,
    MSP_ERROR_HTTP_408 = 12408,
    MSP_ERROR_HTTP_409 = 12409,
    MSP_ERROR_HTTP_410 = 12410,
    MSP_ERROR_HTTP_411 = 12411,
    MSP_ERROR_HTTP_412 = 12412,
    MSP_ERROR_HTTP_413 = 12413,
    MSP_ERROR_HTTP_414 = 12414,
    MSP_ERROR_HTTP_415 = 12415,
    MSP_ERROR_HTTP_416 = 12416,
    MSP_ERROR_HTTP_417 = 12417,
    MSP_ERROR_HTTP_500 = 12500,
    MSP_ERROR_HTTP_501 = 12501,
    MSP_ERROR_HTTP_502 = 12502,
    MSP_ERROR_HTTP_503 = 12503,
    MSP_ERROR_HTTP_504 = 12504,
    MSP_ERROR_HTTP_505 = 12505,
    /*Error codes of ISV */
    MSP_ERROR_ISV_NO_USER = 13000,  /* 32C8 */    /* the user doesn't exist */

    /* Error codes of Lua scripts */
    MSP_ERROR_LUA_BASE = 14000,    /* 0x36B0 */
    MSP_ERROR_LUA_YIELD = 14001,    /* 0x36B1 */
    MSP_ERROR_LUA_ERRRUN = 14002,   /* 0x36B2 */
    MSP_ERROR_LUA_ERRSYNTAX = 14003,    /* 0x36B3 */
    MSP_ERROR_LUA_ERRMEM = 14004,   /* 0x36B4 */
    MSP_ERROR_LUA_ERRERR = 14005,   /* 0x36B5 */
    MSP_ERROR_LUA_INVALID_PARAM = 14006,    /* 0x36B6 */

    /* Error codes of MMP */
    MSP_ERROR_MMP_BASE = 15000,    /* 0x3A98 */
    MSP_ERROR_MMP_MYSQL_INITFAIL = 15001,   /* 0x3A99 */
    MSP_ERROR_MMP_REDIS_INITFAIL = 15002,   /* 0x3A9A */
    MSP_ERROR_MMP_NETDSS_INITFAIL = 15003,  /* 0x3A9B */
    MSP_ERROR_MMP_TAIR_INITFAIL = 15004,    /* 0x3A9C */
    MSP_ERROR_MMP_MAIL_SESSION_FAIL = 15006,    /* 0x3A9E */    /* 邮件登陆服务器时,会话错误。*/
    MSP_ERROR_MMP_MAIL_LOGON_FAIL = 15007,  /* 0x3A9F */    /* 邮件登陆服务器时,拒绝登陆。*/
    MSP_ERROR_MMP_MAIL_USER_ILLEGAL = 15008,    /* 0x3AA0 */    /* 邮件登陆服务器时,用户名非法。*/
    MSP_ERROR_MMP_MAIL_PWD_ERR = 15009, /* 0x3AA1 */    /* 邮件登陆服务器时,密码错误。*/
    MSP_ERROR_MMP_MAIL_SOCKET_ERR = 15010,  /* 0x3AA2 */    /* 邮件发送过程中套接字错误*/
    MSP_ERROR_MMP_MAIL_INIT_FAIL = 15011,   /* 0x3AA3 */    /* 邮件初始化错误*/
    MSP_ERROR_MMP_STORE_MNR_NO_INIT = 15012,    /* 0x3AA4 */    /* store_manager未初始化,或初始化失败*/
    MSP_ERROR_MMP_STORE_MNR_POOL_FULL = 15013,  /* 0x3AA5 */    /* store_manager的连接池满了*/
    MSP_ERROR_MMP_STRATGY_PARAM_ILLEGAL = 15014,    /* 0x3AA6 */    /* 报警策略表达式非法*/
    MSP_ERROR_MMP_STRATGY_PARAM_TOOLOOG = 15015,    /* 0x3AA7 */    /* 报警策略表达式太长*/
    MSP_ERROR_MMP_PARAM_NULL = 15016,   /* 0x3AA8 */    /* 函数参数为空*/
    MSP_ERROR_MMP_ERR_MORE_TOTAL = 15017,   /* 0x3AA9 */    /* pms插入数据库中错误汇总表的数据,错误次数 > 总次数。*/
    MSP_ERROR_MMP_PROC_THRESHOLD = 15018,   /* 0x3AAA */    /* 进程监控阀值设置错误*/
    MSP_ERROR_MMP_SERVER_THRESHOLD = 15019, /* 0x3AAB */    /* 服务器监控阀值设置错误*/
    MSP_ERROR_MMP_PYTHON_NO_EXIST = 15020,    /* 0x3AAC */  /* python脚本文件不存在 */
    MSP_ERROR_MMP_PYTHON_IMPORT_FAILED = 15021, /* 0x3AAD */    /* python脚本导入出错 */
    MSP_ERROR_MMP_PYTHON_BAD_FUNC = 15022,  /* 0x3AAE */    /* python脚本函数格式错误 */
    MSP_ERROR_MMP_DB_DATA_ILLEGAL = 15023,  /* 0x3AAF */    /* 插入数据库中的数据格式有误 */
    MSP_ERROR_MMP_REDIS_NOT_CONN = 15024,   /* 0x3AB0 */    /* redis没有连接到服务端 */
    MSP_ERROR_MMP_PMA_NOT_FOUND_STRATEGY = 15025,   /* 0x3AB1 */    /* 没有找到报警策略 */
    MSP_ERROR_MMP_TAIR_CONNECT = 15026, /* 0x3AB2 */    /* 连接tair集群失败 */
    MSP_ERROR_MMP_PMC_SERVINFO_INVALID = 15027, /* Ox3AB3 */    /* 此pmc的服务器信息已经无效 */
    MSP_ERROR_MMP_ALARM_GROUP_NULL = 15028, /* Ox3AB4 */    /* 服务器报警的短信报警组与邮件报警组均为空 */
    MSP_ERROR_MMP_ALARM_CONTXT_NULL = 15029,    /* Ox3AB5 */    /* 服务器报警的报警内容为空 */

    /* Error codes of MSC(lmod loader) */
    MSP_ERROR_LMOD_BASE = 16000,    /* 0x3E80 */
    MSP_ERROR_LMOD_NOT_FOUND = 16001,   /* 0x3E81 */    /* 没找到lmod文件 */
    MSP_ERROR_LMOD_UNEXPECTED_BIN = 16002,  /* 0x3E82 */    /* 无效的lmod */
    MSP_ERROR_LMOD_LOADCODE = 16003,    /* 0x3E83 */    /* 加载lmod指令失败 */
    MSP_ERROR_LMOD_PRECALL = 16004, /* 0x3E84 */    /* 初始化lmod失败 */
    MSP_ERROR_LMOD_RUNTIME_EXCEPTION = 16005,   /* 0x3E85 */    /* lmod运行时异常 */
    MSP_ERROR_LMOD_ALREADY_LOADED = 16006,  /* 0x3E86 */    /* lmod重复加载 */

    // Error code of Third Business
    MSP_ERROR_BIZ_BASE = 17000, /* 0x4268 */    /* 三方业务错误码 */

    //Error of Nginx errlog file increase exception
    MSP_ERROR_NGX_LOG_MORE_TOTEL_SIZE = 18000,                  /*nginx错误日志大小异常*/

    //Error of Flash client when network checking
    MSP_ERROR_FLASH_NETWORK_CONNECT_FIALED = 19000,                 /*flash服务端网络连接失败*/
    MSP_ERROR_FLASH_NETWORK_CHECK_FIALED = 19001,                   /*flash服务端响应了异常消息*/
    MSP_ERROR_FLASH_NETWORK_CHECK_TIMEOUT = 19002,                  /*flash服务端网络超时*/
    MSP_ERROR_FLASH_NETWORK_CLOSED_EXCEPTION = 19003,                   /*flash服务端网络异常关闭*/

    /*Error Code Of Speech plus*/

    SPEECH_ERROR_NO_NETWORK = 20001, /* 无有效的网络连接*/
    SPEECH_ERROR_NETWORK_TIMEOUT = 20002, /* 网络连接超时*/
    SPEECH_ERROR_NET_EXPECTION = 20003, /* 网络异常*/
    SPEECH_ERROR_INVALID_RESULT = 20004, /* 无有效的结果*/
    SPEECH_ERROR_NO_MATCH = 20005, /* 无匹配结果 */
    SPEECH_ERROR_AUDIO_RECORD = 20006, /* 录音失败 */
    SPEECH_ERROR_NO_SPPECH = 20007, /* 未检测到语音*/

    SPEECH_ERROR_SPEECH_TIMEOUT = 20008, /* 音频输入超时*/
    SPEECH_ERROR_EMPTY_UTTERANCE = 20009, /* 无效的文本输入 */
    SPEECH_ERROR_FILE_ACCESS = 20010, /* 文件读写失败 */
    SPEECH_ERROR_PLAY_MEDIA = 20011, /* 音频播放失败 */

    SPEECH_ERROR_INVALID_PARAM = 20012, /* 无效的参数*/
    SPEECH_ERROR_TEXT_OVERFLOW = 20013, /* 文本溢出 */
    SPEECH_ERROR_INVALID_DATA = 20014, /* 无效数据 */
    SPEECH_ERROR_LOGIN = 20015, /* 用户未登陆*/
    SPEECH_ERROR_PERMISSION_DENIED = 20016, /* 无效授权 */
    SPEECH_ERROR_INTERRUPT = 20017, /* 被异常打断 */

    SPEECH_ERROR_VERSION_LOWER = 20018, /* 版本过低 */
    SPEECH_CLIENT_ERROR_ISUSING = 20019, /* 录音机被占用(iOS平台) */
    SPEECH_ERROR_SYSTEM_PREINSTALL = 20020, /* 系统预置版本 */
    SPEECH_ERROR_UNSATISFIED_LINK = 20021, /* 未实现的Native函数引用 */
    SPEECH_ERROR_UNKNOWN = 20999, /* 未知错误 */


    SPEECH_ERROR_COMPONENT_NOT_INSTALLED = 21001, /* 没有安装语音组件 */
    SPEECH_ERROR_ENGINE_NOT_SUPPORTED = 21002, /* 引擎不支持 */
    SPEECH_ERROR_ENGINE_INIT_FAIL = 21003, /* 初始化失败 */
    SPEECH_ERROR_ENGINE_CALL_FAIL = 21004, /* 调用失败 */
    SPEECH_ERROR_ENGINE_BUSY = 21005, /* 引擎繁忙 */

    SPEECH_ERROR_LOCAL_NO_INIT = 22001, /* 本地引擎未初始化 */
    SPEECH_ERROR_LOCAL_RESOURCE = 22002, /* 本地引擎无资源 */
    SPEECH_ERROR_LOCAL_ENGINE = 22003, /* 本地引擎内部错误 */
    SPEECH_ERROR_IVW_INTERRUPT = 22004, /* 本地唤醒引擎被异常打断 */


    /*Error Code Of Local iflytek Engines*/

    /*Error Code Of AiTalk*/

    /*Error Code Of AiTalk Operation*/
    SPEECH_SUCCESS = 0, // ivErr_OK                  = 0 /*成功状态*/ 

    SPEECH_ERROR_ASR_CLIENT = 23000, /*客户端应用程序错误*///?????????
    SPEECH_ERROR_ASR_INVALID_PARA = 23001, /*无效的参数*/
    SPEECH_ERROR_ASR_INVALID_PARA_VALUE = 23002, /*无效的参数值*/
    SPEECH_ERROR_ASR_OUT_OF_MEMORY = 23003, /*内存耗尽*/
    SPEECH_ERROR_ASR_CREATE_HANDLE_FAILED = 23004, /*创建句柄失败*/
    SPEECH_ERROR_ASR_ENGINE_INIT_FAILED = 23005, /*引擎初始化失败*/
    SPEECH_ERROR_ASR_ENGINE_STARTED = 23006, /*引擎已经启动*/
    SPEECH_ERROR_ASR_ENGINE_UNINIT = 23007, /*引擎未初始化*/
    SPEECH_ERROR_ASR_SPEECH_TIMEOUT = 23008, /*识别超时（VAD没开启或没有检测到后端点）*/
    SPEECH_ERROR_ASR_NO_RECOGNIZED_RESULT = 23009, /*无识别结果*/
    SPEECH_ERROR_ASR_INVALID_HANDLE = 23010, /*无效的句柄*/
    SPEECH_ERROR_ASR_FILE_ACCESS = 23011, /*打开文件失败*/

    /*Error Code Of AiTalk Engine*/
    SPEECH_ERROR_AITALK_FALSE = 23100, // ivErr_FALSE               = 1                                                                                                              

    /* For license check */
    SPEECH_ERROR_AITALK_PERMISSION_DENIED = 23101, // ivErr_InvSN               = 2

    /* General */
    SPEECH_ERROR_AITALK_INVALID_PARA = 23102, // ivErr_InvArg              = 3
    SPEECH_ERROR_AITALK_BUFFER_OVERFLOW = 23103, // ivErr_BufferFull          = 4  /*音频数据缓冲区已满*/
    SPEECH_ERROR_AITALK_FAILED = 23104, // ivErr_Failed              = 5
    SPEECH_ERROR_AITALK_NOT_SUPPORTED = 23105, // ivErr_NotSupport          = 6  /*引擎不支持*/
    SPEECH_ERROR_AITALK_OUT_OF_MEMORY = 23106, // ivErr_OutOfMemory         = 7
    SPEECH_ERROR_AITALK_INVALID_RESOURCE = 23107, // ivErr_InvResource         = 8  /*资源无效*/
    SPEECH_ERROR_AITALK_NOT_FOUND = 23108, // ivErr_NotFound            = 9  /*打开文件失败*/
    SPEECH_ERROR_AITALK_INVALID_GRAMMAR = 23109, // ivErr_InvGrmr             = 10 /*识别语法错误*/

    /* For object status */
    SPEECH_ERROR_AITALK_INVALID_CALL = 23110, // ivErr_InvCall             = 11 /*无效调用*/

    /* For ASR Input */
    SPEECH_ERROR_AITALK_SYNTAX_ERROR = 23111, // ivErr_InvCall             = 12

    /* For Message Call Back */
    SPEECH_ERROR_AITALK_RESET = 23112, // ivErr_Reset               = 13                                                                       
    SPEECH_ERROR_AITALK_ENDED = 23113, // ivErr_Ended               = 14
    SPEECH_ERROR_AITALK_IDLE = 23114, // ivErr_Idle                = 15                                                                       
    SPEECH_ERROR_AITALK_CANNOT_SAVE_FILE = 23115, // ivErr_CanNotSaveFile      = 16

    /* For Lexicon name */
    SPEECH_ERROR_AITALK_INVALID_GRAMMAR_NAME = 23116, // ivErr_InvName             = 17 /*文法或词典名称非法*/

    SPEECH_ERROR_AITALK_BUFFER_EMPTY = 23117, // ivErr_BufferEmpty         = 18

    SPEECH_ERROR_AITALK_GET_RESULT = 23118, // ivErr_GetResult           = 19

    SPEECH_ERROR_AITALK_REACT_OUT_TIME = 23119, // ivErr_ReactOutTime        = 20 /*反应超时*/
    SPEECH_ERROR_AITALK_SPEECH_OUT_TIME = 23120, // ivErr_SpeechOutTime       = 21 /*语音超时*/

    SPEECH_ERROR_AITALK_AUDIO_CUT = 23121, // ivErr_CUT                 = 22 /*录音质量过高*/
    SPEECH_ERROR_AITALK_AUDIO_LOWER = 23122, // ivErr_LOWER               = 23 /*录音质量过低*/

    SPEECH_ERROR_AITALK_INSUFFICIENT_PERMISSIONS = 23123, // ivErr_Limitted            = 24 /*授权不够*/
    SPEECH_ERROR_AITALK_RESULT_ERROR = 23124, // ivErr_ResultError         = 25 /*解码器Wfst输出后,依然有cmd输出*/
    SPEECH_ERROR_AITALK_SHORT_PAUSE = 23125, // ivErr_ShortPause          = 26
    SPEECH_ERROR_AITALK_BUSY = 23126, // ivErr_Busy                = 27
    SPEECH_ERROR_AITALK_GRM_NOT_UPDATE = 23127, // ivErr_GrmNotUpdate        = 28 /*语法未更新*/
    SPEECH_ERROR_AITALK_STARTED = 23128, // ivErr_Started             = 29
    SPEECH_ERROR_AITALK_STOPPED = 23129, // ivErr_Stopped             = 30
    SPEECH_ERROR_AITALK_ALREADY_STARTED = 23130, // ivErr_AlreadyStarted      = 31
    SPEECH_ERROR_AITALK_ALREADY_STOPPED = 23131, // ivErr_AlreadyStopped      = 32
    SPEECH_ERROR_AITALK_TOO_MANY_COMMAND = 23132, // ivErr_TooManyCmd          = 33
    SPEECH_ERROR_AITALK_WAIT = 23133, // ivErr_Wait                = 34 /*程序可能在做一些操作,主线程需要等待*/
    SPEECH_ERROR_AITALK_MAE_RIGHT = 23134, // ivErr_MAERight            = 35 
    SPEECH_ERROR_AITALK_MAE_WRONG = 23135, // ivErr_MAEWrong            = 36

    SPEECH_ERROR_AITALK_GRM_ERR = 23300,  // 语法错误



    /*Error Code Of AiSound*/

    /*Error Code Of AiSound Operation*/
    SPEECH_ERROR_TTS_INVALID_PARA = 24000, /* 错误参数 */
    SPEECH_ERROR_TTS_INVALID_PARA_VALUE = 24001, /* 无效的参数值*/
    SPEECH_ERROR_TTS_OUT_OF_MEMORY = 24002, /* 内存不足*/
    SPEECH_ERROR_TTS_INVALID_HANDLE = 24003, /* 无效的句柄*/
    SPEECH_ERROR_TTS_CREATE_HANDLE_FAILED = 24004, /* 创建句柄失败*/
    SPEECH_ERROR_TTS_INVALID_RESOURCE = 24005,  /* 无效资源 */
    SPEECH_ERROR_TTS_INVALID_VOICE_NAME = 24006,    /* 无效发言人*/
    SPEECH_ERROR_TTS_ENGINE_UNINIT = 24007, /* 引擎未初始化 */
    SPEECH_ERROR_TTS_ENGINE_INIT_FAILED = 24008,    /* 引擎初始化失败 */
    SPEECH_ERROR_TTS_ENGINE_BUSY = 24009, /* 引擎忙 */


    /*Error Code Of AiSound Engine*/
    SPEECH_ERROR_AISOUND_BASE = 24100,
    SPEECH_ERROR_AISOUND_UNIMPEMENTED = 24100,  /* unimplemented function */
    SPEECH_ERROR_AISOUND_UNSUPPORTED = 24101,  /* unsupported on this platform */
    SPEECH_ERROR_AISOUND_INVALID_HANDLE = 24102,  /* invalid handle */
    SPEECH_ERROR_AISOUND_INVALID_PARA = 24103,  /* invalid parameter(s) */
    SPEECH_ERROR_AISOUND_INSUFFICIENT_HEAP = 24104,  /* insufficient heap size  */
    SPEECH_ERROR_AISOUND_STATE_REFUSE = 24105,  /* refuse to do in current state  */
    SPEECH_ERROR_AISOUND_INVALID_PARA_ID = 24106,  /* invalid parameter ID */
    SPEECH_ERROR_AISOUND_INVALID_PARA_VALUE = 24107,  /* invalid parameter value */
    SPEECH_ERROR_AISOUND_RESOURCE = 24108,  /* Resource is error */
    SPEECH_ERROR_AISOUND_RESOURCE_READ = 24109,  /* read resource error */
    SPEECH_ERROR_AISOUND_LBENDIAN = 24110,  /* the Endian of SDK  is error */
    SPEECH_ERROR_AISOUND_HEADFILE = 24111,  /* the HeadFile is different of the SDK */
    SPEECH_ERROR_AISOUND_BUFFER_OVERFLOW = 24112,  /* get data size exceed the data buffer */
    SPEECH_ERROR_AISOUND_INVALID_ISAMPA = 24113,  /* !Invalid iSampa format or input iSampa text contain invalid alphabet*/
    SPEECH_ERROR_AISOUND_INVALID_CSSML = 24114,   /* !Invalid cssml format */


    /*Error Code Of ivw*/

    /*Error Code Of ivw Operation*/
    SPEECH_ERROR_IVW_ENGINE_UNINI = 25000,  /* 引擎未初始化 */
    SPEECH_ERROR_IVW_RESVER_NOMATCH = 25001,  /* 资源版本不匹配 */
    SPEECH_ERROR_IVW_BUFFERED_AUDIOD_LITTLE = 25002,  /* 唤醒加识别缓存音频过少 */
    SPEECH_ERROR_IVW_INVALID_RESTYPE = 25003,  /* 不合法的资源类型 */

    /*Error Code Of ivw Engine*/
    SPEECH_ERROR_IVW_INVALID_CALL = 25101,   // IvwErr_InvCal       = 1					   
    SPEECH_ERROR_IVW_INVALID_ARG = 25102,   // IvwErr_InvArg	    = 2				    
    SPEECH_ERROR_IVW_TELL_SIZE = 25103,   // IvwErr_TellSize     = 3
    SPEECH_ERROR_IVW_OUT_OF_MEMORY = 25104,   // IvwErr_OutOfMemory  = 4			   
    SPEECH_ERROR_IVW_OUT_BUFFER_FULL = 25105,   // IvwErr_BufferFull	= 5
    SPEECH_ERROR_IVW_OUT_BUFFER_EMPTY = 25106,   // IvwErr_BufferEmpty	= 6			    
    SPEECH_ERROR_IVW_INVALID_RESOURCE = 25107,   // IvwErr_InvRes		= 7			  
    SPEECH_ERROR_IVW_REPETITIOPN_ENTER = 25108,   // IvwErr_ReEnter		= 8
    SPEECH_ERROR_IVW_NOT_SUPPORT = 25109,   // IvwErr_NotSupport	= 9			  
    SPEECH_ERROR_IVW_NOT_FOUND = 25110,   // IvwErr_NotFound		= 10		         
    SPEECH_ERROR_IVW_INVALID_SN = 25111,   // IvwErr_InvSN		= 11			    
    SPEECH_ERROR_IVW_LIMITTED = 25112,   // IvwErr_Limitted		= 12			    
    SPEECH_ERROR_IVW_TIME_OUT = 25113,   // IvwErr_TimeOut		= 13		         

    SPEECH_ERROR_IVW_ENROLL1_SUCESS = 25114,   // IvwErr_Enroll1_Success = 14             
    SPEECH_ERROR_IVW_ENROLL1_FAILED = 25115,   // IvwErr_Enroll1_Failed  = 15               
    SPEECH_ERROR_IVW_ENROLL2_SUCESS = 25116,   // IvwErr_Enroll2_Success = 16               
    SPEECH_ERROR_IVW_ENROLL2_FAILED = 25117,   // IvwErr_Enroll2_Failed  = 17              
    SPEECH_ERROR_IVW_ENROLL3_SUCESS = 25118,   // IvwErr_Enroll3_Success = 18             
    SPEECH_ERROR_IVW_ENROLL3_FAILED = 25119,   // IvwErr_Enroll3_Failed  = 19             
    SPEECH_ERROR_IVW_SPEECH_TOO_SHORT = 25120,   // IvwErr_SpeechTooShort  = 20            
    SPEECH_ERROR_IVW_SPEECH_STOP = 25121,   // IvwErr_SpeechStop      = 21             

    /* 非实时转写错误码:26000~26999 */
    SPEECH_ERROR_LFASR_BASE = 26000,    /* 非实时转写错误码基码 */
}
#region QISR
/// <summary>
/// 用来告知msc音频发送是否完成
/// </summary>
public enum AudioStatus
{
    MSP_AUDIO_SAMPLE_INIT = 0x00,
    MSP_AUDIO_SAMPLE_FIRST = 0x01, //第一块音频
    MSP_AUDIO_SAMPLE_CONTINUE = 0x02, //还有后继音频
    MSP_AUDIO_SAMPLE_LAST = 0x04, //最后一块音频
}
/// <summary>
/// 端点检测（End-point detected）器所处的状态
/// </summary>
public enum EpStatus
{
    MSP_EP_LOOKING_FOR_SPEECH = 0,    //还没有检测到音频的前端点
    MSP_EP_IN_SPEECH = 1,    //已经检测到了音频前端点,正在进行正常的音频处理
    MSP_EP_AFTER_SPEECH = 3,    //检测到音频的后端点,后记的音频会被msc忽略
    MSP_EP_TIMEOUT = 4,    //超时
    MSP_EP_ERROR = 5,    //出现错误
    MSP_EP_MAX_SPEECH = 6,    //音频过大
    MSP_EP_IDLE = 7,    // internal state after stop and before start
}
/// <summary>
/// 识别器返回的状态,提醒用户及时开始\停止获取识别结果
/// </summary>
public enum RecogStatus
{
    MSP_REC_STATUS_SUCCESS = 0,    //识别成功,此时用户可以调用QISRGetResult来获取(部分结果)
    MSP_REC_STATUS_NO_MATCH = 1,    //识别结束,没有识别结果
    MSP_REC_STATUS_INCOMPLETE = 2,    //未完成 正在识别中
    MSP_REC_STATUS_NON_SPEECH_DETECTED = 3,
    MSP_REC_STATUS_SPEECH_DETECTED = 4,
    MSP_REC_STATUS_COMPLETE = 5,    //识别结束
    MSP_REC_STATUS_MAX_CPU_TIME = 6,
    MSP_REC_STATUS_MAX_SPEECH = 7,
    MSP_REC_STATUS_STOPPED = 8,
    MSP_REC_STATUS_REJECTED = 9,
    MSP_REC_STATUS_NO_SPEECH_FOUND = 10,
    MSP_REC_STATUS_FAILURE = MSP_REC_STATUS_NO_MATCH,
}
#endregion

#region QTTS
/// <summary>
/// 合成状态
/// </summary>
public enum SynthStatus
{
    MSP_TTS_FLAG_CMD_CANCLEED = 0,
    MSP_TTS_FLAG_STILL_HAVE_DATA = 1,   //音频还没获取完 还有后续的音频
    MSP_TTS_FLAG_DATA_END = 2,   //音频已经获取完
}

/// <summary>
/// 语音音频头
/// </summary>
public struct WaveHeader
{
    public int RIFFID;
    public int FileSize;
    public int RIFFType;
    public int FMTID;
    public int FMTSize;
    public short FMTTag;
    public ushort FMTChannel;
    public int FMTSamplesPerSec;
    public int AvgBytesPerSec;
    public ushort BlockAlign;
    public ushort BitsPerSample;
    public int DataID;
    public int DataSize;
}
public enum TtsVoice
{
    XiaoYan,
    XuJiu,
    XiaoPing,
    XiaoJing,
    XuXiaoBao
}
#endregion