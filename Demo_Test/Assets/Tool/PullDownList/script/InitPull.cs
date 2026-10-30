using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPull : MonoBehaviour
{
    private List<GameObject> itemPanelList;
    public GameObject itemPanel;


    private void Awake()
    {
        itemPanelList = new List<GameObject>();
    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 13; i++)
        {
            //一级菜单
            if (i == 0)
            {
                GameObject newItemPanel = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel);
                newItemPanel.GetComponent<Pull>().SetParent(this.transform);
                newItemPanel.GetComponent<Pull>().InitContent("RFID设备");
            }
            //二级菜单
            if (i == 1)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<Pull>().SetChiclParent(itemPanelList[0].transform);
                newItemPanel2.GetComponent<Pull>().InitContent("有源设备");
            }
            else if (i == 2)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<Pull>().SetChiclParent(itemPanelList[0].transform);
                newItemPanel2.GetComponent<Pull>().InitContent("无源设备");
            }
        }
    }
}
