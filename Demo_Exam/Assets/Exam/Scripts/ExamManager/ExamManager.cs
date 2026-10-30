/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamManager.ExamCreatePaper
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：题目管理类
******************************************************************************/

using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ExamManager
{
    private readonly ExamCreatePaper m_ExamCreatePaper;
    private readonly ExamLoader m_ExamLoader;

    private static EventHandler<string> m_LoadEventHandler;
    private static EventHandler<string> m_CreateEventHandler;


    public ExamManager()
    {
        m_ExamCreatePaper = new ExamCreatePaper(this);
        m_ExamLoader = new ExamLoader(this);
    }

    public void Update(float elapseSeconds, float realElapseSeconds)
    {
        m_ExamLoader.Update();
    }

    /// <summary>
    /// 加载事件。
    /// </summary>
    public event EventHandler<string> LoadEventHandler
    {
        add
        {
            m_LoadEventHandler += value;
        }
        remove
        {
            m_LoadEventHandler -= value;
        }
    }

    /// <summary>
    /// 创建题目事件。
    /// </summary>
    public event EventHandler<string> CreateEventHandler
    {
        add
        {
            m_CreateEventHandler += value;
        }
        remove
        {
            m_CreateEventHandler -= value;
        }
    }

    /// <summary>
    /// 获取或设置分数。
    /// </summary>
    public int ExamScore
    {
        get
        {
            return m_ExamCreatePaper.ExamScore;
        }
        set
        {
            m_ExamCreatePaper.ExamScore = value;
        }
    }

    /// <summary>
    /// 获取或设置题目数量。
    /// </summary>
    public int ExamCount
    {
        get
        {
            return m_ExamLoader.ExamCount;
        }
        set
        {
            m_ExamLoader.ExamCount = value;
        }
    }

    /// <summary>
    /// 加载题目
    /// </summary>
    public void LoadExam(string examName)
    {
        m_ExamLoader.AddLoadAgent(examName);
    }

    /// <summary>
    /// 生成全部题目
    /// </summary>
    public void CreateExam(Transform Content)
    {
        m_ExamCreatePaper.CreateExam(Content);
    }

    /// <summary>
    /// 生成随机题目
    /// </summary>
    /// <param name="count">数量</param>
    public void CreateExam(Transform Content,int count)
    {
        m_ExamCreatePaper.CreateExam(Content,count);
    }

    /// <summary>
    /// 生成题目
    /// </summary>
    /// <param name="examList">传入的数组</param>
    public void CreateExam(Transform Content, int[] examList)
    {
        m_ExamCreatePaper.CreateExam(Content, examList);
    }

    /// <summary>
    /// 生成题目
    /// </summary>
    /// <param name="examList">传入的数组</param>
    public void CreateExam(Transform Content, string[] examList)
    {
        m_ExamCreatePaper.CreateExam(Content, examList);
    }

    /// <summary>
    /// 获取考题
    /// </summary>
    /// <param name="examName"></param>
    /// <returns></returns>
    public ExamBase GetExam(string examName)
    {
        return m_ExamLoader.GetExam(examName);
    }

    /// <summary>
    /// 获取考题
    /// </summary>
    /// <param name="examName"></param>
    /// <returns></returns>
    public List<ExamBase> GetExam()
    {
        return m_ExamLoader.Exam;
    }

    /// <summary>
    /// 清空选择题输入答案
    /// </summary>
    public void ClearAllInputAnswer()
    {
        m_ExamLoader.ClearAllInputAnswer();
    }

    /// <summary>
    /// 清空考题
    /// </summary>
    public void ClearExam()
    {
        m_ExamLoader.ClearExam();
    }
}