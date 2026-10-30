/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ZC_FrameBuild
* 创建日期：2019-05-13 13:39:02
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections;
using HighlightingSystem;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class ZC_FrameBuild : Editor 
	{
        [MenuItem("Tools/新建框架")]
        public static void BuildFrame() {
            if (GameObject.Find("Main"))
            {
                Debug.Log("框架已存在");
                return;
            }
            GameObject main = new GameObject("Main");
            main.AddComponent<IOC>();
            GameObject audio = new GameObject("Audio");
            audio.transform.parent = main.transform;
            audio.AddComponent<AudioWebLoadSystem>();
            GameObject stepAudio = new GameObject("StepAudio");
            stepAudio.transform.parent = audio.transform;
            stepAudio.tag = ObjectTag.Tag;
            stepAudio.AddComponent<AudioSource>();
            stepAudio.AddComponent<ObjDataModel>();
            stepAudio.AddComponent<AudioSystemLogic>();
            GameObject bGMAudio = new GameObject("BGMAudio");
            bGMAudio.transform.parent = audio.transform;
            bGMAudio.tag = ObjectTag.Tag;
            bGMAudio.AddComponent<AudioSource>().loop = true;
            bGMAudio.AddComponent<ObjDataModel>();
            bGMAudio.AddComponent<AudioSystemLogic>();

            if (!GameObject.Find("Main Camera").GetComponent<PhysicsRaycaster>())
            {
                GameObject.Find("Main Camera").AddComponent<PhysicsRaycaster>();
            }
            if (!GameObject.Find("Main Camera").GetComponent<HighlightingRenderer>())
            {
                GameObject.Find("Main Camera").AddComponent<HighlightingRenderer>();
            }
            Debug.Log("框架创建完成");
        }

        

        

        
	}
}

