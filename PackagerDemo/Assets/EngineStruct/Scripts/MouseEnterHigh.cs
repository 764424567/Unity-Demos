using HighlightPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnterHigh : MonoBehaviour
{
    public void OnMouseEnter()
    {
        gameObject.GetComponent<HighlightEffect>().highlighted = true;
    }


    public void OnMouseExit()
    {
        gameObject.GetComponent<HighlightEffect>().highlighted = false;
    }
}
