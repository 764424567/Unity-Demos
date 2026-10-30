using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NameSort
{
    Default,
    Active,
    Passive
}
public class ItemPanelBase : MonoBehaviour
{
    private List<ItemPanelBase> childList;//子物体集合
    [HideInInspector]
    public Button downArrow;//下箭头按钮
    public Button downArrow2;//下箭头按钮
    public Sprite down, right, dot;
    public bool isOpen { get; set; }//子物体开启状态
    private Vector2 startSize;//起始大小

    NameSort m_NameSore = NameSort.Default;
    string m_Name;

    private void Awake()
    {
        childList = new List<ItemPanelBase>();
        downArrow = this.transform.Find("ContentPanel/ArrowButton").GetComponent<Button>();
        downArrow.onClick.AddListener(() =>
        {
            if (isOpen)
            {
                CloseChild();
                isOpen = false;
            }
            else
            {
                OpenChild();
                isOpen = true;
            }
        });
        downArrow2 = this.transform.Find("ContentPanel/ArrowButton2").GetComponent<Button>();
        downArrow2.onClick.AddListener(() =>
        {
            if (isOpen)
            {
                CloseChild();
                isOpen = false;
            }
            else
            {
                OpenChild();
                isOpen = true;
            }
        });
        startSize = this.GetComponent<RectTransform>().sizeDelta;
        isOpen = false;
    }

    //添加子物体到集合
    private void AddChild(ItemPanelBase parentItemPanelBase)
    {
        childList.Add(parentItemPanelBase);
        if (childList.Count >= 1)
        {
            downArrow.GetComponent<Image>().sprite = right;
        }
    }

    //设置当前对象的名字值
    public void SetName(string _name,NameSort m_sort)
    {
        m_Name = _name;
        m_NameSore = m_sort;
    }

    /// <summary>
    /// 设置父物体，父物体不为一级菜单
    /// </summary>
    /// <param name="parentItemPanelBase"></param>
    public void SetItemParent(ItemPanelBase parentItemPanelBase)
    {
        this.transform.parent = parentItemPanelBase.transform;
        parentItemPanelBase.AddChild(this);
        this.GetComponent<VerticalLayoutGroup>().padding = new RectOffset((int)parentItemPanelBase.downArrow.GetComponent<RectTransform>().sizeDelta.x, 0, 0, 0);
        if (parentItemPanelBase.isOpen)
        {

            this.GetComponent<ItemPanelBase>().AddParentSize((int)this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        else
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 设置父物体，父物体为一级菜单
    /// </summary>
    /// <param name="tran"></param>
    public void SetBaseParent(Transform tran)
    {
        this.transform.parent = tran;
    }

    /// <summary>
    /// 填充Item数据
    /// </summary>
    /// <param name="_name">名字</param>
    public void InitPanelContent(string _name)
    {
        transform.Find("ContentPanel/Text").GetComponent<Text>().text = _name;
    }

    /// <summary>
    /// 增加一个子物体后更新Panel大小
    /// </summary>
    /// <param name="change"></param>
    public void UpdateRectTranSize(int change)
    {
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(startSize.x, this.gameObject.GetComponent<RectTransform>().sizeDelta.y + change);
    }
    /// <summary>
    /// 增加父物体高度
    /// </summary>
    /// <param name="parentItem"></param>
    /// <param name="change"></param>
    public void AddParentSize(int change)
    {
        if (this.transform.parent.GetComponent<ItemPanelBase>() != null)
        {
            this.transform.parent.GetComponent<ItemPanelBase>().UpdateRectTranSize(change);
            this.transform.parent.GetComponent<ItemPanelBase>().AddParentSize(change);
        }
    }

    /// <summary>
    /// 关闭子物体列表
    /// </summary>
    public void CloseChild()
    {
        if (childList.Count == 0) return;
        foreach (ItemPanelBase child in childList)
        {
            child.gameObject.SetActive(false);
            child.GetComponent<ItemPanelBase>().AddParentSize(-(int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        downArrow.GetComponent<Image>().sprite = right;
    }

    /// <summary>
    /// 打开子物体列表
    /// </summary>
    public void OpenChild()
    {
        if (childList.Count == 0)
        {
            if (m_Name == "125K读卡器" && m_NameSore == NameSort.Active)
            {
                Debug.Log("125k设备");
            }
            return;
        }

        foreach (ItemPanelBase child in childList)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<ItemPanelBase>().AddParentSize((int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        downArrow.GetComponent<Image>().sprite = down;

    }
}
