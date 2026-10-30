using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMPLink : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI m_TextMeshPro;

    void Awake()
    {
        m_TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, eventData.pressEventCamera);
        TMP_LinkInfo linkInfo = m_TextMeshPro.textInfo.linkInfo[linkIndex];
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_TextMeshPro.rectTransform, eventData.position, eventData.pressEventCamera, out var worldPointInRectangle);
        switch (linkInfo.GetLinkID())
        {
            case "id_01":
                Debug.Log("点击了id：id_01的超链接");
                Application.OpenURL("https://blog.csdn.net/q764424567");
                break;
        }
    }
}