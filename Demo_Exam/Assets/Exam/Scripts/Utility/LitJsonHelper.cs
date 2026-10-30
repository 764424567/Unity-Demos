/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：IJsonHelper
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：LitJsonHelper Json解析实现类
******************************************************************************/

using Newtonsoft.Json.Linq;
using System;

public class LitJsonHelper : IJsonHelper<ExamBase>
{
    /// <summary>
    /// 根据数据类型实例化对应类
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="jObject"></param>
    /// <returns></returns>
    protected override ExamBase Create(Type objectType, JObject jObject)
    {
        if (FindData("ExamType", jObject, out string value))
        {
            if (value == "0"||value == "1" || value == "3" || value == "4" || value == "6")
            {
                return new ChoicesExam();
            }
            else if (value == "2" || value == "5")
            {
                return new InputExam();
            }
            else
            {
                return new ExamBase();
            }
        }
        else
        {
            return new ExamBase();
        }
    }

    /// <summary>
    /// 查找指定数据
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="jObject"></param>
    /// <param name="entityName"></param>
    /// <returns></returns>
    private bool FindData(string fieldName, JObject jObject, out string entityName)
    {
        entityName = jObject[fieldName] == null ? "" : jObject[fieldName].ToString();
        return jObject[fieldName] != null;
    }
}
