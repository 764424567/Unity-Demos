/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamManager.ExamCreatePaper
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：题目组件类
******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ExamComponent : MonoBehaviour
{
    private ExamManager m_ExamManager = null;
    private EventHandler<string> m_LoadEventHandler;
    private Transform ExamContent;// 题目的容器

    private ExamCreateParame ExamParme;

    void Awake()
    {
        m_ExamManager = new ExamManager();
        m_ExamManager.LoadEventHandler += LoadSucces;
    }

    void Start()
    {
        //LoadExam("Exam");
    }

    void Update()
    {
        m_ExamManager.Update(Time.deltaTime, Time.unscaledDeltaTime);
    }

    private void LoadSucces(object sender, string e)
    {
        switch (ExamParme.type)
        {
            case ExamCreateParame.Type.生成全部:
                CreateExam(ExamContent);
                break;
            case ExamCreateParame.Type.生成随机题目:
                CreateExam(ExamContent, (int)ExamParme.value);
                break;
            case ExamCreateParame.Type.生成int数组题目:
                CreateExam(ExamContent, (int)ExamParme.value);
                break;
            case ExamCreateParame.Type.生成string数组题目:
                CreateExam(ExamContent, (int)ExamParme.value);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 加载题目
    /// </summary>
    /// <param name="examExcelName">表名</param>
    public void LoadExam(string examExcelName)
    {
        m_ExamManager.LoadExam(examExcelName);
    }

    public void CreateExam(Transform Content, ExamCreateParame parme)
    {
        this.ExamContent = Content;
        this.ExamParme = parme;
    }

    /// <summary>
    /// 生成全部题目
    /// </summary>
    public void CreateExam(Transform Content)
    {
        m_ExamManager.CreateExam(Content);
    }

    /// <summary>
    /// 生成随机题目
    /// </summary>
    /// <param name="count">数量</param>
    public void CreateExam(Transform Content, int count)
    {
        m_ExamManager.CreateExam(Content, count);
    }

    /// <summary>
    /// 生成题目
    /// </summary>
    /// <param name="examList">传入的数组</param>
    public void CreateExam(Transform Content, int[] examList)
    {
        m_ExamManager.CreateExam(Content, examList);
    }

    /// <summary>
    /// 生成题目
    /// </summary>
    /// <param name="examList">传入的数组</param>
    public void CreateExam(Transform Content, string[] examList)
    {

        m_ExamManager.CreateExam(Content, examList);
    }

    /// <summary>
    /// 获取考题
    /// </summary>
    /// <param name="examName"></param>
    /// <returns></returns>
    public ExamBase GetExam(string examName)
    {
        return m_ExamManager.GetExam("Exam");
    }

    /// <summary>
    /// 获取考题
    /// </summary>
    /// <param name="examName"></param>
    /// <returns></returns>
    public List<ExamBase> GetExam()
    {
        return m_ExamManager.GetExam();
    }

    /// <summary>
    /// 清空选择题输入答案
    /// </summary>
    public void ClearAllInputAnswer()
    {
        m_ExamManager.ClearAllInputAnswer();
    }

    /// <summary>
    /// 清空考题
    /// </summary>
    public void ClearExam()
    {
        m_ExamManager.ClearExam();
    }
}