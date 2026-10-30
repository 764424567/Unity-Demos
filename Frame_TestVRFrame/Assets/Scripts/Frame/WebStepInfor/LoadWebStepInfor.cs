/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LoadWebStepInfor
* 创建日期：2021-04-28 10:14:50
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：读取步骤信息
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class LoadWebStepInfor : MonoBehaviour 
	{

        private void Start()
        {
            StartLoadStepInfor("StepInfor", LoadStepInforCallBack);
        }

        /// <summary>
        /// 考题回调
        /// </summary>
        /// <param name="message"></param>
        private void LoadStepInforCallBack(string message)
        {
            string value = StringAndZip.ZipToString(message);
            List<WebStepInfor> webStepInfors = JsonConvert.DeserializeObject<List<WebStepInfor>>(value);
            InjectService.Get<WebStepInforManager>().SaveStepInfors(webStepInfors);
        }

        /// <summary>
        /// 加载考题
        /// </summary>
        /// <param name="excelName"></param>
        /// <param name="LoadStepInforCallBack"></param>
        private void StartLoadStepInfor(string excelName, UnityAction<string> LoadStepInforCallBack)
        {
            StartCoroutine(LoadStepInfor(excelName, LoadStepInforCallBack));
        }

        private IEnumerator LoadStepInfor(string name, UnityAction<string> LoadStepInforCallBack)
        {
            string url = Application.streamingAssetsPath + "/StepInfor/" + name + ".txt";
            var request = UnityWebRequest.Get(url);
            request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
                yield break;
            }
            while (!request.isDone)
            {
                yield return 0;
            }
            string message = request.downloadHandler.text;
            LoadStepInforCallBack(message);
        }
    }
}

