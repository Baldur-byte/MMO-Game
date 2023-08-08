/**********************************************************
文件：ConditionWhenInTimeNoDamageComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 14:16:22
功能：Nothing
/**********************************************************/

using System;
using UnityEngine;
/// <summary>
/// 一段时间内没有受到伤害的条件
/// </summary>
public class ConditionWhenInTimeNoDamageComponent : Component
{
    /// <summary>
    /// 没有受到伤害的计时器
    /// </summary>
    private GameTimer NoDamageTimer { get; set; }

    public override bool DefaultEnable => false;

    public override void Awake(object initData)
    {
        var time = (float)initData;
        NoDamageTimer = new GameTimer(time);
        Entity.GetParent<CombatEntity>().AddListenActionPoint(ActionPointType.AfterReceiveDamage, WhenReceiveDamage);
    }

    public void StartListen(Action whenNoDamageInTimeCallBack)
    {
        //开始监听时才会激活组件
        NoDamageTimer.OnFinsih(whenNoDamageInTimeCallBack);
        Enable = true;

        //重设计时器
        NoDamageTimer.Reset();
    }

    public override void Update()
    {
        if (NoDamageTimer.IsRunning)
        {
            NoDamageTimer.UpdateAsFinish(Time.deltaTime);
        }
    }

    public void WhenReceiveDamage(IActionExecution actionExecution)
    {
        NoDamageTimer.Reset();
    }
}
