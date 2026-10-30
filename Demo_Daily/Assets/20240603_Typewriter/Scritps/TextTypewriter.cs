using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextTypewriter : MonoBehaviour
{
    public UnityEvent myEvent;
    public int charsPerSecond = 8;
    public bool isActive = false;
    public float timer;
    public string words;
    private Text mText;
    public int maxChars = 50;


    void Start()
    {
        if (myEvent == null)
            myEvent = new UnityEvent();

        words = GetComponent<Text>().text;
        GetComponent<Text>().text = string.Empty;
        timer = 0;
        charsPerSecond = Mathf.Max(1, charsPerSecond);
        mText = GetComponent<Text>();

        OnStart("123456");
    }

    void ReloadText()
    {
        words = GetComponent<Text>().text;
        mText = GetComponent<Text>();
    }

    public void OnStart()
    {
        ReloadText();
        isActive = true;
    }

    public void OnStart(string worlds)
    {
        isActive = true;
        timer = 0;
        words = worlds;
        this.GetComponentInChildren<Text>().text = worlds;
    }

    void Update()
    {
        OnStartWriter();
    }


    void OnStartWriter()
    {
        if (isActive)
        {
            try
            {
                if ((int)(charsPerSecond * timer) > maxChars)
                    mText.text = words.Substring((int)(charsPerSecond * timer) - maxChars, maxChars);
                else
                    mText.text = words.Substring(0, (int)(charsPerSecond * timer));
                timer += Time.deltaTime;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                OnFinish();
            }
        }
        else
        {
            timer = 0;
        }
    }

    void OnFinish()
    {
        isActive = false;
        timer = 0;
        try
        {
            Debug.Log(111);
            myEvent.Invoke();
        }
        catch (Exception e)
        {
            Debug.Log("Œ Ã‚"+ e);
        }
    }
}
