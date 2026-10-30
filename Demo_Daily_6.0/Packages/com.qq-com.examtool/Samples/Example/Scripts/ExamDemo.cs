using Com.Rainier.Buskit.Unity.Architecture.Injector;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ExamDemo : MonoBehaviour
{
    /// <summary>
    /// 当前考题
    /// </summary>
    protected Exam exam;

    private GameObject Content;

    void Start()
    {
        Content = GameObject.Find("Canvas").transform.Find("ExamContent").gameObject;

        StartCoroutine(LoadExam());
    }

    IEnumerator LoadExam()
    {
        yield return new WaitUntil(() => InjectService.Get<ExamManager>().GetExamCount() != 0);
        CreateAllExam();
    }

    /// <summary>
    /// 创建题目
    /// </summary>
    /// <param name="count">题目个数</param>
    /// <param name="isRandom">是否随机</param>
    public void CreateAllExam(int count = -1, bool isRandom = false)
    {
        int examCount;
        if (count == -1)
        {
            examCount = InjectService.Get<ExamManager>().GetExamCount();
        }
        else
        {
            examCount = count;
        }
        if (isRandom)
        {
            RandomExam(examCount, isRandom);
        }
        else
        {
            RandomExam(examCount, isRandom);
        }
    }

    /// <summary>
    /// 生成随机数量题目
    /// </summary>
    /// <param name="randomCount">生成题目的数量</param>
    public void RandomExam(int randomCount, bool isRandom)
    {
        List<int> randomList = new List<int>();
        if (isRandom)
        {
            System.Random rad = new System.Random(Random.Range(0, 1000));
            int examCount = InjectService.Get<ExamManager>().GetExamCount();
            if (randomCount < examCount / 2)
            {
                while (randomList.Count < randomCount)
                {
                    int number = rad.Next(1, examCount + 1);
                    if (!randomList.Contains(number))
                    {
                        randomList.Add(number);
                    }
                }
            }
            else
            {
                List<int> reversList = new List<int>();
                while (reversList.Count < examCount - randomCount)
                {
                    int number = rad.Next(1, examCount + 1);
                    if (!reversList.Contains(number))
                    {
                        reversList.Add(number);
                    }
                }
                for (int i = 1; i < examCount + 1; i++)
                {
                    if (!reversList.Contains(i))
                    {
                        randomList.Add(i);
                    }
                }
            }
        }
        else
        {
            for (int i = 1; i < randomCount + 1; i++)
            {
                randomList.Add(i);
            }
        }
        CreateExam(randomList.ToArray());
    }

    public void CreateExam(int[] examNames)
    {
        GameObject TopicSingle = Resources.Load<GameObject>("Prefabs/TopicSingle");
        GameObject TopicImageSingle = Resources.Load<GameObject>("Prefabs/TopicImageSingle");
        GameObject optionExtension = Resources.Load<GameObject>("Prefabs/OptionChoice");

        for (int i = 0; i < examNames.Length; i++)
        {
            Exam exam = InjectService.Get<ExamManager>().GetExam(examNames[i].ToString());
            if (exam == null)
                continue;

            GameObject tempTopic;
            if (exam.ExamType == ExamType.ImageXuanZe)
            {
                tempTopic = Instantiate(TopicImageSingle, Content.transform);
            }
            else
            {
                tempTopic = Instantiate(TopicSingle, Content.transform);
            }

            tempTopic.name = exam.ExamName;
            tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = (i+1)+".";

            GameObject extensionParent = tempTopic.transform.Find("OptionParent").gameObject;

            if (exam.ExamType == ExamType.XuanZeTi)
            {
                Choices choiceExam = exam as Choices;
                CreateOption(choiceExam, optionExtension, extensionParent);

                tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
                tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = "单选题";
            }
            if (exam.ExamType == ExamType.DuoXuanTi)
            {
                Choices choiceExam = exam as Choices;
                CreateOption(choiceExam, optionExtension, extensionParent);

                tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
                tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = "多选题";
            }
            else if (exam.ExamType == ExamType.ImageXuanZe)
            {
                Choices choiceExam = exam as Choices;

                List<string> temp = getArrayFromJson(choiceExam.ExamDetail);
                choiceExam.ExamDetail = choiceExam.ExamDetail.Replace(temp[0], "");

                tempTopic.transform.Find("ImageTitle").gameObject.SetActive(true);
                tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite = Resources.Load<Sprite>(temp[1]);

                CreateOption(choiceExam, optionExtension, extensionParent);
                tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
                tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = "单选题";
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Content.GetComponent<RectTransform>());
    }

    string StrStep(int index)
    {
        string[] Chinese = new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };
        return " 第" + Chinese[index] + "步：";
    }

    /// <summary>
    /// 创建选择题
    /// </summary>
    /// <param name="choiceExam">选择题数据</param>
    /// <param name="optionPrefab">预制体</param>
    /// <param name="optionParent">生成父节点</param>
    private void CreateOption(Choices choiceExam, GameObject optionPrefab, GameObject optionParent)
    {
        int correctCount = 0;
        List<Toggle> toggles = new List<Toggle>();
        for (int o = 0; o < choiceExam.Options.Count; o++)
        {
            if (choiceExam.Options[o].Answer)
                correctCount++;
            GameObject tempOption = Instantiate(optionPrefab, optionParent.transform);
            tempOption.transform.Find("OptionText").GetComponent<Text>().text = choiceExam.Options[o].OptionName;//choiceExam.ExamDetail;
            tempOption.transform.localScale = new Vector3(1, 1, 1);
            toggles.Add(tempOption.GetComponent<Toggle>());
        }
        if (correctCount <= 1)//单选
        {
            ToggleGroup group = optionParent.GetComponent<ToggleGroup>();
            group.allowSwitchOff = true;
            for (int t = 0; t < toggles.Count; t++)
            {
                toggles[t].group = group;
            }
            group.SetAllTogglesOff(false);
        }
    }

    /// <summary>
    /// 创建填空题
    /// </summary>
    private void CreateGap(InputExam inputExam, GameObject gapPrefab, GameObject inputParent)
    {
        for (int o = 0; o < inputExam.Options.Count; o++)
        {
            GameObject tempExtension = Instantiate(gapPrefab, inputParent.transform);
            tempExtension.name = o.ToString();
            tempExtension.transform.Find("Order").GetComponent<Text>().text = inputExam.Options[o].OptionName;//choiceExam.ExamDetail;
        }
    }

    private List<string> getArrayFromJson(string json)
    {
        List<string> lst = new List<string>();
        // 定义正则表达式用来匹配 img 标签            
        Regex regImg = new Regex("<img src=\"([^\"]*)\">", RegexOptions.IgnoreCase & RegexOptions.IgnorePatternWhitespace);
        // 搜索匹配的字符串
        MatchCollection matches = regImg.Matches(json);
        // 得到每个matches 中的字符串
        foreach (Match m in matches)
        {
            lst.Add(m.Value);
        }

        List<string> lst2 = new List<string>();
        // 定义正则表达式用来匹配 img 标签            
        Regex regImg2 = new Regex("\"([^\"]*)\"", RegexOptions.IgnoreCase & RegexOptions.IgnorePatternWhitespace);
        // 搜索匹配的字符串
        MatchCollection matches2 = regImg2.Matches(json);
        // 得到每个matches 中的字符串
        foreach (Match m in matches2)
        {
            lst2.Add(m.Value);
        }

        lst2[0] = lst2[0].Replace('"', ' ');
        lst2[0] = lst2[0].Trim();

        List<string> retList = new List<string>();
        retList.Add(lst[0]);
        retList.Add(lst2[0]);

        return retList;
    }

    /// <summary>
    /// 提交试卷，答题检测
    /// </summary>
    public int OnSubmit()
    {
        List<bool> optionInput = new List<bool>();
        List<string> gapInput = new List<string>();
        int score = 0;
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            Transform topic = Content.transform.GetChild(i);
            Image topicImg = topic.GetComponent<Image>();
            topicImg.enabled = true;
            try
            {
                Exam exam = InjectService.Get<ExamManager>().GetExam(topic.name);
                Transform extension = topic.transform.Find("OptionParent");
                if (exam.ExamType == ExamType.XuanZeTi)
                {
                    optionInput.Clear();
                    Toggle[] toggles = extension.GetComponentsInChildren<Toggle>();
                    Choices tempChoice = exam as Choices;
                    for (int t = 0; t < toggles.Length; t++)
                    {
                        optionInput.Add(toggles[t].isOn);
                    }
                    tempChoice.InputAnswer = optionInput;
                    topicImg.color = tempChoice.Answer ? Color.green : Color.red;
                    score += int.Parse(tempChoice.GetScore());
                }
                else if (exam.ExamType == ExamType.TianKongTi)
                {
                    gapInput.Clear();
                    InputField[] inputs = extension.GetComponentsInChildren<InputField>();
                    InputExam tempGap = exam as InputExam;
                    for (int t = 0; t < inputs.Length; t++)
                    {
                        gapInput.Add(inputs[t].text);
                    }
                    tempGap.InputAnswer = gapInput;
                    topicImg.color = tempGap.Answer ? Color.green : Color.red;
                    score += int.Parse(tempGap.GetScore());
                }
                else if (exam.ExamType == ExamType.DuoXuanTi)
                {
                    optionInput.Clear();
                    Toggle[] toggles = extension.GetComponentsInChildren<Toggle>();
                    Choices tempChoice = exam as Choices;
                    for (int t = 0; t < toggles.Length; t++)
                    {
                        optionInput.Add(toggles[t].isOn);
                    }
                    tempChoice.InputAnswer = optionInput;
                    topicImg.color = tempChoice.Answer ? Color.green : Color.red;
                    score += int.Parse(tempChoice.GetScore());
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("cant submit topic by:" + e);
                throw;
            }
        }
        Debug.Log("exam score:" + score.ToString());
        return score;
    }
}
