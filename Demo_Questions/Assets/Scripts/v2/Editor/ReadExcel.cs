using Excel;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class ReadExcel : EditorWindow
{
    /// <summary>
    /// 当前编辑器窗口实例
    /// </summary>
    private static ReadExcel instance;

    /// <summary>
    /// Excel文件列表
    /// </summary>
    private static List<string> excelList;

    /// <summary>
    /// 项目根路径	
    /// </summary>
    private static string pathRoot;

    /// <summary>
    /// 滚动窗口初始位置
    /// </summary>
    private static Vector2 scrollPos;

    /// <summary>
    /// 是否保留原始文件
    /// </summary>
    private static bool keepSource = true;

    /// <summary>
    /// 显示当前窗口	
    /// </summary>
    [MenuItem("Plugins/读取Excel题目加密转成txt")]
    static void ShowExcelTools()
    {
        Init();
        //加载Excel文件
        LoadExcel();
        instance.Show();
    }

    void OnGUI()
    {
        DrawExport();
    }

    /// <summary>
    /// 绘制插件界面输出项
    /// </summary>
    private void DrawExport()
    {
        if (excelList == null) return;
        if (excelList.Count < 1)
        {
            EditorGUILayout.LabelField("目前没有Excel文件被选中哦!");
        }
        else
        {
            keepSource = GUILayout.Toggle(keepSource, "保留Excel源文件");

            EditorGUILayout.LabelField("下列项目将被加密转换为Txt:");
            foreach (string s in excelList)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Toggle(true, s);
                GUILayout.EndHorizontal();
            }

            EditorGUILayout.LabelField("输出路径:");
            foreach (string s in excelList)
            {
                int pathIndex = s.LastIndexOf('/');
                string outPath = s.Substring(pathIndex, s.Length- pathIndex - 1);
                outPath = outPath.Replace(".xlsx", ".csv");
                outPath = Application.streamingAssetsPath + outPath;
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(outPath);
                GUILayout.EndHorizontal();
            }

            //输出
            if (GUILayout.Button("加密转换"))
            {
                ConvertEncryptTxt();
            }
        }
    }

    private void ConvertEncryptTxt()
    {
        foreach (string  assetsPath in excelList)
        {
            //获得Excel的路径
            string excelPath = pathRoot + "/" + assetsPath;
            List<Exam> tmpChoices = ReadExcelToList(excelPath);
            if (tmpChoices.Count != 0)
            {
                int pathIndex = excelPath.LastIndexOf('/');
                string outPath = excelPath.Substring(pathIndex, excelPath.Length - pathIndex - 1);
                outPath = outPath.Replace(".xlsx", ".csv");
                outPath = Application.streamingAssetsPath+ outPath;
                FileStream tmpFileStream = new FileStream(outPath, FileMode.Create);
                StreamWriter tmpWriter = new StreamWriter(tmpFileStream);
                string jsonStr = JsonConvert.SerializeObject(tmpChoices);
                tmpWriter.Write(StringAndZip.StringToZip(jsonStr));
                tmpWriter.Flush();
                tmpWriter.Close();
                tmpFileStream.Close();
                Debug.Log("存储完毕");
            }
            //判断是否保留源文件
            if (!keepSource)
            {
                FileUtil.DeleteFileOrDirectory(excelPath);
            }

            //刷新本地资源
            AssetDatabase.Refresh();
        }
        //关闭窗口
        //instance.Close();
    }

    private List<Exam> ReadExcelToList(string path)
    {
        List<Exam> examChoices = new List<Exam>();
        FileStream tmpFileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
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
                Debug.Log(result.Tables[0].Rows[i][1].ToString());
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
                    //Debug.Log("选择题题号：" + result.Tables[0].Rows[i][0].ToString() + "存入");
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
                else
                {
                    Debug.Log("考题类型错误无法存储题号： " + result.Tables[0].Rows[i][0].ToString() + "考题");
                }
            }
        }
        return examChoices;
    }

    /// <summary>
    /// 加载Excel
    /// </summary>
    private static void LoadExcel()
    {
        if (excelList == null) excelList = new List<string>();
        excelList.Clear();
        //获取选中的对象
        object[] selection = (object[])Selection.objects;
        //判断是否有对象被选中
        if (selection.Length == 0)
            return;
        //遍历每一个对象判断不是Excel文件
        foreach (Object obj in selection)
        {
            string objPath = AssetDatabase.GetAssetPath(obj);
            if (objPath.EndsWith(".xlsx"))
            {
                excelList.Add(objPath);
            }
        }
    }

    private static void Init()
    {
        //获取当前实例
        instance = EditorWindow.GetWindow<ReadExcel>();
        //初始化
        pathRoot = Application.dataPath;
        //这里需要对路径进行处理
        pathRoot = pathRoot.Substring(0, pathRoot.LastIndexOf("/"));
        excelList = new List<string>();
        scrollPos = new Vector2(instance.position.x, instance.position.y + 75);
    }

    void OnSelectionChange()
    {
        //当选择发生变化时重绘窗体
        Show();
        LoadExcel();
        Repaint();
    }
}