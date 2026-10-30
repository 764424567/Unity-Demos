using Excel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsItem
{
    public string Topic;
    public string Option;
    public string Answer;
    public string Type;
    public string Score;
}
public class QuesionsControl : MonoBehaviour
{
    /// <summary>
    /// 创建题目
    /// </summary>
    /// <param name="questions">题目数据</param>
    /// <param name="Content">题目父物体容器</param>
    /// <param name="Index">题目下标</param>
    /// <param name="IndexShow">题目Title显示下标</param>
    /// <param name="type">题目类型</param>
    public void CreateQuestion(GameObject Content, int Index, string IndexShow)
    {
        QuestionsItem[] questions = ReturnQuestionsExcel();
        Dictionary<int, GameObject> QuestionsList = new Dictionary<int, GameObject>();
        GameObject TopicSingle = Resources.Load<GameObject>("v1/Prefabs/TopicSingle");
        GameObject OptionChoice = Resources.Load<GameObject>("v1/Prefabs/OptionChoice");
        string type = "";
        foreach (QuestionsItem topic in questions)
        {
            if (topic.Topic != null && topic.Topic != "" && topic.Topic.Split('_')[0] == Index.ToString())
            {
                GameObject tempTopic = Instantiate(TopicSingle);
                tempTopic.transform.Find("Title").GetComponent<Text>().text = IndexShow + topic.Topic.Split('_')[1];
                tempTopic.transform.SetParent(Content.transform);
                tempTopic.transform.localScale = new Vector3(1, 1, 1);
                QuestionsList.Add(Index, tempTopic);
                AnswerStatus answer = tempTopic.transform.Find("OptionParent").gameObject.AddComponent<AnswerStatus>();
                answer.Grade = float.Parse(topic.Score.Split('_')[1]);
                answer.CorrectText = topic.Answer.Split('_')[1];
                answer.title = IndexShow + topic.Topic.Split('_')[1];
                answer.Options = new List<Toggle>();
            }
            if (topic.Type != null && topic.Type != "" && topic.Type.Split('_')[0] == Index.ToString())
            {
                type = topic.Type.Split('_')[1];
            }
            if (topic.Option.Split('_')[0] == Index.ToString())
            {
                if (type == "单选题")
                {
                    GameObject tempOption = Instantiate(OptionChoice);
                    tempOption.transform.Find("OptionClick").name = topic.Option.Split('_')[0] + topic.Option.Split('_')[1].Split('.')[0];
                    tempOption.transform.Find("Text").GetComponent<Text>().text = topic.Option.Split('_')[1].Replace(" ", "");
                    GameObject OptionParent = QuestionsList[Index].transform.Find("OptionParent").gameObject;
                    tempOption.transform.SetParent(OptionParent.transform);
                    tempOption.transform.localScale = new Vector3(1, 1, 1);
                    tempOption.GetComponent<Toggle>().group = OptionParent.GetComponent<ToggleGroup>();
                    tempOption.GetComponentInParent<AnswerStatus>().Options.Add(tempOption.GetComponent<Toggle>());
                }
                else if (type == "多选题")
                {
                    GameObject tempOption = Instantiate(OptionChoice);
                    tempOption.transform.Find("OptionClick").name = topic.Option.Split('_')[0] + topic.Option.Split('_')[1].Split('.')[0];
                    tempOption.transform.Find("Text").GetComponent<Text>().text = topic.Option.Split('_')[1].Replace(" ", "");
                    GameObject OptionParent = QuestionsList[Index].transform.Find("OptionParent").gameObject;
                    tempOption.transform.SetParent(OptionParent.transform);
                    tempOption.transform.localScale = new Vector3(1, 1, 1);
                    tempOption.GetComponentInParent<AnswerStatus>().Options.Add(tempOption.GetComponent<Toggle>());
                }
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Content.GetComponent<RectTransform>());
    }

    //题目数据
    private QuestionsItem[] questionsItem;
    /// <summary>
    /// 返回所有题目数据
    /// </summary>
    /// <returns>题目数据</returns>
    private QuestionsItem[] ReturnQuestionsExcel()
    {
        if (questionsItem == null)
        {
            string path = Application.streamingAssetsPath + "/v1/Topic.xlsx";
            questionsItem = ReadQuestionsExcel(path);
            return questionsItem;
        }
        else
        {
            return questionsItem;
        }
    }

    /// <summary>
    /// 读取Excel表中的题目数据
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>题目数据</returns>
    private static QuestionsItem[] ReadQuestionsExcel(string filePath)
    {
        //获得表数据
        int columnNum = 0, rowNum = 0;
        DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

        //根据excel的定义，第二行开始才是数据
        QuestionsItem[] array = new QuestionsItem[rowNum - 1];
        for (int i = 1; i < rowNum; i++)
        {
            QuestionsItem item = new QuestionsItem();
            //解析每列的数据
            item.Topic = collect[i][0].ToString();
            item.Option = collect[i][1].ToString();
            item.Answer = collect[i][2].ToString();
            item.Type = collect[i][3].ToString();
            item.Score = collect[i][4].ToString();
            array[i - 1] = item;
        }
        return array;
    }

    /// <summary>
    /// 读取Excel文件内容
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="columnNum">行数</param>
    /// <param name="rowNum">列数</param>
    /// <returns>表数据对象</returns>
    private static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
    {
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();
        //Tables[0] 下标0表示excel文件中第一张表的数据
        columnNum = result.Tables[0].Columns.Count;
        rowNum = result.Tables[0].Rows.Count;
        return result.Tables[0].Rows;
    }
}
