using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 考题类反序列化规则
/// </summary>
public class ExamConverter : DATACreationConverter<Exam>
{
    /// <summary>
    /// 根据数据类型实例化对应类
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="jObject"></param>
    /// <returns></returns>
    protected override Exam Create(Type objectType, JObject jObject)
    {
        if (FindData("ExamType", jObject, out string value))
        {
            if (value == "1")
            {
                return new Choices();
            }
            else if (value == "2")
            {
                return new InputExam();
            }
            else
            {
                return new Exam();
            }
        }
        else
        {
            return new Exam();
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

public abstract class DATACreationConverter<T> : JsonConverter
{
    protected abstract T Create(Type objectType, JObject jObject);

    public override bool CanConvert(Type objectType)
    {
        return typeof(T).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jObject = JObject.Load(reader);
        T target = Create(objectType, jObject);
        serializer.Populate(jObject.CreateReader(), target);
        return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
