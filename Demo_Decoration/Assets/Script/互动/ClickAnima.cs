using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnima : MonoBehaviour
{
    public Animator animator;
    bool ison = false;
    private void OnMouseDown()
    {
        ison = !ison;
        animator.SetBool("isOn", ison);
    }
}
