using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class ButtonTest : MonoBehaviour
{
    public Text m_Text;

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();

        btnListener.OnClick += delegate () {
            ButtonOnClickEvent();
        };
    }

    public void ButtonOnClickEvent()
    {
        m_Text.text = "鼠标点击";
    }
}
