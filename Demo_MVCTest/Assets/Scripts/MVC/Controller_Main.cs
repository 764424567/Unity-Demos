using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//逻辑实现类
public class Controller_Main : MonoBehaviour
{
    //视图对象
    View_Main m_ViewMain;
    //模型对象
    Model_Main m_MainScenesData = Model_Main.Instance;
    //标识数字
    int i = 2;

    void Awake()
    {
        //获取材质
        Resources_Get();
        m_ViewMain = GameObject.Find("ScenesController").GetComponent<View_Main>();
    }

    //贴图赋值
    public void Resources_Get()
    {
        //贴图
        m_MainScenesData.Image_1 = Resources.Load("Texture/1",typeof(Sprite)) as Sprite;
        m_MainScenesData.Image_2 = Resources.Load("Texture/2", typeof(Sprite)) as Sprite;
        m_MainScenesData.Image_3 = Resources.Load("Texture/3", typeof(Sprite)) as Sprite;
        m_MainScenesData.Image_4 = Resources.Load("Texture/4", typeof(Sprite)) as Sprite;
        m_MainScenesData.Image_5 = Resources.Load("Texture/5", typeof(Sprite)) as Sprite;
        m_MainScenesData.Image_6 = Resources.Load("Texture/6", typeof(Sprite)) as Sprite;
        m_MainScenesData.Image_7 = Resources.Load("Texture/7", typeof(Sprite)) as Sprite;
    }

    //点击对象获取到对象的名字
    public GameObject OnePointColliderObject()
    {
        //存有鼠标或者触摸数据的对象
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        //当前指针位置
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //射线命中之后的反馈数据
        List<RaycastResult> results = new List<RaycastResult>();
        //投射一条光线并返回所有碰撞
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        //返回点击到的物体
        if (results.Count > 0)
            return results[0].gameObject;
        else
            return null;
    }

    //按钮及图片的点击事件
    public void ButtonImageOnClick(string onClickName)
    {
        switch (onClickName)
        {
            case "Button_ReplaceImager":
                Button_ReplaceImager(onClickName);
                break;
            default:
                break;
        }
    }

    public void Button_ReplaceImager(string onClickName)
    {
        switch (i)
        {
            case 1:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_1;
                i = i + 1;
                break;
            case 2:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_2;
                i = i + 1;
                break;
            case 3:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_3;
                i = i + 1;
                break;
            case 4:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_4;
                i = i + 1;
                break;
            case 5:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_5;
                i = i + 1;
                break;
            case 6:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_6;
                i = i + 1;
                break;
            case 7:
                m_ViewMain.m_Image.sprite = m_MainScenesData.Image_7;
                i = 1;
                break;
            default:
                break;
        }
    }
}
