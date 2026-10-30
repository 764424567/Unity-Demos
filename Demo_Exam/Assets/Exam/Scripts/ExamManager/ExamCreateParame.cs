/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamManager.ExamCreatePaper
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：生成题目 参数类
******************************************************************************/

public sealed class ExamCreateParame
{
    internal enum Type
    {
        生成全部,
        生成随机题目,
        生成int数组题目,
        生成string数组题目
    }

    internal Type type;

    internal object value;

    internal ExamCreateParame(Type type, object value=null)
    {
        this.type = type;
        this.value = value;
    }
}