using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class STMyCam : MonoBehaviour
{

    WebCamTexture camTexture;
    CanvasScaler CanScaler;
    Camera ca;
    public Image img;

    public Text log;
    void Start()
    {

        CanScaler = GetComponentInChildren<CanvasScaler>();
        CanScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        ca = GetComponentInChildren<Camera>();
        ca.orthographicSize = Screen.width / 100.0f / 2.0f;

        img.transform.localScale = new Vector3(-1, -1, -1);

        img.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        img.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        img.rectTransform.pivot = new Vector2(0.5f, 0.5f);

        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);

        // 设备不同的坐标转换
#if UNITY_IOS || UNITY_IPHONE
 img.transform.localEulerAngles =new Vector3 (180, 0, 180);
#endif
#if UNITY_ANDROID
        img.transform.localEulerAngles = new Vector3(180, 180, 0);
#endif

        StartCoroutine(CallCamera());

    }

    IEnumerator CallCamera()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            if (camTexture != null)
                camTexture.Stop();

            WebCamDevice[] cameraDevices = WebCamTexture.devices;
            if (cameraDevices.Length > 0)
            {
                string deviceName = cameraDevices[0].name;

                camTexture = new WebCamTexture(deviceName, Screen.height, Screen.width, 60);
#if UNITY_ANDROID
                camTexture = new WebCamTexture(deviceName, Screen.width, Screen.height);
#endif               
                img.canvasRenderer.SetTexture(camTexture);

                camTexture.Play();
            }
        }
    }

}