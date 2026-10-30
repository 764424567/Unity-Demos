using UnityEngine;

public class Screenshot : MonoBehaviour
{
    //截图相机
    Camera capCamera;
    //场景图片
    Texture2D screenShot;

    void Start()
    {
        capCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Show",GUILayout.Width(300),GUILayout.Height(300)))
        {
            CaptureCamera();
        }
    }

    void CaptureCamera()
    {
        Rect rect = new Rect(Screen.width * 0f, Screen.height * 0f, Screen.width * 1f, Screen.height * 1f);
        // 创建一个RenderTexture对象  
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        // 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机  
        capCamera.targetTexture = rt;
        capCamera.Render();
        // 激活这个rt, 并从中中读取像素。  
        RenderTexture.active = rt;
        screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素  
        screenShot.Apply();

        // 重置相关参数，以使用camera继续在屏幕上显示  
        capCamera.targetTexture = null;
        //ps: camera2.targetTexture = null;  
        RenderTexture.active = null; // JC: added to avoid errors  

        //销毁这个对象
        Destroy(rt);

        //保存图片
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.streamingAssetsPath + "/2.png";
        System.IO.File.WriteAllBytes(filename, bytes);
    }
}
