using UnityEngine;
using UnityEngine.UI;//注意添加RawImage命名空间

public class FadeInOut : MonoBehaviour, IFadeInOut
{
    [HideInInspector]
    public bool isBlack = false;//不透明状态
    [HideInInspector]
    public float fadeSpeed = 1;//透明度变化速率
    public RawImage rawImage;
    public RectTransform rectTransform;

    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);//使背景满屏
        rawImage.color = Color.clear;
    }

    void Update()
    {
        if (isBlack == false)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);//渐亮
            if (rawImage.color.a < 0.1f)
            {
                rawImage.color = Color.clear;
            }
        }
        else if (isBlack)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.black, Time.deltaTime * fadeSpeed);//渐暗
            if (rawImage.color.a > 0.9f)
            {
                rawImage.color = Color.black;
            }
        }
    }

    //切换状态
    public void BackGroundControl(bool b)
    {
        if (b == true)
            isBlack = true;
        else
            isBlack = false;
    }
}