using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    private List<Pull> childList;//子物体集合
    [HideInInspector]
    public Button downArrow;//下箭头按钮
    public Button downArrow2;//下箭头按钮
    public Sprite down, right, dot;
    public bool isOpen { get; set; }//子物体开启状态
    private Vector2 startSize;//起始大小

    private void Awake()
    {
        childList = new List<Pull>();
        downArrow = transform.Find("ContentPanel/ArrowButton").GetComponent<Button>();
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

    public void SetParent(Transform _obj)
    {
        transform.parent = _obj;
    }

    public void SetChiclParent(Transform _obj)
    {
        transform.parent = _obj;
        AddChild(this);
        GetComponent<VerticalLayoutGroup>().padding = new RectOffset((int)downArrow.GetComponent<RectTransform>().sizeDelta.x, 0, 0, 0);
        if (isOpen)
        {
            GetComponent<ItemPanelBase>().AddParentSize((int)gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
    }

    //添加子物体到集合
    private void AddChild(Pull _obj)
    {
        childList.Add(_obj);
        if (childList.Count >= 1)
        {
            downArrow.GetComponent<Image>().sprite = right;
        }
    }

    public void UpdateRectTranSize(int change)
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(startSize.x, this.gameObject.GetComponent<RectTransform>().sizeDelta.y + change);
    }

    public void AddParentSize(int change)
    {
        if (transform.parent.GetComponent<Pull>() != null)
        {
            transform.parent.GetComponent<Pull>().UpdateRectTranSize(change);
            transform.parent.GetComponent<Pull>().AddParentSize(change);
        }
    }

    /// <summary>
    /// 关闭子物体列表
    /// </summary>
    public void CloseChild()
    {
        if (childList.Count == 0) return;
        foreach (Pull child in childList)
        {
            child.gameObject.SetActive(false);
            child.GetComponent<Pull>().AddParentSize(-(int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        downArrow.GetComponent<Image>().sprite = right;
    }

    /// <summary>
    /// 打开子物体列表
    /// </summary>
    public void OpenChild()
    {
        Debug.Log(gameObject.name);
        if (childList.Count == 0)
        {
            return;
        }
        foreach (Pull child in childList)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<Pull>().AddParentSize((int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        downArrow.GetComponent<Image>().sprite = down;
    }

    public void InitContent(string itemName)
    {
        transform.Find("ContentPanel/Text").GetComponent<Text>().text = itemName;
    }
}
