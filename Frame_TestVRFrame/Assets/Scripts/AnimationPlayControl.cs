using UnityEngine;

public class AnimationPlayControl : MonoBehaviour
{
    public Animator ani;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // 暂停动画
            ani.SetFloat("speed",0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // 倒播
            ani.SetFloat("speed", -1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // 播放动画
            ani.SetFloat("speed", 1);
        }
    }
}