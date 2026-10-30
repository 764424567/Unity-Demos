using UnityEngine;

//主要是用来存放数据的类
public class Model_Main 
{
    //单例
    private Model_Main() { }
    private static Model_Main m_ModelMain;
    public static Model_Main Instance
    {
        get
        {
            if (m_ModelMain == null)
            {
                m_ModelMain = new Model_Main();
            }
            return m_ModelMain;
        }
    }

    //图片数据
    public Sprite Image_1 { get; set; }
    public Sprite Image_2 { get; set; }
    public Sprite Image_3 { get; set; }
    public Sprite Image_4 { get; set; }
    public Sprite Image_5 { get; set; }
    public Sprite Image_6 { get; set; }
    public Sprite Image_7 { get; set; }
}
