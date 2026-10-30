using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class php_Test : MonoBehaviour
{
    private string url = "http://localhost:8080/phpunityTest.php?id=1100001&cid=1200001";  //带get参数id和cid的url
    private string url1 = "http://localhost:8080/phpunityTest1.php";  //带get参数id和cid的url

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 200, 100), "get php"))
        {
            StartCoroutine(OnGet());
        }
        if (GUI.Button(new Rect(100, 400, 200, 100), "post php"))
        {
            StartCoroutine(OnPost());
        }
    }

    IEnumerator OnGet()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.error != null)
            {
                Debug.Log("php请求错误: 代码为" + www.error);
            }
            else
            {
                Debug.Log("php请求成功" + www.downloadHandler.text);
            }
        }
    }

    IEnumerator OnPost()
    {
        //表单
        WWWForm form = new WWWForm();
        form.AddField("id", 1100001);
        form.AddField("cid", 1100001);
        using (UnityWebRequest www = UnityWebRequest.Post(url1, form))
        {
            yield return www.SendWebRequest();
            if (www.error != null)
            {
                Debug.Log("php请求错误: 代码为" + www.error);
            }
            else
            {
                Debug.Log("php请求成功" + www.downloadHandler.text);
            }
        }
    }
}
