using UnityEngine;
public class Test_5_6 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("byte类型的最小值：" + byte.MinValue + "\n最大值：" + byte.MaxValue);
        //Debug.Log("char类型的最小值：" + char.MinValue + "\n最大值：" + char.MaxValue);
        //Debug.Log("double类型的最小值：" + double.MinValue + "\n最大值：" + double.MaxValue);
        //Debug.Log("float类型的最小值：" + float.MinValue + "\n最大值：" + float.MaxValue);
        //Debug.Log("int类型的最小值：" + int.MinValue + "\n最大值：" + int.MaxValue);
        //Debug.Log("sbyte类型的最小值：" + sbyte.MinValue + "\n最大值：" + sbyte.MaxValue);
        //Debug.Log("short类型的最小值：" + short.MinValue + "\n最大值：" + short.MaxValue);
        //Debug.Log("uint类型的最小值：" + uint.MinValue + "\n最大值：" + uint.MaxValue);
        //Debug.Log("ulong类型的最小值：" + ulong.MinValue + "\n最大值：" + ulong.MaxValue);
        //Debug.Log("uint类型的最小值：" + ushort.MinValue + "\n最大值：" + ushort.MaxValue);

        Debug.Log(string.Format("{0:C3}", 2));
        Debug.Log(string.Format("{0:D3}", 2));
        Debug.Log(string.Format("{0:E3}", 2));
        Debug.Log(string.Format("{0:G}", 2));
        Debug.Log(string.Format("{0:N}", 250000));
        Debug.Log(string.Format("{0:X}", 255));
    }
}