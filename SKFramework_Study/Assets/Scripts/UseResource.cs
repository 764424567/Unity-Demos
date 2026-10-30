using SK.Framework;
using SK.Framework.Resource;
using UnityEngine;
using UnityEngine.UI;

public class UseResource : MonoBehaviour
{
    //场景加载过渡界面
    [SerializeField] GameObject loadingView;
    //加载进度条
    [SerializeField] Image progress;
    //加载进度文本
    [SerializeField] Text progressText;

    void Start()
    {
        SKFramework.Module<Resource>().LoadSceneAsync(Application.dataPath+ "/Scenes/SampleScene.unity",
        (s) =>
        {
            progress.fillAmount = s;
            progressText.text = string.Format("{0}%", Mathf.Round(s * 100));
        },
        (finish) =>
        {
            loadingView.SetActive(false);
        });
    }
}