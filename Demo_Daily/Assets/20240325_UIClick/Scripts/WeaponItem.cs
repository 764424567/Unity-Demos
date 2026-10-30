using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour
{
    public static WeaponItem Instance;
    public GameObject Current;

    public Image Item;
    public Sprite[] SpirteItem;

    public Button BtnClose;
    public Text TextName;
    public Text TextRank;
    public Text TextContent;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Current.SetActive(false);
        BtnClose.onClick.AddListener(Close);
    }

    public void ShowInfo(int ItemType,string itemName,string itemRank,string itemContent)
    {
        Current.SetActive(true);
        Item.sprite = SpirteItem[ItemType];
        TextName.text = itemName;
        TextRank.text = itemRank;
        TextContent.text = itemContent;
    }

    public void Close()
    {
        Current.SetActive(false);
    }
}