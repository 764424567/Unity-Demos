using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite[] CardSprites;//读取图集中所有切片
    private string fileName = "2048";//图集的名字
    public int _currentIndex = 0;//当前卡片的显示编号

    void Awake()
    {
        CardSprites = Resources.LoadAll<Sprite>(fileName);
    }


    //根据卡片编号修改SpriteRendere，从而改变卡片的数值
    public void Generate(int index)
    {
        _currentIndex = index;
        GetComponent<SpriteRenderer>().sprite = CardSprites[_currentIndex];
    }

    //合并卡片的逻辑
    public void Merge()
    {
        _currentIndex++;
        GetComponent<SpriteRenderer>().sprite = CardSprites[_currentIndex];
    }
}
