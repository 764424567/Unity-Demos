/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UIStorageView
* 创建日期：2019-08-23 14:15:35
* 作者名称：王庚
* 功能描述：
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 场景保存及数据加载UI
    /// </summary>
	public class UIStorageView : UIEventSupprotView, IEventSourceSupportable
    {

        private bool canSave = true;
        private bool canLoad = true;

        private Texture2D _saveNormalImage;
        private Texture2D _saveHoverImage;
        private Texture2D _loadNormalImage;
        private Texture2D _loadHoverImage;

        private GUIStyle _saveBtnStyle;
        private GUIStyle _loadBtnStyle;

        private int _rectX = 10;
        private int _rectY = 10;

        private int _imageWidth = 110;
        private int _imageHeight = 30;

        private void Start()
        {
            _saveNormalImage = Resources.Load<Texture2D>("Buskit3DTexture/normalImageFont");
            _saveHoverImage = Resources.Load<Texture2D>("Buskit3DTexture/hoverImageFont");
            _loadNormalImage = Resources.Load<Texture2D>("Buskit3DTexture/normalImageFont1");
            _loadHoverImage = Resources.Load<Texture2D>("Buskit3DTexture/hoverImageFont1");
            _saveBtnStyle = new GUIStyle();
            _loadBtnStyle = new GUIStyle();

            _saveBtnStyle.normal.background = _saveNormalImage;
            _saveBtnStyle.hover.background = _saveHoverImage;
            _saveBtnStyle.hover.textColor = Color.white;
            _saveBtnStyle.active.background = _saveHoverImage;
            _saveBtnStyle.active.textColor = Color.white;
            _saveBtnStyle.fontSize = 16;
            _saveBtnStyle.fontStyle = FontStyle.Normal;
            _saveBtnStyle.alignment = TextAnchor.MiddleCenter;

            _loadBtnStyle.normal.background = _loadNormalImage;
            _loadBtnStyle.hover.background = _loadHoverImage;
            _loadBtnStyle.hover.textColor = Color.white;
            _loadBtnStyle.active.background = _loadHoverImage;
            _loadBtnStyle.active.textColor = Color.white;
            _loadBtnStyle.fontSize = 16;
            _loadBtnStyle.fontStyle = FontStyle.Normal;
            _loadBtnStyle.alignment = TextAnchor.MiddleCenter;
        }


        /// <summary>
        /// 获取横位置
        /// </summary>
        /// <returns></returns>
        private int GetWidth()
        {
            return Screen.width - _imageWidth - _rectX;
        }

        void OnGUI()
        {
            if (EventPool.EnableRecord)
            {

                if (canSave && GUI.Button(new Rect(GetWidth(), _rectY, _imageWidth, _imageHeight), "", _saveBtnStyle))
                {
                    EventPool pool = InjectService.Get<EventPool>();
                    if (pool.Current.Count() <= 0)
                    {
                        UnityEngine.Debug.Log("实验未开始 ");
                        return;
                    }
                    StorageSystem storage = InjectService.Get<StorageSystem>();
                    storage.BeginSave();
                }

                if (canLoad && GUI.Button(new Rect(GetWidth(), _rectY + 5 + _imageHeight, _imageWidth, _imageHeight), "", _loadBtnStyle))
                {
                    EventPool pool = InjectService.Get<EventPool>();
                    if (pool.Current.Count() > 0 || pool.Count() > 0)
                    {
                        UnityEngine.Debug.Log("实验进行中 ");
                        return;
                    }
                    StorageSystem storage = InjectService.Get<StorageSystem>();
                    storage.BeginLoad();
                    canLoad = false;
                }

                if (canLoad)
                {
                    EventPool pool = InjectService.Get<EventPool>();
                    if (pool.Current.Count() > 0 || pool.Count() > 0)
                    {
                        //for (int i = 0; i < pool.Current.Count(); i++)
                        //{
                        //    Debug.Log(pool.Current.Get(i).ToString());
                        //}
                        UnityEngine.Debug.Log("实验进行中 ");
                        canLoad = false;
                        return;
                    }
                }
            }
        }
    }
}

