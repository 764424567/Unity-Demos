using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIKeyNavigation : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private EventSystem eventSystem;
    private bool _isSelect = false;
    private bool isGetOneMessage = false;

    // Use this for initialization
    void Start()
    {
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        // 监测Tab按下，此时应该选择下一个UI控件
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //下一个ui控件
            Selectable next = null;
            //当前的ui控件
            Selectable current = null;

            // 验证当前是否有正在选中的物体
            if (eventSystem.currentSelectedGameObject != null)
            {
                //验证当前选中的物体在层次列表里是否可用
                if (eventSystem.currentSelectedGameObject.activeInHierarchy)
                {
                    current = eventSystem.currentSelectedGameObject.GetComponent<Selectable>();
                }
            }

            if (current != null)
            {
                //当左(右)shift被按住，并且伴随着，点击tab键，光标依次向上移动
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    next = current.FindSelectableOnLeft();
                    if (next == null)
                    {
                        next = current.FindSelectableOnUp();
                    }
                }
                else
                {
                    next = current.FindSelectableOnRight();
                    if (next == null)
                    {
                        next = current.FindSelectableOnDown();
                        if (next == null)
                        {
                            current = eventSystem.firstSelectedGameObject.GetComponent<Selectable>();
                            next = current;
                        }
                    }
                }
            }
            else
            {
                //如果没有 “当前正在选择的物体”，那么选择第一个可选项
                if (Selectable.allSelectables.Count > 0)
                {
                    next = Selectable.allSelectables[0];
                }
            }

            if (next != null)
            {
                next.Select();
            }
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        _isSelect = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _isSelect = false;
    }
}
