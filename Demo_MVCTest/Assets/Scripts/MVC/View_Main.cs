using UnityEngine;
using UnityEngine.UI;

//UI获取，UI控制的类
public class View_Main : MonoBehaviour
{
    //场景控制器
    Controller_Main m_ControllerMain;
    //图片对象
    [HideInInspector]
    public Image m_Image;

    void Start()
    {
        m_ControllerMain = GameObject.Find("ScenesController").GetComponent<Controller_Main>();
        m_Image = GameObject.Find("ImageBackground").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //根据点击到UI对象，获取UI对象名字
            //如果获取到对象的话   
            if (m_ControllerMain.OnePointColliderObject() != null)
            {
                //给图片名字赋值
                string onClickName = m_ControllerMain.OnePointColliderObject().name;
                //创建对象
                m_ControllerMain.ButtonImageOnClick(onClickName);
            }
        }
    }
}
