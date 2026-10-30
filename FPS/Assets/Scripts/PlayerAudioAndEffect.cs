using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioAndEffect : StateMachineBehaviour
{
    public bool fire = true;
    public bool reload = true;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        GunSystem currentGun = animator.GetComponent<GunSystem>();
        if (fire)
        {
            //获取开火声音
            AudioClip fireClip = currentGun.fireClip;
            //播放
            AudioSource.PlayClipAtPoint(fireClip, animator.transform.position);
        }
        if (reload)
        {
            //获取换弹声音
            AudioClip reloadClip = currentGun.reloadClip;
            //播放
            AudioSource.PlayClipAtPoint(reloadClip, animator.transform.position);
        }
    }
}
