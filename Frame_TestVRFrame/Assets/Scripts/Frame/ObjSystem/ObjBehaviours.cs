/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ObjBehaviours
* 创建日期：2020-05-27 19:37:42
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
//using HighlightPlus;
using DG.Tweening;
using HighlightingSystem;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class ObjBehaviours : MonoBehaviour 
	{
        
        
        [DisplayOnly]
        public string rootName;

        [DisplayOnly]
        public string objName;
        
        private Transform rootTransform;

        private void Awake()
        {
            //rootTransform = SearchRoot(transform);
            rootTransform = GetRootTransform(transform);
            if (rootTransform == null)
            {
                rootTransform = transform;
            }
            try
            {
                InjectService.Get<ObjManager>().SetObjBehaviour(rootTransform.name, transform.name, this);
                rootName = rootTransform.name;
                objName = transform.name;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("请检查IOC是否初始化");
            }
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        private Transform GetRootTransform(Transform self) {
            if (self.GetComponent<ObjDataModel>())//优先判断自身
            {
                return self;
            }
            else//自身没有则递归寻找父物体，如果父物体也没有则默认为自身
            {
                return GetRoot(self);
            }
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        private Transform GetRoot(Transform self) {
            if (self.parent)
            {
                if (self.parent.GetComponent<ObjDataModel>())
                {
                    return self.parent;
                }
                else
                {
                    return SearchRoot(self.parent);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 寻找logic根节点(弃用)
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        private Transform SearchRoot(Transform self) {
            if (self.parent)
            {
                if (self.parent.GetComponent<ObjDataModel>())
                {
                    return self.parent;
                }
                else
                {
                    return SearchRoot(self.parent);
                }
            }
            else
            {
                if (self.GetComponent<ObjDataModel>())
                {
                    return self;
                }
                else
                {
                    return null;
                }
            }
        }

        private void OnDestroy()
        {
            InjectService.Get<ObjManager>().DeleteObjBehaviour(rootTransform.name,transform.name);
        }

        #region Transform
        /// <summary>
        /// 本地坐标
        /// </summary>
        public Vector3 LocalPosition
        {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }

        /// <summary>
        /// 世界坐标
        /// </summary>
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        /// <summary>
        /// 世界旋转
        /// </summary>
        public Vector3 Rotation
        {
            get { return transform.eulerAngles; }
            set { transform.eulerAngles = value; }
        }

        /// <summary>
        /// 本地旋转
        /// </summary>
        public Vector3 LocalRotation
        {
            get { return transform.localEulerAngles; }
            set { transform.localEulerAngles = value; }
        }

        /// <summary>
        /// 缩放
        /// </summary>
        public Vector3 Scale
        {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        /// <summary>
        /// 设置激活状态
        /// </summary>
        /// <param name="isActive">是否激活</param>
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public bool IsActive()
        {
            return gameObject.activeSelf;
        }

        /// <summary>
        /// 此物体是第几个子物体
        /// </summary>
        public int ChildNumber
        {
            get { return transform.GetSiblingIndex(); }
            set { transform.SetSiblingIndex(value); }
        }

        /// <summary>
        /// 父物体
        /// </summary>
        public Transform Parent
        {
            get { return transform.parent; }
            set { transform.parent = value; }
        }
        #endregion

        #region MeshRenderer
        /// <summary>
        /// Mesh上的第一个材质球
        /// </summary>
        public Material MeshRendererMaterial
        {
            get { return transform.GetComponent<Renderer>().material; }
            set { transform.GetComponent<Renderer>().material = value; }
        }

        /// <summary>
        /// Mesh上的所有材质球
        /// </summary>
        public Material[] MeshRendererMaterials
        {
            get { return transform.GetComponent<Renderer>().materials; }
            set { transform.GetComponent<Renderer>().materials = value; }
        }

        /// <summary>
        /// 模型Mesh
        /// </summary>
        public Mesh ModelMesh
        {
            get { return transform.GetComponent<MeshFilter>().mesh; }
            set { transform.GetComponent<MeshFilter>().mesh = value; }
        }


        #endregion

        #region Animator

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animeName">动画名称</param>
        public void PlayAnime(string animeName)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            tmpAni.speed = 1;
            tmpAni.Play(animeName, 0, 0);
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="action">回调</param>
        public void PlayAnime(string animeName, UnityAction action)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            tmpAni.speed = 1;
            float animeTime = GetAnimeClipTime(tmpAni, animeName);
            tmpAni.Play(animeName, 0, 0);
            StartCoroutine(WaitTime(tmpAni, animeTime, action));
        }

        /// <summary>
        /// 播放动画（可调倍速，速度大于等于0）
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="speed">速度</param>
        /// <param name="action">回调</param>
        public void PlayAnime(string animeName,float speed, UnityAction action)
        {
            if (speed<0)
            {
                Debug.Log("此方法不适用倒播动画。");
                return;
            }
            Animator tmpAni = transform.GetComponent<Animator>();
            tmpAni.speed = speed;
            float animeTime = GetAnimeClipTime(tmpAni, animeName)/speed;
            tmpAni.Play(animeName, 0, 0);
            StartCoroutine(WaitTime(tmpAni, animeTime, action));
        }

        /// <summary>
        /// 播放动画片段
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            float normalized = startFrame / GetAnimeClipFrame(tmpAni, animeName);
            float time = Mathf.Abs(endFrame - startFrame) * GetAnimeClipSPF(tmpAni, animeName);
            tmpAni.speed = 1;
            tmpAni.Play(animeName, 0, normalized);
            StartCoroutine(WaitTime(tmpAni, time));
        }

        /// <summary>
        /// 播放动画帧
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        /// <param name="normalized">所在百分比(0-1)</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame, float normalized)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            normalized = Mathf.Clamp(normalized, 0, 1f);
            float stateNormalized = (startFrame + ((endFrame - startFrame) * normalized)) / GetAnimeClipFrame(tmpAni, animeName);
            tmpAni.speed = 0;
            tmpAni.Play(animeName, 0, stateNormalized);
        }

        /// <summary>
        /// 播放动画片段
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        /// <param name="action">回调</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame, UnityAction action)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            float normalized = startFrame / GetAnimeClipFrame(tmpAni, animeName);
            float time = Mathf.Abs(endFrame - startFrame) * GetAnimeClipSPF(tmpAni, animeName);
            tmpAni.speed = 1;
            tmpAni.Play(animeName, 0, normalized);
            StartCoroutine(WaitTime(tmpAni, time, action));
        }

        /// <summary>
        /// 播放动画片段（可调倍速，速度大于等于0）
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        /// <param name="speed">播放速度（不能为负）</param>
        /// <param name="action">回调</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame,float speed, UnityAction action)
        {
            if (speed<0)
            {
                Debug.Log("此方法不适用倒播动画。");
                return;
            }
            Animator tmpAni = transform.GetComponent<Animator>();
            float normalized = startFrame / GetAnimeClipFrame(tmpAni, animeName);
            float time = (Mathf.Abs(endFrame - startFrame) * GetAnimeClipSPF(tmpAni, animeName))/speed;
            tmpAni.speed = speed;
            tmpAni.Play(animeName, 0, normalized);
            StartCoroutine(WaitTime(tmpAni, time, action));
        }

        /// <summary>
        /// 等待时间
        /// </summary>
        /// <param name="tmpani">动画组件</param>
        /// <param name="time">时间</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        private IEnumerator WaitTime(Animator tmpani, float time, UnityAction func)
        {
            yield return new WaitForSeconds(time);
            tmpani.speed = 0;
            if (func != null)
            {
                func();
            }
        }

        /// <summary>
        /// 等待时间
        /// </summary>
        /// <param name="tmpani">动画组件</param>
        /// <param name="time">时间</param>
        /// <returns></returns>
        private IEnumerator WaitTime(Animator tmpani, float time)
        {
            yield return new WaitForSeconds(time);
            tmpani.speed = 0;
        }

        /// <summary>
        /// 获取动画片段总帧数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private float GetAnimeClipFrame(Animator animator, string name)
        {
            float frame = 0;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(name))
                {
                    return frame = clips[i].frameRate * clips[i].length;
                }
            }
            return 0;
        }

        /// <summary>
        /// 获取动画片段秒率(帧率分之一)
        /// </summary>
        /// <param name="name">动画片段名</param>
        /// <returns></returns>
        private float GetAnimeClipSPF(Animator animator, string name)
        {
            float spf = 0;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(name))
                {
                    return spf = 1 / clips[i].frameRate;
                }
            }
            return 0;
        }

        /// <summary>
        /// 获取动画片段时长
        /// </summary>
        /// <param name="name">动画名</param>
        /// <returns></returns>
        private float GetAnimeClipTime(Animator animator, string name)
        {
            float time = 0;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(name))
                {
                    return time = clips[i].length;
                }
            }
            return 0;
        }
        #endregion

        #region Click(点击)

        /// <summary>
        /// 添加物体点击事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjClickListener(UnityAction action)
        {
            if (!transform.GetComponent<ClickTrigger>())
            {
                gameObject.AddComponent<ClickTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<ClickTrigger>().OnMouseClick.AddListener(action);
        }

        /// <summary>
        /// 移除物体指定点击事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjClickListener(UnityAction action)
        {
            if (transform.GetComponent<ClickTrigger>())
            {
                transform.GetComponent<ClickTrigger>().OnMouseClick.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除物体所有点击事件
        /// </summary>
        public void RemoveObjClickListener()
        {
            if (transform.GetComponent<ClickTrigger>())
            {
                transform.GetComponent<ClickTrigger>().OnMouseClick.RemoveAllListeners();
            }
        }

        #endregion

        #region Down(按下)
        /// <summary>
        /// 添加物体按下事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjDownListener(UnityAction action)
        {
            if (!transform.GetComponent<DownTrigger>())
            {
                gameObject.AddComponent<DownTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<DownTrigger>().OnMouseDown.AddListener(action);
        }

        /// <summary>
        /// 移除指定物体按下事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjDownListener(UnityAction action)
        {
            if (transform.GetComponent<DownTrigger>())
            {
                transform.GetComponent<DownTrigger>().OnMouseDown.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除鼠标按下事件
        /// </summary>
        public void RemoveObjDownListener()
        {
            if (transform.GetComponent<DownTrigger>())
            {
                transform.GetComponent<DownTrigger>().OnMouseDown.RemoveAllListeners();
            }
        }
        #endregion

        #region Up(抬起)
        /// <summary>
        /// 添加鼠标抬起事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjUpListener(UnityAction action)
        {
            if (!transform.GetComponent<UpTrigger>())
            {
                gameObject.AddComponent<UpTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<UpTrigger>().OnMouseUp.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标抬起事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjUpListener(UnityAction action)
        {
            if (transform.GetComponent<UpTrigger>())
            {
                transform.GetComponent<UpTrigger>().OnMouseUp.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除鼠标抬起事件
        /// </summary>
        public void RemoveObjUpListener()
        {
            if (transform.GetComponent<UpTrigger>())
            {
                transform.GetComponent<UpTrigger>().OnMouseUp.RemoveAllListeners();
            }
        }
        #endregion

        #region BeginDrag(开始拖拽)
        /// <summary>
        /// 添加鼠标开始拖拽监听
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjBeginDragListener(UnityAction action)
        {
            if (!transform.GetComponent<BeginDragTrigger>())
            {
                gameObject.AddComponent<BeginDragTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<BeginDragTrigger>().OnMouseBeginDrag.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标开始拖拽监听
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjBeginDragListener(UnityAction action)
        {
            if (transform.GetComponent<BeginDragTrigger>())
            {
                transform.GetComponent<BeginDragTrigger>().OnMouseBeginDrag.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标开始拖拽监听
        /// </summary>
        public void RemoveObjBeginDragListener()
        {
            if (transform.GetComponent<BeginDragTrigger>())
            {
                transform.GetComponent<BeginDragTrigger>().OnMouseBeginDrag.RemoveAllListeners();
            }
        }
        #endregion

        #region Drag(拖拽)
        /// <summary>
        /// 添加物体拖拽事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjDragListener(UnityAction action)
        {
            if (!transform.GetComponent<DragTrigger>())
            {
                gameObject.AddComponent<DragTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<DragTrigger>().OnMouseDrag.AddListener(action);
        }

        /// <summary>
        /// 移除指定物体拖拽事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjDragListener(UnityAction action)
        {
            if (transform.GetComponent<DragTrigger>())
            {
                transform.GetComponent<DragTrigger>().OnMouseDrag.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除物体拖拽事件
        /// </summary>
        public void RemoveObjDragListener()
        {
            if (transform.GetComponent<DragTrigger>())
            {
                transform.GetComponent<DragTrigger>().OnMouseDrag.RemoveAllListeners();
            }
        }
        #endregion

        #region EndDrag(结束拖拽)
        /// <summary>
        /// 添加鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjEndDragListener(UnityAction action)
        {
            if (!transform.GetComponent<EndDragTrigger>())
            {
                gameObject.AddComponent<EndDragTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<EndDragTrigger>().OnMouseEndDrag.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标拖拽监听
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjEndDragListener(UnityAction action)
        {
            if (transform.GetComponent<EndDragTrigger>())
            {
                transform.GetComponent<EndDragTrigger>().OnMouseEndDrag.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标拖拽监听
        /// </summary>
        public void RemoveObjEndDragListener()
        {
            if (transform.GetComponent<EndDragTrigger>())
            {
                transform.GetComponent<EndDragTrigger>().OnMouseEndDrag.RemoveAllListeners();
            }
        }
        #endregion

        #region Drop (结束拖拽)
        /// <summary>
        /// 添加鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjDropListener(UnityAction action)
        {
            if (!transform.GetComponent<DropTrigger>())
            {
                gameObject.AddComponent<DropTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<DropTrigger>().OnMouseDrop.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjDropListener(UnityAction action)
        {
            if (transform.GetComponent<DropTrigger>())
            {
                transform.GetComponent<DropTrigger>().OnMouseDrop.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标结束拖拽监听
        /// </summary>
        public void RemoveObjDropListener()
        {
            if (transform.GetComponent<DropTrigger>())
            {
                transform.GetComponent<DropTrigger>().OnMouseDrop.RemoveAllListeners();
            }
        }

        #endregion

        #region Enter (进入)
        /// <summary>
        /// 添加鼠标进入物体事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjEnterListener(UnityAction action)
        {
            if (!transform.GetComponent<EnterTrigger>())
            {
                gameObject.AddComponent<EnterTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<EnterTrigger>().OnMouseEnter.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标进入物体事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjEnterListener(UnityAction action)
        {
            if (transform.GetComponent<EnterTrigger>())
            {
                transform.GetComponent<EnterTrigger>().OnMouseEnter.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除鼠标进入物体事件
        /// </summary>
        public void RemoveObjEnterListener()
        {
            if (transform.GetComponent<EnterTrigger>())
            {
                transform.GetComponent<EnterTrigger>().OnMouseEnter.RemoveAllListeners();
            }
        }
        #endregion

        #region Exit (离开)
        /// <summary>
        /// 添加鼠标离开物体事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjExitListener(UnityAction action)
        {
            if (!transform.GetComponent<ExitTrigger>())
            {
                gameObject.AddComponent<ExitTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<ExitTrigger>().OnMouseExit.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标离开物体事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjExitListener(UnityAction action)
        {
            if (transform.GetComponent<ExitTrigger>())
            {
                transform.GetComponent<ExitTrigger>().OnMouseExit.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除鼠标离开物体事件
        /// </summary>
        public void RemoveObjExitListener()
        {
            if (transform.GetComponent<ExitTrigger>())
            {
                transform.GetComponent<ExitTrigger>().OnMouseExit.RemoveAllListeners();
            }
        }
        #endregion

        #region Scroll (滚轮)
        /// <summary>
        /// 添加鼠标滚轮监听
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjScrollListener(UnityAction action)
        {
            if (!transform.GetComponent<ScrollTrigger>())
            {
                gameObject.AddComponent<ScrollTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<ScrollTrigger>().OnMouseScroll.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标滚轮监听
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjScrollListener(UnityAction action)
        {
            if (transform.GetComponent<ScrollTrigger>())
            {
                transform.GetComponent<ScrollTrigger>().OnMouseScroll.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标滚轮监听
        /// </summary>
        public void RemoveObjScrollListener()
        {
            if (transform.GetComponent<ScrollTrigger>())
            {
                transform.GetComponent<ScrollTrigger>().OnMouseScroll.RemoveAllListeners();
            }
        }
        #endregion

        #region Press (按住)
        /// <summary>
        /// 添加鼠标按住监听
        /// </summary>
        /// <param name="action">事件</param>
        public void AddObjPressListener(UnityAction action)
        {
            if (!transform.GetComponent<PressTrigger>())
            {
                gameObject.AddComponent<PressTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<PressTrigger>().OnMousePress.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标按住监听
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveObjPressListener(UnityAction action)
        {
            if (transform.GetComponent<PressTrigger>())
            {
                transform.GetComponent<PressTrigger>().OnMousePress.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标滚轮监听
        /// </summary>
        public void RemoveObjPressListener()
        {
            if (transform.GetComponent<PressTrigger>())
            {
                transform.GetComponent<PressTrigger>().OnMousePress.RemoveAllListeners();
            }
        }
        #endregion

        #region 高亮插件

        /// <summary>
        /// 设置物体高亮
        /// </summary>
        /// <param name="isLight">是否高亮</param>
        public void SetObjHighlight(bool isLight) {
            GradientColorKey[] flashingColorKeys = new GradientColorKey[]
        {
            new GradientColorKey(SaveValue.HighlightColor, 0f),
            new GradientColorKey(SaveValue.HighlightColor, 1f)
        };
            GradientAlphaKey[] flashingAlphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(0f, 0f),
            new GradientAlphaKey(1f, 1f),
        };
            if (!gameObject.GetComponent<Highlighter>() && !isLight)
            {
                return;
            }
            if (!transform.GetComponent<Highlighter>())
            {
                gameObject.AddComponent<Highlighter>();
            }
            if (isLight)
            {
                transform.GetComponent<Highlighter>().tweenGradient.SetKeys(flashingColorKeys, flashingAlphaKeys);
                transform.GetComponent<Highlighter>().TweenStart();
            }
            else
            {
                transform.GetComponent<Highlighter>().TweenStop();
            }
        }

        /// <summary>
        /// 设置物体高亮
        /// </summary>
        /// <param name="isLight">是否高亮</param>
        /// <param name="lightColor">高亮颜色</param>
        public void SetObjHighlight(bool isLight,Color lightColor)
        {
            if (!gameObject.GetComponent<Highlighter>() && !isLight)
            {
                return;
            }
            if (!transform.GetComponent<Highlighter>())
            {
                gameObject.AddComponent<Highlighter>();
            }

            GradientColorKey[] flashingColorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0f, 1f, 1f, 1f), 0f),
            new GradientColorKey(new Color(0f, 1f, 1f, 1f), 1f)
        };
            GradientAlphaKey[] flashingAlphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(0f, 0f),
            new GradientAlphaKey(1f, 1f),
        };
            if (isLight)
            {
                flashingColorKeys[0].color = lightColor; 
                flashingColorKeys[1].color = lightColor;
                transform.GetComponent<Highlighter>().tweenGradient.SetKeys(flashingColorKeys, flashingAlphaKeys);
                transform.GetComponent<Highlighter>().TweenStart();
            }
            else
            {
                transform.GetComponent<Highlighter>().TweenStop();
            }
        }

        #endregion

        #region DoTween插件
        /// <summary>
        /// 正播DT动画
        /// </summary>
        public void PlayDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DOPlayForward();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 倒播DT动画
        /// </summary>
        public void PlayDTAnimeBack()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DOPlayBackwards();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 正播DT动画结束后执行方法
        /// </summary>
        /// <param name="action">方法</param>
        public void PlayDTAnime(UnityAction action)
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.tween.OnStepComplete(() => {
                    tmpAnime.tween.OnStepComplete(null);
                    action();

                });
                tmpAnime.DOPlayForward();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 倒播DT动画结束后执行方法
        /// </summary>
        /// <param name="action">方法</param>
        public void PlayDTAnimeBack(UnityAction action)
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.tween.OnStepComplete(() => {
                    tmpAnime.tween.OnStepComplete(null);
                    action();

                });
                tmpAnime.DOPlayBackwards();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 停止DT动画
        /// </summary>
        public void PauseDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DOPause();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 重播DT动画
        /// </summary>
        public void ReplayDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DORestart();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 重置动画回初始状态
        /// </summary>
        public void RewindDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DORewind();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }
        #endregion
    }
}

