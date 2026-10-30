/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ReadStepInforExcel
* 创建日期：2021-04-28 09:00:09
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：读取实验步骤信息Excel
******************************************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.IO;
using Excel;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class ReadStepInforExcel : Editor 
	{

        [MenuItem("Tools/读取步骤信息Excel")]
        private static void WriteTotxt()
        {
            List<WebStepInfor> tmpChoices = ReadExcelToList();
            if (tmpChoices.Count != 0)
            {
                FileStream tmpFileStream = new FileStream(Application.streamingAssetsPath + "/StepInfor" + "/StepInfor.txt", FileMode.Create);
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

        private static List<WebStepInfor> ReadExcelToList()
        {
            List<WebStepInfor> stepInfors = new List<WebStepInfor>();
            FileStream tmpFileStream = File.Open(Application.dataPath + "/Excel" + "/步骤信息.xls", FileMode.Open, FileAccess.Read, FileShare.Read);
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
                    WebStepInfor tmpWebStepInfor = new WebStepInfor(result.Tables[0].Rows[i][1].ToString(),
                        Convert.ToInt32(result.Tables[0].Rows[i][0].ToString()), result.Tables[0].Rows[i][2].ToString(),
                        Convert.ToInt32(result.Tables[0].Rows[i][3].ToString()), Convert.ToInt32(result.Tables[0].Rows[i][4].ToString()),
                        result.Tables[0].Rows[i][5].ToString(), result.Tables[0].Rows[i][6].ToString(),
                        result.Tables[0].Rows[i][7].ToString());

                    stepInfors.Add(tmpWebStepInfor);
                    Debug.Log("步骤：" + result.Tables[0].Rows[i][0].ToString() + "存入");
                }
            }
            return stepInfors;
        }
    }
}

