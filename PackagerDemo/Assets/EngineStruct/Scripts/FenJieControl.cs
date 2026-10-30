using DG.Tweening;
using HighlightPlus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FenJieControl : MonoBehaviour
{
    public Transform camTarget;
    public Transform _canvas;
    public Animator anim;
    public GameObject[] models;
    public GameObject[] panels;
    Tweener twen;
    // Start is called before the first frame update
    void Start()
    {
        _canvas.Find("分解").AddActionToButton(FenJie);
        _canvas.Find("合并").AddActionToButton(ZuHe);
        ModelClickAction(models[0], 0);
        ModelClickAction(models[1], 1);
        ModelClickAction(models[2], 2);
        ModelClickAction(models[3], 3);
        ModelClickAction(models[4], 4);
        ModelClickAction(models[5], 5);
        ModelClickAction(models[6], 6);
        ModelClickAction(models[7], 7);
        ModelClickAction(models[8], 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FenJie()
    {
        _canvas.Find("分解").GetComponent<Button>().enabled = false;
        anim.SetBool("isChaiKai",true);
        models[7].transform.parent.gameObject.SetActive(true);
        AnimatorPlayed_time(anim, "Take-拆开", () => {
            models[7].transform.parent.DOLocalMove(new Vector3(-0.4001769f, 1.243f, 0), 1f).SetEase(Ease.Linear).OnComplete(() => {
                for (int i = 0; i < models.Length; i++)
                {
                    models[i].GetComponent<BoxCollider>().enabled = true;
                }
                _canvas.Find("分解").GetComponent<Button>().enabled = true;
                _canvas.Find("分解").gameObject.SetActive(false);
                _canvas.Find("合并").gameObject.SetActive(true);
            });

        });
    }
    public void ZuHe()
    {
        _canvas.Find("合并").GetComponent<Button>().enabled = false;
        for (int i = 0; i < models.Length; i++)
        {
            models[i].GetComponent<BoxCollider>().enabled = false;
            panels[i].SetActive(false);
        }
        if (twen != null)
        {
            twen.Kill();
        }
        models[7].transform.parent.DOLocalMove(new Vector3(-0.4001769f,0, 0), 1f).SetEase(Ease.Linear).OnComplete(() => {
            models[7].transform.parent.gameObject.SetActive(false);
        });
        float l = Vector3.Distance(camTarget.localPosition, new Vector3(0, 0, 0));
        float t = l / 2;
        twen=camTarget.DOMove(new Vector3(0,0,0), t).SetEase(Ease.Linear).OnComplete(() => {
            anim.SetBool("isChaiKai", false);
            AnimatorPlayed_time(anim, "Take-合并", () => {
                _canvas.Find("合并").GetComponent<Button>().enabled = true;
                _canvas.Find("分解").gameObject.SetActive(true);
                _canvas.Find("合并").gameObject.SetActive(false);
            });
        });
    }
    public void AnimatorPlayed_time(Animator animator, string clipName, Action endAct = null)
    {
        StartCoroutine(PlayAnimationItor_time(animator, clipName, endAct));
    }
    /// <summary>
    /// Animation动画播放迭代器
    /// </summary>
    /// <param name="animator">Animation组件</param>
    /// <param name="clipName">clip片段名</param>
    /// <param name="endAct">委托函数</param>
    /// <returns></returns>
    private IEnumerator PlayAnimationItor_time(Animator animator, string clipName, Action endAct)
    {
        while (true)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName(clipName))
            {
                break;
            }
            yield return null;
        }
        while (true)
        {
            AnimatorStateInfo stateInfo2 = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo2.normalizedTime >= 0.999f)
            {
                endAct?.Invoke();
                StopCoroutine("PlayAnimationItor");
                break;
            }
            yield return null;
        }
    }
    public void ModelClickAction(GameObject go, int num)
    {
        go.AddListener(EventTriggerType.PointerClick, (PointerEventData eventData) =>
        {
            float l = Vector3.Distance(camTarget.localPosition, go.transform.position);
            float t = l / 2;
            if (twen!=null)
            {
                twen.Kill();
            }
            twen =camTarget.DOMove(go.transform.position, t).SetEase(Ease.Linear);
            for (int i = 0; i < panels.Length; i++)
            {
                if (i == num)
                {
                    panels[num].gameObject.SetActive(true);
                }
                else
                {
                    panels[i].gameObject.SetActive(false);
                }
            }
        });
    }

}
