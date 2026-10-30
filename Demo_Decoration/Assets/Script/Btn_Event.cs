using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn_Event : MonoBehaviour
{
    public int id;
    public Animator animator;
    public Image img_BG;


    public void PointerEnter()
    {
        transform.SetAsLastSibling();
        animator.SetBool("isEnter", true);
        img_BG.sprite = Resources.Load<Sprite>("room" + id.ToString() + "_1_1");
    }
    public void PointerExit()
    {
        //transform.SetAsLastSibling();
        animator.SetBool("isEnter", false);
        img_BG.sprite = Resources.Load<Sprite>("background");
    }
    public void OnClick()
    {
        //SceneManager.LoadScene(id.ToString());
        PlayerPrefs.SetString("ScenesID", id.ToString() + "_1");
        SceneManager.LoadScene("Loading");
    }
}
