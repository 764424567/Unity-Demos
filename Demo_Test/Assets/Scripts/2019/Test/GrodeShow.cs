using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrodeShow : MonoBehaviour
{
    Dictionary<string, int> dic = new Dictionary<string, int>();

    int score = 100;

    float tim = 0;
    float tim1 = 0;
    float tim2 = 0;
    int jifen = 0;
    public Text fen;
    bool isjifen = false;

    // Use this for initialization
    void Start()
    {
        dic.Add("安全逃生加4分", 4);
        dic.Add("使用其他灭火器灭火扣2分", 2);
        dic.Add("如果没有做这一步扣10分", 10);
        SubGrade();
        ShowGrade();
    }

    // Update is called once per frame
    void Update()
    {
        if (isjifen == false)
        {
            if ((tim += Time.deltaTime) >= 0.05f)
            {
                tim = 0;
                jifen += 1;
                fen.GetComponent<Text>().text = jifen.ToString();
                if (jifen == score)
                {
                    isjifen = true;
                }
            }
        }
    }

    public void SubGrade()
    {
        dic.Remove("安全逃生加4分");
    }

    public void ShowGrade()
    {
        foreach (var item in dic.Keys)
        {
            Debug.Log(item+"  -"+dic[item]+"分");
            score -= dic[item];
        }
        Debug.Log(score);
    }
}
