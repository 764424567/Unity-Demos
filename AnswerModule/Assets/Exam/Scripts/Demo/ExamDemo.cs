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
        Invoke("LoadExam", 0.5f);
        Content = GameObject.Find("Canvas").GetComponentInChildren<ScrollRect>().content.gameObject;

        //LoadExam();
    }

    private void LoadExam()
    {
        LoadExam("34");
        //CreateAllExam();
        //RandomExam(10);
    }

    public void LoadExam(string examName)
    {
        //exam = InjectService.Get<ExamManager>().GetExam(examName);
        //Choices choices = (Choices)exam;
        //Debug.Log("ExamName:" + choices.ExamName);
        //for (int i = 0; i < choices.Options.Count; i++)
        //{
        //    Debug.Log("OptionName:" + choices.Options[i].OptionName);
        //    Debug.Log("OptionAnswer:" + choices.Options[i].Answer);
        //}
        //Debug.Log("InputAnswer:" + choices.InputAnswer);
        //Debug.Log("ExamType:" + choices.ExamType);
        //Debug.Log("ExamScore:" + choices.ExamScore);
        //Debug.Log("AnswerScore:" + choices.AnswerScore);
        //Debug.Log("Answer:" + choices.Answer);

        GameObject TopicSingle = Resources.Load<GameObject>("Prefabs/TopicSingle");
        GameObject TopicImageSingle = Resources.Load<GameObject>("Prefabs/TopicImageSingle");
        GameObject optionExtension = Resources.Load<GameObject>("Prefabs/OptionChoice");
        GameObject gapExtension = Resources.Load<GameObject>("Prefabs/GapFilling");

        Exam exam = InjectService.Get<ExamManager>().GetExam(examName);
        GameObject tempTopic = Instantiate(TopicImageSingle, Content.transform);
        tempTopic.name = exam.ExamName;

        tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = "1";

        GameObject extensionParent = tempTopic.transform.Find("OptionParent").gameObject;

        if (exam.ExamType == ExamType.XuanZeTi)
        {
            Choices choiceExam = exam as Choices;

            List<string> temp = getArrayFromJson(choiceExam.ExamDetail);
            choiceExam.ExamDetail = choiceExam.ExamDetail.Replace(temp[0], "");

            tempTopic.transform.Find("ImageTitle").gameObject.SetActive(true);
            tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite = Resources.Load<Sprite>(temp[1]);

            CreateOption(choiceExam, optionExtension, extensionParent);
            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
        }
        else if (exam.ExamType == ExamType.TianKongTi)
        {
            InputExam inputExam = exam as InputExam;
            CreateGap(inputExam, gapExtension, extensionParent);
            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = inputExam.ExamDetail;
        }
        else if (exam.ExamType == ExamType.ImageXuanZe)
        {
            Choices choiceExam = exam as Choices;
            CreateOption(choiceExam, optionExtension, extensionParent);
            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Content.GetComponent<RectTransform>());
    }

    public List<string> getArrayFromJson(string json)
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

    public string getArrayFromSrc(string json)
    {
        List<string> lst = new List<string>();
        // 定义正则表达式用来匹配 img 标签            
        Regex regImg = new Regex("\"([^\"]*)\"", RegexOptions.IgnoreCase & RegexOptions.IgnorePatternWhitespace);
        // 搜索匹配的字符串
        MatchCollection matches = regImg.Matches(json);
        // 得到每个matches 中的字符串
        foreach (Match m in matches)
        {
            lst.Add(m.Value);
        }
        lst[0] = lst[0].Replace('"', ' ');
        lst[0] = lst[0].Trim();
        return lst[0];
    }

    public void CreateAllExam()
    {
        int examCount = InjectService.Get<ExamManager>().GetExamCount();
        RandomExam(examCount);
    }

    /// <summary>
    /// 生成随机数量题目
    /// </summary>
    /// <param name="randomCount">生成题目的数量</param>
    public void RandomExam(int randomCount)
    {
        System.Random rad = new System.Random(Random.Range(0, 1000));
        List<int> randomList = new List<int>();
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
        CreateExam(randomList.ToArray());
    }

    public void CreateExam(int[] examNames)
    {
        int examCount = InjectService.Get<ExamManager>().GetExamCount();
        GameObject TopicSingle = Resources.Load<GameObject>("Prefabs/TopicSingle");
        GameObject optionExtension = Resources.Load<GameObject>("Prefabs/OptionChoice");
        GameObject gapExtension = Resources.Load<GameObject>("Prefabs/GapFilling");
        for (int i = 0; i < examNames.Length; i++)
        {
            #region Create Exam Title
            Exam exam = InjectService.Get<ExamManager>().GetExam(examNames[i].ToString());
            if (exam == null)
                continue;
            GameObject tempTopic = Instantiate(TopicSingle, Content.transform);
            tempTopic.name = exam.ExamName;
            tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = (i + 1).ToString() + ".";
            #endregion
            GameObject extensionParent = tempTopic.transform.Find("OptionParent").gameObject;

            if (exam.ExamType == ExamType.XuanZeTi)
            {
                Choices choiceExam = exam as Choices;
                CreateOption(choiceExam, optionExtension, extensionParent);
                tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
            }
            else if (exam.ExamType == ExamType.TianKongTi)
            {
                InputExam inputExam = exam as InputExam;
                CreateGap(inputExam, gapExtension, extensionParent);
                tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = inputExam.ExamDetail;
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Content.GetComponent<RectTransform>());
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

    /// <summary>
    /// 提交试卷，答题检测
    /// </summary>
    public void OnSubmit()
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
            }
            catch (System.Exception e)
            {
                Debug.Log("cant submit topic by:" + e);
                throw;
            }
        }
        Debug.Log("exam score:" + score.ToString());
    }
}
