/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamManager.ExamCreatePaper
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：生成题目处理类
******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public partial class ExamManager
{
    public sealed class ExamCreatePaper
    {
        public delegate void CreateCallbacks(string value);

        private readonly ExamManager m_ExamManager;
        private readonly CreateCallbacks m_CreateCallbacks;

        private List<GameObject> m_TopicList;
        private int m_ExamScore;
        private Transform ExamContent;// 题目的容器

        /// <summary>
        /// 初始化加载资源器的新实例。
        /// </summary>
        /// <param name="resourceManager">资源管理器。</param>
        public ExamCreatePaper(ExamManager examManager)
        {
            m_ExamManager = examManager;
            m_CreateCallbacks = new CreateCallbacks(OnCreateSuccess);

            m_TopicList = new List<GameObject>();
        }

        public int ExamScore
        {
            get
            {
                return m_ExamScore;
            }
            set
            {
                m_ExamScore = value;
            }
        }

        private void OnCreateSuccess(string value)
        {
            m_LoadEventHandler(this, value);
        }

        /// <summary>
        /// 生成全部题目
        /// </summary>
        public void CreateExam(Transform Content)
        {
            this.ExamContent = Content;

            List<ExamBase> exams = m_ExamManager.GetExam();
            for (int i = 0; i < exams.Count; i++)
            {
                CreateExamHandle(exams[i].ExamName);
            }
        }

        /// <summary>
        /// 生成随机题目
        /// </summary>
        /// <param name="count">数量</param>
        public void CreateExam(Transform Content,int count)
        {
            this.ExamContent = Content;

            List<int> randomList = new List<int>();
            System.Random rad = new System.Random(UnityEngine.Random.Range(0, 1000));
            int examCount = m_ExamManager.ExamCount;
            if (count < examCount / 2)
            {
                while (randomList.Count < count)
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
                while (reversList.Count < examCount - count)
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
            List<ExamBase> exams = m_ExamManager.GetExam();
            for (int i = 0; i < randomList.Count; i++)
            {
                CreateExamHandle(exams[randomList[i]].ExamName);
            }
        }

        /// <summary>
        /// 生成题目
        /// </summary>
        /// <param name="examList">传入的数组</param>
        public void CreateExam(Transform Content,int[] examList)
        {
            this.ExamContent = Content;

            List<ExamBase> exams = m_ExamManager.GetExam();
            for (int i = 0; i < examList.Length; i++)
            {
                CreateExamHandle(exams[examList[i]].ExamName);
            }
        }

        /// <summary>
        /// 生成题目
        /// </summary>
        /// <param name="examList">传入的数组</param>
        public void CreateExam(Transform Content, string[] examList)
        {
            this.ExamContent = Content;

            for (int i = 0; i < examList.Length; i++)
            {
                CreateExamHandle(examList[i]);
            }
        }

        int serialIndex = 0;
        /// <summary>
        /// 生成题目辅助器
        /// </summary>
        /// <param name="examNames">题目名</param>
        /// <param name="identifier">序号标识符</param>
        private void CreateExamHandle(string examNames, string identifier = "、")
        {
            GameObject TopicSingle = Resources.Load<GameObject>("Prefabs/TopicSingle");//题干
            GameObject TopicImageSingle = Resources.Load<GameObject>("Prefabs/TopicImageSingle");// 图文选择题 题干
            GameObject choicesOption = Resources.Load<GameObject>("Prefabs/choicesOption");// 单选 选项
            GameObject gapOption = Resources.Load<GameObject>("Prefabs/gapOption");// 填空 选项

            ExamBase exam = m_ExamManager.GetExam(examNames);

            GameObject tempTopic = null;//题目对象
            serialIndex++;
            switch (exam.ExamType)
            {
                case ExamType.KaoTi:
                    tempTopic = CreateChoice(exam, TopicSingle, choicesOption, serialIndex + identifier);
                    break;
                case ExamType.XuanZeTi:
                    tempTopic = CreateChoice(exam, TopicSingle, choicesOption, serialIndex + identifier);
                    break;
                case ExamType.TianKongTi:
                    tempTopic = CreateGap(exam, TopicSingle, gapOption, serialIndex + identifier);
                    break;
                case ExamType.DuoXuanTi:
                    tempTopic = CreateChoice(exam, TopicSingle, choicesOption, serialIndex + identifier);
                    break;
                case ExamType.ImageXuanZe:
                    tempTopic = CreateChoiceImage(exam, TopicImageSingle, choicesOption, serialIndex + identifier);
                    break;
                case ExamType.ImageTianKong:
                    tempTopic = CreateGapImage(exam, TopicImageSingle, gapOption, serialIndex + identifier);
                    break;
                case ExamType.ImageDuoXuan:
                    tempTopic = CreateChoiceImage(exam, TopicImageSingle, choicesOption, serialIndex + identifier);
                    break;
            }

            m_TopicList.Add(tempTopic);

            LayoutRebuilder.ForceRebuildLayoutImmediate(ExamContent.GetComponent<RectTransform>());
        }

        /// <summary>
        /// 创建选择题
        /// </summary>
        private GameObject CreateChoice(ExamBase exam, GameObject choicePrefab, GameObject optionPrefab, string serial)
        {
            ChoicesExam choiceExam = exam as ChoicesExam;

            GameObject tempTopic = GameObject.Instantiate(choicePrefab, ExamContent);

            tempTopic.name = exam.ExamName;
            tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = serial;

            GameObject OptionParent = tempTopic.transform.Find("OptionParent").gameObject;
            CreateChoiceOption(choiceExam, optionPrefab, OptionParent);

            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
            tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = getExamType(choiceExam.ExamType);

            return tempTopic;
        }

        /// <summary>
        /// 创建选择题选项
        /// </summary>
        /// <param name="choiceExam">选择题数据</param>
        /// <param name="optionPrefab">预制体</param>
        /// <param name="optionParent">生成父节点</param>
        private void CreateChoiceOption(ChoicesExam choiceExam, GameObject optionPrefab, GameObject optionParent)
        {
            int correctCount = 0;
            List<Toggle> toggles = new List<Toggle>();
            for (int o = 0; o < choiceExam.Options.Count; o++)
            {
                if (choiceExam.Options[o].Answer)
                    correctCount++;
                GameObject tempOption = GameObject.Instantiate(optionPrefab, optionParent.transform);
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
        /// <param name="exam"></param>
        /// <param name="choicePrefab"></param>
        /// <param name="choiceParent"></param>
        /// <param name="optionPrefab"></param>
        /// <returns></returns>
        private GameObject CreateGap(ExamBase exam, GameObject gapPrefab, GameObject optionPrefab, string serial)
        {
            InputExam inputExam = exam as InputExam;

            GameObject tempTopic = GameObject.Instantiate(gapPrefab, ExamContent);

            tempTopic.name = exam.ExamName;
            tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = serial;

            GameObject OptionParent = tempTopic.transform.Find("OptionParent").gameObject;
            CreateGapOption(inputExam, optionPrefab, OptionParent);

            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = inputExam.ExamDetail;
            tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = getExamType(inputExam.ExamType);

            return tempTopic;
        }

        /// <summary>
        /// 创建填空题选项
        /// </summary>
        private void CreateGapOption(InputExam inputExam, GameObject gapPrefab, GameObject inputParent)
        {
            for (int o = 0; o < inputExam.Options.Count; o++)
            {
                GameObject tempExtension = GameObject.Instantiate(gapPrefab, inputParent.transform);
                tempExtension.name = o.ToString();
                tempExtension.transform.Find("Order").GetComponent<Text>().text = inputExam.Options[o].OptionName;//choiceExam.ExamDetail;
            }
        }

        /// <summary>
        /// 创建图文选择题
        /// </summary>
        private GameObject CreateChoiceImage(ExamBase exam, GameObject choicePrefab, GameObject optionPrefab, string serial)
        {
            ChoicesExam choiceExam = exam as ChoicesExam;

            GameObject tempTopic = GameObject.Instantiate(choicePrefab, ExamContent);

            tempTopic.name = exam.ExamName;
            tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = serial;

            List<string> temp = getArrayFromJson(choiceExam.ExamDetail);
            choiceExam.ExamDetail = choiceExam.ExamDetail.Replace(temp[0], "");

            tempTopic.transform.Find("ImageTitle").gameObject.SetActive(true);
            tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite = Resources.Load<Sprite>(temp[1]);
            tempTopic.transform.Find("ImageTitle").GetComponent<Image>().rectTransform.sizeDelta = new Vector2(
                tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite.rect.width,
                tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite.rect.height);

            GameObject OptionParent = tempTopic.transform.Find("OptionParent").gameObject;
            CreateChoiceOption(choiceExam, optionPrefab, OptionParent);

            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = choiceExam.ExamDetail;
            tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = getExamType(choiceExam.ExamType);

            return tempTopic;
        }

        /// <summary>
        /// 创建填空题
        /// </summary>
        /// <param name="exam"></param>
        /// <param name="choicePrefab"></param>
        /// <param name="choiceParent"></param>
        /// <param name="optionPrefab"></param>
        /// <returns></returns>
        private GameObject CreateGapImage(ExamBase exam, GameObject gapPrefab, GameObject optionPrefab, string serial)
        {
            InputExam inputExam = exam as InputExam;

            GameObject tempTopic = GameObject.Instantiate(gapPrefab, ExamContent);

            tempTopic.name = exam.ExamName;
            tempTopic.transform.Find("TitleParent").Find("Order").GetComponent<Text>().text = serial;

            List<string> temp = getArrayFromJson(inputExam.ExamDetail);
            inputExam.ExamDetail = inputExam.ExamDetail.Replace(temp[0], "");

            tempTopic.transform.Find("ImageTitle").gameObject.SetActive(true);
            tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite = Resources.Load<Sprite>(temp[1]);
            tempTopic.transform.Find("ImageTitle").GetComponent<Image>().rectTransform.sizeDelta = new Vector2(
                tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite.rect.width,
                tempTopic.transform.Find("ImageTitle").GetComponent<Image>().sprite.rect.height);

            GameObject OptionParent = tempTopic.transform.Find("OptionParent").gameObject;
            CreateGapOption(inputExam, optionPrefab, OptionParent);

            tempTopic.transform.Find("TitleParent").Find("Title").GetComponent<Text>().text = inputExam.ExamDetail;
            tempTopic.transform.Find("TitleParent").Find("Image").Find("TextType").GetComponent<Text>().text = getExamType(inputExam.ExamType);

            return tempTopic;
        }

        /// <summary>
        /// 获得题目类型名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string getExamType(ExamType type)
        {
            string str = "";
            switch (type)
            {
                case ExamType.KaoTi:
                    str = "考题";
                    break;
                case ExamType.XuanZeTi:
                    str = "单选题";
                    break;
                case ExamType.TianKongTi:
                    str = "填空题";
                    break;
                case ExamType.DuoXuanTi:
                    str = "多选题";
                    break;
                case ExamType.ImageXuanZe:
                    str = "图文选择题";
                    break;
                case ExamType.ImageTianKong:
                    str = "图文填空题";
                    break;
                case ExamType.ImageDuoXuan:
                    str = "图文多选题";
                    break;
                default:
                    break;
            }
            return str;
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
            for (int i = 0; i < m_TopicList.Count; i++)
            {
                Transform topic = m_TopicList[i].transform;
                Image topicImg = topic.GetComponent<Image>();
                topicImg.enabled = true;
                try
                {
                    ExamBase exam = m_ExamManager.GetExam(topic.name);
                    Transform extension = topic.transform.Find("OptionParent");
                    if (exam.ExamType == ExamType.XuanZeTi)
                    {
                        optionInput.Clear();
                        Toggle[] toggles = extension.GetComponentsInChildren<Toggle>();
                        ChoicesExam tempChoice = exam as ChoicesExam;
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
                        ChoicesExam tempChoice = exam as ChoicesExam;
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
}