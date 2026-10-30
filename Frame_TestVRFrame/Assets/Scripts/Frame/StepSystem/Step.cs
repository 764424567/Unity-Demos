/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: Step.cs
  Author:张辰       Version :1.0          Date: 2017-12-4
  Description:步骤类
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{

    public class Step
    {
        /// <summary>
        /// 步骤触发物体枚举
        /// </summary>
        public enum TriggerType
        {
            /// <summary>
            /// 无触发
            /// </summary>
            none = 0,
            /// <summary>
            /// 3D物体触发
            /// </summary>
            Obj,
            /// <summary>
            /// 3D物体高亮触发
            /// </summary>
            ObjLight,
            /// <summary>
            /// UI触发
            /// </summary>
            UI,
            /// <summary>
            /// UI触发（带框）
            /// </summary>
            UIFrame,
            /// <summary>
            /// UI高亮触发
            /// </summary>
            UILight,
            /// <summary>
            /// UI框高亮触发
            /// </summary>
            UIFrameLight
        }

        

        /// <summary>
        /// 跳步编号
        /// </summary>
        private ushort stepNumber;

        /// <summary>
        /// 步骤名字
        /// </summary>
        private string stepAudioName;

        /// <summary>
        /// 步骤开始方法
        /// </summary>
        private UnityAction stepStartFunction;

        /// <summary>
        /// 步骤提示
        /// </summary>
        private string stepMassage;

        /// <summary>
        /// 步骤触发物体
        /// </summary>
        private NamePair stepTriggerObjName;

        /// <summary>
        /// 步骤触发物体种类
        /// </summary>
        private TriggerType stepTriggerType;

        /// <summary>
        /// 步骤执行的方法
        /// </summary>
        private UnityAction stepFunction;

        /// <summary>
        /// 步骤结束时执行的方法
        /// </summary>
        private UnityAction stepEndFunction;

        /// <summary>
        /// 步骤编号
        /// </summary>
        public ushort StepNumber
        {
            get { return stepNumber; }
        }

        /// <summary>
        /// 步骤名字
        /// </summary>
        public string StepAudioName
        {
            get { return stepAudioName; }
        }

        /// <summary>
        /// 步骤开始方法
        /// </summary>
        public UnityAction StepStartFunction {
            get { return stepStartFunction; }
        }

        /// <summary>
        /// 步骤提示
        /// </summary>
        public string StepMassage
        {
            get { return stepMassage; }
        }

        /// <summary>
        /// 步骤高亮物体
        /// </summary>
        public NamePair StepTriggerObjName
        {
            get { return stepTriggerObjName; }
        }

        /// <summary>
        /// 步骤触发物体类型
        /// </summary>
        public TriggerType StepTriggerType {
            get { return stepTriggerType; }
        }

        /// <summary>
        /// 步骤执行的方法
        /// </summary>
        public UnityAction StepFunction
        {
            get { return stepFunction; }
        }

        /// <summary>
        /// 步骤结束方法
        /// </summary>
        public UnityAction StepEndFunction
        {
            get { return stepEndFunction; }
        }


        protected Step() { }

        /// <summary>
        /// 新建步骤
        /// </summary>
        /// <param name="stepNumber">跳步序号</param>
        /// <param name="stepAudioName">步骤画外音名字</param>
        /// <param name="stepStartFunction">步骤开始前执行的方法</param>
        /// <param name="stepMassage">步骤提示</param>
        /// <param name="stepTriggerObjName">高亮物体名字</param>
        /// <param name="stepTriggerType">高亮类型</param>
        /// <param name="stepFunction">步骤方法</param>
        /// <param name="stepEndFunction">步骤结束后执行的方法</param>
        public Step(ushort stepNumber, string stepAudioName,UnityAction stepStartFunction, string stepMassage, NamePair stepTriggerObjName, TriggerType stepTriggerType, UnityAction stepFunction ,UnityAction stepEndFunction)
        {
            this.stepNumber = stepNumber;
            this.stepAudioName = stepAudioName;
            this.stepStartFunction = stepStartFunction;
            this.stepMassage = stepMassage;
            this.stepTriggerObjName = stepTriggerObjName;
            this.stepTriggerType = stepTriggerType;
            this.stepFunction = stepFunction;
            this.stepEndFunction = stepEndFunction;
        }

    }

    [SerializeField]
    public class NamePair {
        private string rootName = string.Empty;

        private string objName = string.Empty;

        /// <summary>
        /// 根物体名字
        /// </summary>
        public string RootName {
            get { return rootName; }
            set { rootName = value; }
        }

        /// <summary>
        /// 对象名字
        /// </summary>
        public string ObjName {
            get { return objName; }
            set { objName = value; }
        }

        public NamePair(string rootName,string objName) {
            this.rootName = rootName;
            this.objName = objName;
        }
    }
}

