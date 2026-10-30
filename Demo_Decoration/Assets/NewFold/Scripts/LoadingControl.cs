using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingControl : MonoBehaviour
{
    public Text loadingText;
    public Text loadingValue;
    public Image progressBar;
    private int curProgressValue = 0;
    private AsyncOperation operation=null;
    private bool BoolTextLoading = true;
    private float timer = 0;

    void Start()
    {
        StartCoroutine(AsyncLoading());
    }

    IEnumerator AsyncLoading()
    {
        yield return new WaitForSeconds(0.1f);
        string scenesId = PlayerPrefs.GetString("ScenesID");
        operation = SceneManager.LoadSceneAsync(scenesId);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;
        yield return operation;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoolTextLoading)
        {
            timer += Time.deltaTime;
            if (timer % 1 > 0.1f && timer % 1 < 0.4f)
            {
                loadingText.text = "Loading..";
            }
            else if (timer % 1 > 0.4f && timer % 1 < 0.7f)
            {
                loadingText.text = "Loading...";
            }
            else if (timer % 1 > 0.7f && timer % 1 < 0.9f)
            {
                loadingText.text = "Loading....";
            }
            else
            {
                loadingText.text = "Loading.";
            }
        }

        int progressValue = 100;
        if (curProgressValue < progressValue)
        {
            curProgressValue++;
        }

        loadingValue.text = curProgressValue + "%";//实时更新进度百分比的文本显示  
        progressBar.fillAmount = curProgressValue / 100f;//实时更新滑动进度图片的fillAmount值  
        if (curProgressValue == 100)
        {
            operation.allowSceneActivation = true;//启用自动加载场景  
            BoolTextLoading = false;
            loadingValue.text = "OK";//文本显示完成OK  
        }
    }
}
