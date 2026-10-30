using UnityEngine;

public class First : MonoBehaviour
{
    public GameObject tips;//闪烁的Text组件
    private CanvasGroup canvasGroup;
    private float alphaSpeed = 4f;//闪烁速度
    private float alpha = 0.3f;//最低透明度
    private bool isShow = true;//用来控制闪烁的内容
    public bool isShanShow = true;
    void Awake()
    {
        canvasGroup = tips.transform.GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (isShanShow)
        {
            if (isShow)
            {
                if (canvasGroup.alpha != alpha)
                {
                    canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alpha, alphaSpeed * Time.deltaTime);
                    if (Mathf.Abs(canvasGroup.alpha - alpha) <= 0.01)
                    {
                        canvasGroup.alpha = alpha;
                        isShow = false;
                    }
                }
            }
            else
            {
                if (canvasGroup.alpha != 1)
                {
                    canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, alphaSpeed * Time.deltaTime);
                    if (Mathf.Abs(1 - canvasGroup.alpha) <= 0.01)
                    {
                        canvasGroup.alpha = 1;
                        isShow = true;
                    }
                }
            }
        }
        else
            canvasGroup.alpha = 0.9f;
    }
}