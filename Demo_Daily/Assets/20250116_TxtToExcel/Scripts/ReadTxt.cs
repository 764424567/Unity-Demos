using LitJson;
using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class ReadTxt : MonoBehaviour
{
    public TextAsset textTxt;

    void Start()
    {

        //CreateExcel();
        ReadTxtInfo();
    }

    void ReadTxtInfo()
    {
        Debug.Log(textTxt.text);
        string json = textTxt.text;

        //这里是解析，包括整形与字符串  
        JsonData jd = JsonMapper.ToObject(json);
        Debug.Log("tlogTraceId = " + (string)jd["headers"]["tlogTraceId"][0]);

        JsonData jdItems = jd["body"]["result"];
        List<string> items = new List<string>();
        foreach (var item in jdItems.Keys)
        {
            items.Add(item.ToString());
        }

        WriteExcel("名称","设备组", "设备ID");
        for (int j = 0; j < items.Count; j++)
        {
            JsonData item = jdItems[items[j]]["records"];
            Debug.Log(items[j]);
            for (int k = 0; k < item.Count; k++)
            {
                //Debug.Log("name = " + (string)item[k]["name"]);
                //Debug.Log("psrId = " + (string)item[k]["psrId"]);
                //WriteExcel(path,j+2,k+1, (string)item[k]["name"]);
                //WriteExcel(path,j+2,k+2, (string)item[k]["psrId"]);

                if (item[k].Keys.Contains("name"))
                {
                    WriteExcel((string)item[k]["name"], items[j],(string)item[k]["psrId"]);
                }
                else
                {
                    WriteExcel("", items[j],(string)item[k]["psrId"]);
                }
            }
        }
    }


    /// <summary>
    /// 创建表格
    /// </summary>
    private void CreateExcel()
    {
        string path = Application.dataPath + "/20250116_TxtToExcel/Info.xlsx";//读取文件
        Debug.Log(path);
        FileInfo newFile = new FileInfo(path);//创建新的Excel文件
        if (newFile.Exists)
        {
            newFile.Delete();
            newFile = new FileInfo(path);//创建新的Excel文件
        }
        ExcelPackage package = new ExcelPackage(newFile);
        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("潭王变电站站内设备列表");//创建工作簿
        worksheet.Cells[1, 1].Value = "Hello";//内容
        package.Save();//保存
    }

    /// <summary>
    /// 写入数据
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="value"></param>
    private void WriteExcel(string filePath,int row,int col,string value)
    {
        FileInfo _excelName = new FileInfo(filePath);
        using (ExcelPackage package = new ExcelPackage(_excelName))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["潭王变电站站内设备列表"];
            //修改某一行的数据
            worksheet.Cells[row, col].Value = value;
            //保存excel
            package.Save();
        }
    }

    /// <summary>
    /// 写入数据
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="value"></param>
    private void WriteExcel(string value1,string value2,string value3)
    {
        rowIndex++;
        Debug.Log(rowIndex);
        string filePath= Application.dataPath + "/20250116_TxtToExcel/Info.xlsx";
        FileInfo _excelName = new FileInfo(filePath);
        using (ExcelPackage package = new ExcelPackage(_excelName))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["潭王变电站站内设备列表"];
            //修改某一行的数据
            worksheet.Cells[rowIndex, 2].Value = value1;
            worksheet.Cells[rowIndex, 1].Value = value2;
            worksheet.Cells[rowIndex, 3].Value = value3;
            //保存excel
            package.Save();
        }
    }
    int rowIndex = 0;
}