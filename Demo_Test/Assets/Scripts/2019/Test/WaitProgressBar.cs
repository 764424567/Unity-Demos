using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaitProgressBar : MonoBehaviour
{

    public Text TimeLabel;//时间显示UI
    public Slider slider;//进度条 滑条 UI
    public GameObject progressBar;//圆环 进度条UI

    public float sumTime;//总时间 单位 秒
    private float currentTime;//当前 的时间 秒

    public float countdownTime = 1;//倒计时 时间间隔

    private void Awake()
    {
        currentTime = sumTime;
    }

    private void Start()
    {
        //StartCoroutine("startCountDown");
        //currentTime = sumTime; 如果在 Start函数内，设置 currentTime，会使得 这个currentTime的值 无效。
    }
    public void progressBarStartCountDown(float time)
    {
        StartCoroutine(startCountDown(time));
    }

    private IEnumerator startCountDown(float _time)
    {
        sumTime = _time;
        currentTime = sumTime;
        progressBar.SetActive(true);//圆环 进度条UI 为真

        while (currentTime >= 0)
        {
            currentTime = currentTime - countdownTime;//总时间 单位 秒，倒计时
            TimeLabel.text = "Time:" + currentTime;//时间显示UI
            slider.value = 1 - (currentTime / sumTime);
            if (currentTime == 0)
            {
                currentTime = 0;
                Debug.Log("gameOver");
                TimeLabel.text = "Time:" + currentTime;
                progressBar.SetActive(false);//圆环 进度条UI 为假
                yield break;//停止 协程
            }
            else if (currentTime > 0)
            {
                yield return new WaitForSeconds(countdownTime);// 每次 自减1，等待 1 秒
            }
        }
    }

    //延迟等待 函数
    IEnumerator Wait()
    {
        // suspend execution for 5 seconds  
        yield return new WaitForSeconds(5);
        //... 一些函数
    }
}