using System.Collections.Generic;
using UnityEngine;

public class PullDownList : MonoBehaviour
{
    private List<GameObject> itemPanelList;
    public GameObject itemPanel;

    private void Awake()
    {
        itemPanelList = new List<GameObject>();
    }

    void Start()
    {
        for (int i = 0; i < 27; i++)
        {
            //一级菜单
            if(i == 0)
            {
                GameObject newItemPanel = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel);
                newItemPanel.GetComponent<ItemPanelBase>().SetBaseParent(this.transform);
                newItemPanel.GetComponent<ItemPanelBase>().InitPanelContent("层级一");
            }
            //二级菜单
            if (i == 1)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[0].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级二");
            }
            else if (i == 2)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[0].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级二");
            }
            //三级菜单
            else if (i == 3)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[1].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 4)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[1].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 5)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[1].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 6)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[1].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 7)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[2].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 8)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[2].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 9)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[2].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            else if (i == 10)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[2].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级三");
            }
            //四级菜单
            else if (i == 11)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[3].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 12)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[3].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 13)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[4].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 14)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[4].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 15)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[5].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 16)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[5].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 17)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[6].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 18)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[6].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Active);
            }
            else if (i == 19)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[7].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 20)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[7].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 21)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[8].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 22)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[8].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 23)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[9].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 24)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[9].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 25)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[10].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
            else if (i == 26)
            {
                GameObject newItemPanel2 = Instantiate(itemPanel);
                itemPanelList.Add(newItemPanel2);
                newItemPanel2.GetComponent<ItemPanelBase>().SetItemParent(itemPanelList[10].GetComponent<ItemPanelBase>());
                newItemPanel2.GetComponent<ItemPanelBase>().InitPanelContent("层级四");
                newItemPanel2.GetComponent<ItemPanelBase>().SetName("层级四", NameSort.Passive);
            }
        }
    }
}
