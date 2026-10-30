using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplay : MonoBehaviour
{
    public Button[] BtnEquipmentList;//按钮列表
    public Text TextDetails;//显示的文字
    public GameObject[] AllModels;//所有的模型
    private int Index;//记录上一次点击的下标
    private string[] StrDetails = new string[] { "立方体", "球体", "胶囊体", "圆柱体" };//文字提示列表

    void Start()
    {
        // 按钮绑定事件
        for (int i = 0; i < BtnEquipmentList.Length; i++)
        {
            int index = i;
            BtnEquipmentList[i].onClick.AddListener(() => BtnEquipmentListEvent(index));
        }
        // 所有的模型隐藏
        for (int i = 0; i < AllModels.Length; i++)
        {
            AllModels[i].SetActive(false);
        }
        // 初始化
        Index = 0;
        AllModels[0].gameObject.SetActive(true);
        TextDetails.text = StrDetails[0];
    }

    void BtnEquipmentListEvent(int index)
    {
        AllModels[Index].SetActive(false);
        AllModels[index].SetActive(true);
        Index = index;
        TextDetails.text = StrDetails[index];
    }
}