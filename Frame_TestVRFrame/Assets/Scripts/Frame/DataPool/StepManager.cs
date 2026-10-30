/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: StepManager.cs
  Author:张辰       Version :1.0          Date: 2017-11-15
  Description:步骤方法存储脚本
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{
    public class StepManager 
    {
        private const ushort orderStepStart = 0;
        private const ushort jumpStepStart = 3000;
        private ushort orderIndex = 1;
        public enum StepID
        {
            /// <summary>
            /// 顺序步骤
            /// </summary>
            orderStep = orderStepStart,
            /// <summary>
            /// 跳步步骤
            /// </summary>
            jumpStep = jumpStepStart,
        }

        /// <summary>
        /// 步骤存储链表
        /// </summary>
        private List<Step> steps = new List<Step>();

        /// <summary>
        /// 步骤下标
        /// </summary>
        private int stepIndex = -1;

        /// <summary>
        /// 添加步骤
        /// </summary>
        /// <param name="stepNumber">步骤序号（唯一）</param>
        /// <param name="stepAudioName">步骤画外音名字</param>
        /// <param name="stepStartFunction">步骤开始前执行的方法</param>
        /// <param name="stepMassage">步骤提示</param>
        /// <param name="stepTriggerObjName">步骤高亮物体</param>
        /// <param name="stepTriggerType">高亮类型</param>
        /// <param name="stepFunction">步骤执行的方法</param>
        /// <param name="stepEndFunction">步骤结束后执行的方法</param>
        public void AddStep(StepID stepNumber, string stepAudioName,UnityAction stepStartFunction, string stepMassage, NamePair stepTriggerObjName, Step.TriggerType stepTriggerType, UnityAction stepFunction,UnityAction stepEndFunction)
        {
            if (stepNumber < StepID.jumpStep)
            {
                stepNumber = StepID.orderStep + orderIndex;
                orderIndex++;
            }
            steps.Add(new Step((ushort)stepNumber, stepAudioName, stepStartFunction, stepMassage, stepTriggerObjName, stepTriggerType, stepFunction, stepEndFunction));
        }

        /// <summary>
        /// 跳入指定步骤
        /// </summary>
        /// <param name="stepNumber">步骤序号</param>
        public void JumpStep(StepID stepNumber)
        {
            for (int i = 0; i < steps.Count; i++)
            {
                if (steps[i].StepNumber == (ushort)stepNumber)
                {
                    stepIndex = i;
                    Debug.Log("当前步骤：" + (stepIndex + 1) + "\n总步骤数：" + steps.Count);
                    return;
                }
            }
            Debug.Log("此步骤：" + stepNumber + "不存在");
        }

        /// <summary>
        /// 进入下一步
        /// </summary>
        public void NextStep()
        {
            if (stepIndex >= -1 && stepIndex < steps.Count - 1)
            {
                stepIndex++;
                Debug.Log("当前步骤：" +(stepIndex + 1) + "\n总步骤数：" + steps.Count);
            }
            else
            {
                stepIndex = -1;
                Debug.Log("所有步骤结束");
            }
        }

        /// <summary>
        /// 清空步骤存储
        /// </summary>
        public void RemoveAllStep() {
            steps.Clear();
            StepIndex = -1;
        }

        /// <summary>
        /// 步骤下标
        /// </summary>
        public int StepIndex
        {
            get { return stepIndex; }
            set { stepIndex = value; }
        }

        /// <summary>
        /// 获取步骤编号
        /// </summary>
        public int GetStepNumber
        {
            get { return steps[stepIndex].StepNumber; }
        }

        /// <summary>
        /// 获取步骤画外音名字
        /// </summary>
        public string GetStepAudioName
        {
            get { return steps[stepIndex].StepAudioName; }
        }

        /// <summary>
        /// 获取步骤开始前执行的方法
        /// </summary>
        public UnityAction GetStepStartFunction {
            get { return steps[stepIndex].StepStartFunction; }
        }

        /// <summary>
        /// 获取步骤提示
        /// </summary>
        public string GetStepMassage
        {
            get { return steps[stepIndex].StepMassage; }
        }

        /// <summary>
        /// 获取步骤触发物体
        /// </summary>
        public NamePair GetStepTriggerObjName
        {
            get { return steps[stepIndex].StepTriggerObjName; }
        }

        /// <summary>
        /// 获取步骤触发物体种类
        /// </summary>
        public Step.TriggerType GetStepTriggerType
        {
            get { return steps[stepIndex].StepTriggerType; }
        }

        /// <summary>
        /// 获取步骤方法
        /// </summary>
        public UnityAction GetStepFunction
        {
            get { return steps[stepIndex].StepFunction; }
        }

        /// <summary>
        /// 步骤结束执行的方法
        /// </summary>
        public UnityAction GetStepEndFunction {
            get { return steps[stepIndex].StepEndFunction; }
        }


    }
}

