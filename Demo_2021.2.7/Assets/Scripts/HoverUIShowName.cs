using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverUIShowName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoImage;
    public string Name;

    //偏移值
    [SerializeField] float offsetX = 0;
    [SerializeField] float offsety = 0;

    /// <summary>
    /// 根据不同的分辨率进行适配
    /// </summary>
    void Start()
    {
        if (infoImage != null)
            infoImage.SetActive(false);
        float offsetXtemp = 1920f / 50f;
        offsetXtemp = Screen.width / offsetXtemp;
        offsetX = offsetXtemp;
        offsety = -30;
    }

    /// <summary>
    /// 控制UI的位置
    /// </summary>
    void Update()
    {
        if (infoImage.activeSelf)
        {
            infoImage.transform.position = Input.mousePosition + new Vector3(offsetX, offsety, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (infoImage != null)
        {
            infoImage.SetActive(true);
            infoImage.GetComponentInChildren<Text>().text = Name;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (infoImage != null)
        {
            infoImage.SetActive(false);
        }
    }
}