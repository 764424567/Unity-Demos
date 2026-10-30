using Excel;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class ReadExcel : Editor
{
    [MenuItem("Tools/读取考题Excel")]
    private static void WriteTotxt()
    {
        List<Exam> tmpChoices = ReadExcelToList();
        if (tmpChoices.Count != 0)
        {
            FileStream tmpFileStream = new FileStream(Application.streamingAssetsPath + "/Exam" + "/Exam.txt", FileMode.Create);
            StreamWriter tmpWriter = new StreamWriter(tmpFileStream);
            string jsonStr = JsonConvert.SerializeObject(tmpChoices);
            tmpWriter.Write(StringAndZip.StringToZip(jsonStr));
            tmpWriter.Flush();
            tmpWriter.Close();
            tmpFileStream.Close();
            Debug.Log("存储完毕");
        }
        else
        {
            Debug.Log("未读取到数据");
        }
    }

    private static List<Exam> ReadExcelToList()
    {
        List<Exam> examChoices = new List<Exam>();
        FileStream tmpFileStream = File.Open(Application.dataPath + "/Exam/Excel" + "/考题.xlsx", FileMode.Open, FileAccess.Read, FileShare.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(tmpFileStream);
        DataSet result = excelReader.AsDataSet();
        tmpFileStream.Close();
        excelReader.Close();
        int columns = result.Tables[0].Columns.Count;//列
        int rows = result.Tables[0].Rows.Count;//行
        for (int i = 1; i < rows; i++)//从第二行开始读
        {
            if (result.Tables[0].Rows[i][0].ToString() != string.Empty)
            {
                ExamType examType = ExamType.KaoTi;
                if (result.Tables[0].Rows[i][3].ToString().Equals("选择题"))
                {
                    examType = ExamType.XuanZeTi;
                    List<Option> options = new List<Option>();
                    for (int j = 4; j < columns; j += 2)//从第五列开始读
                    {
                        if (result.Tables[0].Rows[i][j].ToString() != string.Empty)
                        {
                            if (result.Tables[0].Rows[i][j + 1].ToString().ToUpper() == "TRUE")
                            {
                                options.Add(new Option(result.Tables[0].Rows[i][j].ToString(), true));
                            }
                            else if (result.Tables[0].Rows[i][j + 1].ToString().ToUpper() == "FALSE")
                            {
                                options.Add(new Option(result.Tables[0].Rows[i][j].ToString(), false));
                            }
                        }
                    }
                    Choices tmpChoice = new Choices(examType,
                        result.Tables[0].Rows[i][0].ToString(),
                        result.Tables[0].Rows[i][1].ToString(),
                        result.Tables[0].Rows[i][2].ToString(), options);
                    examChoices.Add(tmpChoice);
                    Debug.Log("选择题题号：" + result.Tables[0].Rows[i][0].ToString() + "存入");
                }
                else if (result.Tables[0].Rows[i][3].ToString().Equals("多选题"))
                {
                    examType = ExamType.DuoXuanTi;
                    List<Option> options = new List<Option>();
                    for (int j = 4; j < columns; j += 2)//从第五列开始读
                    {
                        if (result.Tables[0].Rows[i][j].ToString() != string.Empty)
                        {
                            if (result.Tables[0].Rows[i][j + 1].ToString().ToUpper() == "TRUE")
                            {
                                options.Add(new Option(result.Tables[0].Rows[i][j].ToString(), true));
                            }
                            else if (result.Tables[0].Rows[i][j + 1].ToString().ToUpper() == "FALSE")
                            {
                                options.Add(new Option(result.Tables[0].Rows[i][j].ToString(), false));
                            }
                        }
                    }
                    Choices tmpChoice = new Choices(examType,
                        result.Tables[0].Rows[i][0].ToString(),
                        result.Tables[0].Rows[i][1].ToString(),
                        result.Tables[0].Rows[i][2].ToString(), options);
                    examChoices.Add(tmpChoice);
                    Debug.Log("选择题题号：" + result.Tables[0].Rows[i][0].ToString() + "存入");
                }
                else if (result.Tables[0].Rows[i][3].ToString().Equals("填空题"))
                {
                    examType = ExamType.TianKongTi;
                    List<InputOption> options = new List<InputOption>();
                    for (int j = 4; j < columns; j += 2)//从第五列开始读
                    {
                        if (result.Tables[0].Rows[i][j].ToString() != string.Empty)
                        {
                            string[] tmpAswers = Regex.Split(result.Tables[0].Rows[i][j + 1].ToString(), "//", RegexOptions.IgnoreCase);
                            options.Add(new InputOption(result.Tables[0].Rows[i][j].ToString(), tmpAswers));
                        }
                    }
                    InputExam tmpChoice = new InputExam(examType,
                        result.Tables[0].Rows[i][0].ToString(),
                        result.Tables[0].Rows[i][1].ToString(),
                        result.Tables[0].Rows[i][2].ToString(), options);
                    examChoices.Add(tmpChoice);
                    Debug.Log("填空题题号：" + result.Tables[0].Rows[i][0].ToString() + "存入");
                }
                else if (result.Tables[0].Rows[i][3].ToString().Equals("图文单选题"))
                {
                    examType = ExamType.ImageXuanZe;
                    List<Option> options = new List<Option>();
                    for (int j = 4; j < columns; j += 2)//从第五列开始读
                    {
                        if (result.Tables[0].Rows[i][j].ToString() != string.Empty)
                        {
                            if (result.Tables[0].Rows[i][j + 1].ToString().ToUpper() == "TRUE")
                            {
                                options.Add(new Option(result.Tables[0].Rows[i][j].ToString(), true));
                            }
                            else if (result.Tables[0].Rows[i][j + 1].ToString().ToUpper() == "FALSE")
                            {
                                options.Add(new Option(result.Tables[0].Rows[i][j].ToString(), false));
                            }
                        }
                    }
                    Choices tmpChoice = new Choices(examType,
                        result.Tables[0].Rows[i][0].ToString(),
                        result.Tables[0].Rows[i][1].ToString(),
                        result.Tables[0].Rows[i][2].ToString(), options);
                    examChoices.Add(tmpChoice);
                    Debug.Log("选择题题号：" + result.Tables[0].Rows[i][0].ToString() + "存入");
                }
                else
                {
                    Debug.Log("考题类型错误无法存储题号： " + result.Tables[0].Rows[i][0].ToString() + "考题");
                }
            }
        }
        return examChoices;
    }
}