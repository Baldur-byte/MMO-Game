/**********************************************************
文件：ConditionComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 12:09:41
功能：Nothing
/**********************************************************/

using System;
using System.Collections.Generic;
/// <summary>
/// 条件管理组件，在这里管理一个战斗实体所有条件达成的事件，添加监听、移除监听和触发
/// </summary>
public sealed class ConditionComponent : Component
{
    private Dictionary<string, ConditionEntity> Conditions { get; set; } = new Dictionary<string, ConditionEntity>();

    public void AddListener(ConditionType conditionType, Action action, object paramObj = null)
    {
        switch (conditionType)
        {
            case ConditionType.CustomCondition:
                break;
            case ConditionType.WhenHPLower:
                break;
            case ConditionType.WhenHPctLower:
                break;
            case ConditionType.WhenInTimeNoDamage:
                var time = (float)paramObj;
                var condition = Entity.AddChild<ConditionEntity>();
                var component = condition.AddComponent<ConditionComponent>(time);
                Conditions.Add(conditionType.ToString(), condition);
                break;
        }
    }

    public void RemoveListener(ConditionType conditionType)
    {
        if (Conditions.ContainsKey(conditionType.ToString()))
        {
            Entity.Destory(Conditions[conditionType.ToString()]);
            Conditions.Remove(conditionType.ToString());
        }
    }
}
