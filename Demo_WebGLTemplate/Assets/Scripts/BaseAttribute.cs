using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode] //不需要运行游戏即可控制图片切换
public class BaseAttribute : MonoBehaviour
{

    //背景属性
    public Sprite BackSprite;
    public float BackSpriteWidth = 100;
    public float BackSpriteHeight = 100;


    //前景属性
    public Sprite ForwardSprite;
    public float ForwardSpriteWidth;
    public float ForwardSpriteHeight;

    void Update()
    {
        SettingBackImage();
    }

    void SettingBackImage()
    {
        this.GetComponent<Image>().sprite = BackSprite;
    }
}