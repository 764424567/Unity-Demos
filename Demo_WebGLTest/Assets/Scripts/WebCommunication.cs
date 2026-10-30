using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebCommunication : MonoBehaviour
{
    //引用jslib的FileImg()方法
    [DllImport("__Internal")]
    private static extern void FileImg();
    public Text m_Text;
    public Image preview;
    public Texture2D tx;
    public GameObject m_Cube;
    string url = "http://YOUR_API_HOST:800/zut/fashion/Experiment/recvDataFromExperiment";
    string url1 = "http://YOUR_API_HOST:800/zut/fashion/Experiment/experimentize";

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 35), "OpenDialog"))
        {
            FileImg();
        }
        if (GUI.Button(new Rect(0, 100, 100, 35), "UploadImg"))
        {
            StartCoroutine(ImgUploadPost2());
            //StartCoroutine(GetUserInfo());
        }
        if (GUI.Button(new Rect(0, 200, 100, 35), "GetImg"))
        {
            StartCoroutine(GetImg("http://YOUR_API_HOST:800/zut/fashion/public/upload/structure/a3f390d88e4c41f2747bfa2f1b5f87db/5ef9529b5b156.jpg"));
            //StartCoroutine(PreviewCoroutine("http://localhost/UpLoad/upload/black.png"));
        }
    }

    IEnumerator GetUserInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("type", 1);
        form.AddField("exp_id", 2);
        form.AddField("data_id", -1);
        form.AddField("data", "");
        UnityWebRequest req = UnityWebRequest.Post(url1, form);
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            Debug.LogError(req.error);
        }

        if (req.isDone)
        {
            Debug.Log(req.downloadHandler.text);
        }
    }

    public void FileDialogResult(string fileUrl)
    {
        Debug.Log(fileUrl);
        m_Text.text = fileUrl;
        //StartCoroutine(PreviewCoroutine(fileUrl));
        StartCoroutine(GetImg(fileUrl));
    }

    public void FileUpload()
    {
        StartCoroutine(ImgUpload());
    }

    IEnumerator PreviewCoroutine(string url)
    {
        var www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            tx = www.texture;
            m_Cube.GetComponent<MeshRenderer>().material.mainTexture = tx;
            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            preview.sprite = sprite;
        }
    }

    IEnumerator ImgUpload()
    {
        if (tx)
        {
            //byte[] bytes = tx.EncodeToPNG();
            WWWForm form = new WWWForm();
            form.AddField("Name", "1");
            form.AddBinaryData("post", tx.EncodeToPNG());
            WWW www = new WWW("http://localhost/UpLoad/UnityUpload.php", form);
            yield return www;
            Debug.Log(www.isDone);
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator ImgUploadPost()
    {
        byte[] bytes = tx.EncodeToPNG();
        WWWForm form = new WWWForm();
        form.AddField("Name", "14");
        form.AddBinaryData("post", bytes);
        UnityWebRequest req = UnityWebRequest.Post("http://localhost/UpLoad/UnityUpload.php", form);
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            Debug.Log("发送失败：" + req.error);
        }

        if (req.isDone)
        {
            Debug.Log("发送成功：" + req.downloadHandler.text);
        }
    }

    IEnumerator ImgUploadPost2()
    {
        WWWForm form = new WWWForm();
        form.AddField("type", 2);
        form.AddField("exp_id", 2);
        form.AddField("data_id", 169);
        form.AddField("idx", 0);
        //form.AddField("folder", "Photos/");
        form.AddBinaryData("data", tx.EncodeToPNG(), "jgt1.png", "image/png");
        UnityWebRequest req = UnityWebRequest.Post(url, form);
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            Debug.LogError(req.error);
        }

        if (req.isDone)
        {
            Debug.Log(req.downloadHandler.text);
        }
    }

    IEnumerator ImgUploadPost3()
    {
        Hashtable headers = new System.Collections.Hashtable();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");//哈希表的数据格式
        //byte[] bs = tx.EncodeToPNG();
        string data = "username=post&password=6789&";
        byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes(data);
        byte[] bs2= tx.EncodeToPNG();
        byte[] bs3 = new byte[bs.Length + bs2.Length];
        bs.CopyTo(bs3, 0);
        bs2.CopyTo(bs3, bs.Length);

        WWW www = new WWW("http://YOUR_API_HOST:800/zut/fashion/Experiment/recvDataFromExperiment", bs3, headers);
        yield return www;
        Debug.Log(www.text);
        //form.AddField("exp_id", "1");
        //form.AddField("data_id", "1");
        //form.AddField("type", "2");
        //form.AddField("idx", "1");
        //form.AddField("file_name", "1");
        //form.AddBinaryData("data", tx.EncodeToPNG());
        //UnityWebRequest req = UnityWebRequest.Post("http://YOUR_API_HOST:800/zut/fashion/Experiment/recvDataFromExperiment",bs,headers);
        //yield return req.SendWebRequest();
        //if (req.isNetworkError)
        //{
        //    Debug.Log("发送失败：" + req.error);
        //}

        //if (req.isDone)
        //{
        //    Debug.Log("接收数据：" + req.downloadHandler.text);
        //}
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();//创建提交数据表单
        form.AddField("exp_id", "1");
        form.AddField("data_id", "1");
        form.AddField("type", "2");
        form.AddField("idx", "1");
        form.AddField("file_name", "1");
        form.AddField("folder", "Photos/");//定义表单字段用来定义文件夹
        form.AddBinaryData("data", tx.EncodeToPNG(), "11.png", "image/png");//字段名，文件数据，文件名，文件类型
        UnityWebRequest req = UnityWebRequest.Post("http://YOUR_API_HOST:800/zut/fashion/Experiment/recvDataFromExperiment", form);
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            Debug.LogError(req.error);
        }

        if (req.isDone)
        {
            Debug.Log("接收数据：" + req.downloadHandler.text);
        }

        //WWWForm form = new WWWForm();
        ////form.AddField("exp_id", "1");
        ////form.AddField("data_id", "1");
        ////form.AddField("type", "2");
        ////form.AddField("idx", "1");
        ////form.AddField("file_name", "1");
        //form.AddBinaryData("data", tx.EncodeToPNG());
        //UnityWebRequest req = UnityWebRequest.Post("http://YOUR_API_HOST:800/zut/fashion/Experiment/recvDataFromExperiment", form);
        //yield return req.SendWebRequest();
        //if (req.isNetworkError)
        //{
        //    Debug.Log("发送失败：" + req.error);
        //}

        //if (req.isDone)
        //{
        //    Debug.Log("接收数据：" + req.downloadHandler.text);
        //}
    }


    IEnumerator GetImg(string url)
    {
        var www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            tx = www.texture;
            m_Cube.GetComponent<MeshRenderer>().material.mainTexture = tx;
            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            preview.sprite = sprite;
        }
        else
        {
            Debug.Log("数据为空");
        }
    }

    public Texture2D Screenshot()//截屏
    {
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);
        tex.Apply();
        return tex;

    }
    IEnumerator UploadScreen()//上传图片
    {
        yield return new WaitForEndOfFrame();
        byte[] bytes = Screenshot().EncodeToPNG();
        WWWForm form = new WWWForm();
        form.AddField("Name", "1");
        form.AddBinaryData("post", bytes);
        WWW www = new WWW("http://localhost/UpLoad/UnityUpload.php", form);
        yield return www;
        Debug.Log(www.isDone);
    }
}
