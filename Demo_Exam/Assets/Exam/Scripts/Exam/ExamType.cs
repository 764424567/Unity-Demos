/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamType
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：试题类型
******************************************************************************/

public enum ExamType
{
    /// <summary>
    /// 原始考题
    /// </summary>
    KaoTi = 0,
    /// <summary>
    /// 选择题
    /// </summary>
    XuanZeTi,
    /// <summary>
    /// 填空题
    /// </summary>
    TianKongTi,
    /// <summary>
    /// 多选题
    /// </summary>
    DuoXuanTi,
    /// <summary>
    /// 图文单选题
    /// </summary>
    ImageXuanZe,
    /// <summary>
    /// 图文填空题
    /// </summary>
    ImageTianKong,
    /// <summary>
    /// 图文多选题
    /// </summary>
    ImageDuoXuan
}