using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExampleTTS : MonoBehaviour
{
    public AudioSource m_AudioSource; //播放音频
    public Button[] m_BtnPerson;      //切换人员
    public InputField m_InputVoice;   //语音文本
    public Button m_BtnPlay;          //播放按钮
    public Button m_BtnSave;          //保存按钮
    public Slider m_Slide;            //播放进度条
    public Text m_TextTime;           //播放的时间
    private bool onDrag = false;      //拖动的状态
    TtsVoice voicetype;
    public Text TextTips;             //提示文字

    void Start()
    {
        for (int i = 0; i < m_BtnPerson.Length; i++)
        {
            int index = i;
            m_BtnPerson[i].onClick.AddListener(() => BtnPersonEvent(index));
        }

        m_Slide.OnEventTriggerEvent(EventTriggerType.PointerDown, s =>
        {
            m_AudioSource.Pause();
            onDrag = true;
        });
        m_Slide.OnEventTriggerEvent(EventTriggerType.PointerUp, s =>
        {
            m_AudioSource.time = m_Slide.value * m_AudioSource.clip.length;
            m_AudioSource.Play();
            onDrag = false;
        });

        m_BtnPlay.onClick.AddListener(BtnPlayEvent);
        m_BtnSave.onClick.AddListener(BtnSaveEvent);

        voicetype = TtsVoice.XiaoYan;
    }

    void Update()
    {
        if (m_AudioSource.clip != null)
        {
            m_TextTime.text = string.Format("{0} / {1}", ToTimeFormat((float)m_AudioSource.time), ToTimeFormat((float)m_AudioSource.clip.length));
        }

        if (!onDrag)
        {
            if (m_AudioSource.time != 0 && m_AudioSource.clip.length != 0)
            {
                m_Slide.value = (float)(m_AudioSource.time / m_AudioSource.clip.length);
            }
        }
    }

    /// <summary>
    /// 切换朗读员
    /// </summary>
    /// <param name="index">朗读员按钮下标</param>
    int nextIndex = 0; // 上一次选择的朗读员
    void BtnPersonEvent(int index)
    {
        // 恢复上一个按钮的状态
        m_BtnPerson[nextIndex].transform.Find("Select").gameObject.SetActive(false);
        m_BtnPerson[nextIndex].GetComponentInChildren<Text>().color = Color.black;
        // 切换下一个按钮的状态
        nextIndex = index;
        m_BtnPerson[nextIndex].transform.Find("Select").gameObject.SetActive(true);
        m_BtnPerson[nextIndex].GetComponentInChildren<Text>().color = Color.blue;
        switch (index)
        {
            case 0:
                voicetype = TtsVoice.XiaoYan;
                break;
            case 1:
                voicetype = TtsVoice.XuJiu;
                break;
            case 2:
                voicetype = TtsVoice.XiaoPing;
                break;
            case 3:
                voicetype = TtsVoice.XiaoJing;
                break;
            case 4:
                voicetype = TtsVoice.XuXiaoBao;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 按钮播放事件
    /// </summary>
    void BtnPlayEvent()
    {
        if (m_InputVoice.text == "")
        {
            TextTips.text = "未输入文本";
            return;
        }
        CreateVoice(voicetype, () =>
        {
            TextTips.text = "";
            m_AudioSource.Play();
        });
    }

    /// <summary>
    /// 按钮保存事件
    /// </summary>
    void BtnSaveEvent()
    {
        if (m_InputVoice.text == "")
        {
            TextTips.text = "未输入文本";
            return;
        }
        //使用时间戳作为文件名
        string path = Path.Combine(Application.streamingAssetsPath, DateTime.Now.Ticks + ".mp3");
        CreateVoice(path, () =>
        {
            // 保存
            TextTips.text = "保存成功，路径：" + path;
        });
    }

    /// <summary>
    /// 创建音频
    /// </summary>
    void CreateVoice(TtsVoice voice, Action action)
    {
        StartCoroutine(TtsCoroutine(voice, action));
    }

    /// <summary>
    /// 创建音频
    /// </summary>
    void CreateVoice(string path, Action action)
    {
        StartCoroutine(TtsCoroutine(path, action));
    }

    IEnumerator TtsCoroutine(TtsVoice voice, Action action)
    {
        TextTips.text = "生成中，请稍后。。。";
        m_AudioSource.clip = null;
        yield return new WaitForSeconds(0.1f);
        m_AudioSource.clip = Speech.Tts(m_InputVoice.text, voice);
        bool isFinish = m_AudioSource.clip;
        yield return new WaitUntil(() => isFinish);
        action?.Invoke();
    }

    IEnumerator TtsCoroutine(string path, Action action)
    {
        TextTips.text = "生成中，请稍后。。。";
        yield return new WaitForSeconds(0.1f);
        bool isFinsh = Speech.Tts(m_InputVoice.text, path);
        yield return new WaitUntil(() => isFinsh);
        action?.Invoke();
    }

    //时长用00：00显示
    public string ToTimeFormat(float time)
    {
        int seconds = (int)time;
        int minutes = seconds / 60;
        seconds %= 60;
        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}