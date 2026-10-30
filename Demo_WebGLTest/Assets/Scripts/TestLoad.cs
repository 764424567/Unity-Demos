using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoad : MonoBehaviour
{

    public Texture2D tx;
    void Start()
    {
        StartCoroutine(shangchuan());
    }

    IEnumerator shangchuan()
    {
        if (tx)
        {
            WWWForm form = new WWWForm();
            form.AddField("Name", "3");  //这个3代表上传成功后的图片名字为 3.png      这个Name是和服务器自检的,不用修改
            form.AddBinaryData("post", tx.EncodeToPNG());       //这个post是和服务器自检的,不用修改         tx.EncodeToPNG()为图片转的16进制数组(byte[])
            WWW www = new WWW("http://localhost/UpLoad/UnityUpload.php", form);    //必须上传这个路径http://xxxxxxxx/UpLoad/UnityUpload.php,因为服务器里的接收在这个路径下
            yield return www;
        }
        else
            yield return null;
    }
}
