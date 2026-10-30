using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_BtnEvent : MonoBehaviour
{
    Control_Painting m_ControlPainting;
    Control_File m_ControlFile;
    public Button btn_Recover;
    public MyButton btn_Finish;
    public Button btn_View;
    public Button btn_Red;
    public Button btn_Black;
    public Button btn_Blue;
    public Button btn_Thick;
    public Button btn_Middle;
    public Button btn_Slender;

    public GameObject panel_Finish;
    public Button btn_FinishOK;
    public Button btn_FinishCancel;

    public GameObject panel_View;
    public Button btn_ViewPageUp;
    public Button btn_ViewPageDown;
    public Button btn_ViewBack;
    public Rect m_TempRect;

    private void Awake()
    {
        m_ControlPainting = GetComponent<Control_Painting>();
        m_ControlFile = GetComponent<Control_File>();

        btn_Recover.onClick.AddListener(BtnRecover_Event);
        btn_Finish.onClick.AddListener(BtnFinish_Evnet);
        btn_View.onClick.AddListener(BtnView_Event);

        btn_Red.onClick.AddListener(BtnRed_Event);
        btn_Black.onClick.AddListener(BtnBlack_Event);
        btn_Blue.onClick.AddListener(BtnBlue_Event);

        btn_Thick.onClick.AddListener(BtnThick_Evnet);
        btn_Middle.onClick.AddListener(BtnMiddle_Event);
        btn_Slender.onClick.AddListener(BtnSlender_Event);

        btn_FinishOK.onClick.AddListener(BtnFinishOK_Event);
        btn_FinishCancel.onClick.AddListener(BtnFinishCancel_Event);

        btn_ViewPageUp.onClick.AddListener(BtnViewPageUp_Event);
        btn_ViewPageDown.onClick.AddListener(BtnViewPageDown_Event);
        btn_ViewBack.onClick.AddListener(BtnViewBack_Event);
    }

    private void Start()
    {
        //m_ControlFile.GetScanceImage();
    }

    private void Update()
    {
        //if (btn_Finish.m_BtnState == Selection.Highlighted)
        //{
        //    m_ControlPainting.enabled = false;
        //}
        //else if(btn_Finish.m_BtnState == Selection.Pressed)
        //{
        //    m_ControlPainting.enabled = false;
        //}
        //else
        //{
        //    m_ControlPainting.enabled = true;
        //    //Invoke("State_Recover", 3f);
        //}
    }

    public void BtnRecover_Event()
    {
        m_ControlPainting.OnClickClear();
    }

    public void BtnFinish_Evnet()
    {
        m_ControlPainting.enabled = false;
        //m_ControlFile.ScreenTexture(new Rect(60, 210, 780, 480), "C:\\TempImg");
        //Invoke("State_Recover", 3f);
        panel_Finish.SetActive(true);
    }

    public void BtnView_Event()
    {
        panel_View.SetActive(true);
        m_ControlPainting.OnClickClear();
        m_ControlFile.GetScanceImage();
    }

    public void BtnRed_Event()
    {
        m_ControlPainting.brushColor = Color.red;
    }

    public void BtnBlack_Event()
    {
        m_ControlPainting.brushColor = Color.black;
    }

    public void BtnBlue_Event()
    {
        m_ControlPainting.brushColor = Color.blue;
    }

    public void BtnThick_Evnet()
    {
        m_ControlPainting.brushScale = 1;
    }

    public void BtnMiddle_Event()
    {
        m_ControlPainting.brushScale = 0.5f;
    }

    public void BtnSlender_Event()
    {
        m_ControlPainting.brushScale = 0.1f;
    }

    public void BtnFinishOK_Event()
    {
        panel_Finish.SetActive(false);
        StartCoroutine(FileImgSave());
    }

    IEnumerator FileImgSave()
    {
        yield return new WaitForSeconds(0.1f);
        //m_ControlFile.ScreenTexture(new Rect(60, 210, 1200, 800), "C:\\TempImg");
        m_ControlFile.ScreenTexture(m_TempRect, "C:\\TempImg");
        m_ControlPainting.enabled = true;
    }

    public void State_Recover()
    {
        //m_ControlPainting.OnClickClear();
        m_ControlPainting.enabled = true;
    }

    public void BtnFinishCancel_Event()
    {
        //m_ControlFile.DestroyTempImg();
        panel_Finish.SetActive(false);
        //Invoke("Invoke_FinishCancel",3f);
    }

    

    public void BtnViewPageUp_Event()
    {
        m_ControlFile.ImageBackClothes();
    }

    public void BtnViewPageDown_Event()
    {
        m_ControlFile.ImageNextClothes();
    }

    public void BtnViewBack_Event()
    {
        m_ControlFile.DestroyTempImg();
        //Invoke("Invoke_FinishCancel", 3f);
        panel_View.SetActive(false);
    }

    public void Invoke_FinishCancel()
    {
        panel_View.SetActive(false);
    }
}
