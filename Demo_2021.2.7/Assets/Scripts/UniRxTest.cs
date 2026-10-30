using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class UniRxTest : MonoBehaviour
{
    private bool stopLoop = false;//动画控制
    void Start()
    {
    }

    /// <summary>
    /// Animation播放指定帧的动画
    /// </summary>
    /// <param name="myAnim">动画组件</param>
    /// <param name="startTimeInt">开始时间</param>
    /// <param name="endTimeInt">结束时间</param>
    private async void PlayAnimation(Animation myAnim, int startTimeInt, int endTimeInt)
    {
        int speed = GetSpeed(startTimeInt, endTimeInt);
        float frame = GetFrame(myAnim);
        float startTime;
        float endTime;
        if (speed == 1)
        {
            startTime = frame * startTimeInt;
            endTime = frame * endTimeInt;
        }
        else
        {
            startTime = frame * endTimeInt;
            endTime = frame * startTimeInt;
        }
        stopLoop = false;

        while (!stopLoop)
        {
            myAnim[myAnim.clip.name].time = startTime;//跳过开始帧
            myAnim[myAnim.clip.name].speed = speed;//正播还是倒播
            myAnim.Play(myAnim.clip.name);//Play()
            await UniTask.DelayFrame(1);//帧延缓，等Play()启动                                                               
            await UniTask.WaitUntil(() => myAnim[myAnim.clip.name].time > endTime);//播放到指定的进度点则停止        
            myAnim.Stop();//停止播放
            stopLoop = true;//停止播放
        }
    }

    // 判断是正播还是倒播
    int GetSpeed(int startTime, int endTime)
    {
        if (endTime - startTime > 0)
        {
            return 1;
        }
        else if (endTime - startTime < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    // 得到动画的播放帧率
    float GetFrame(Animation myAnim)
    {
        return myAnim[myAnim.clip.name].length / 100;
    }
}