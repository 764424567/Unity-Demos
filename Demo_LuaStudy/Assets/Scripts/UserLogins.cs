using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserLogins : MonoBehaviour
{
    public InputField userIdField;
    public InputField passwordField;
    public Text statusText;

    private string userId = "";
    private string password = "";
    private string url = "http://localhost:8080/login.php";

    public void OnLogin()
    {
        userId = userIdField.text;
        password = passwordField.text;

        if (userId.isEmpty() || password.isEmpty())
        {
            Debug.Log("账户和密码不能为空");
            return;
        }
        StartCoroutine(logining());
    }

    private IEnumerator logining()
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", userId);
        form.AddField("password", UserTools.StrEncrypMd5(UserTools.StrEncrypMd5(password)));  //双重加密,由于md5的
        using (UnityWebRequest www =UnityWebRequest.Post(url,form))
        {
            yield return www.SendWebRequest();
            if (www.error != null)
            {
                Debug.Log("发送错误" + www.error);
                statusText.text = www.error + "...";
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                statusText.text = www.downloadHandler.text;
            }
        }
    }

}
