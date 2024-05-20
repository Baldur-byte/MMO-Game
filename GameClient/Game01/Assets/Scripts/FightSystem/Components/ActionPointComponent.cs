/**********************************************************
文件：ActionPointComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 11:27:56
功能：Nothing
/**********************************************************/

using System;
using System.Collections.Generic;
/// <summary>
/// 行动点组件，管理一个战斗实体所有行动点的添加监听、移出监听和触发监听
/// </summary>
public class ActionPointComponent : Component
{
    private Dictionary<string, ActionPoint> actionPoints { get; set; } = new Dictionary<string, ActionPoint>();

    public void AddListener(ActionPointType actionPointType, Action<IActionExecution> action)
    {
        if (!actionPoints.ContainsKey(actionPointType.ToString()))
        {
            actionPoints.Add(actionPointType.ToString(), new ActionPoint());
        }
        actionPoints[actionPointType.ToString()].AddListener(action);
    }

    public void RemoveListener(ActionPointType actionPointType, Action<IActionExecution> action)
    {
        if (actionPoints.ContainsKey(actionPointType.ToString()))
        {
            actionPoints[actionPointType.ToString()].RemoveListener(action);
        }
    }

    public ActionPoint GetActionPoint(ActionPointType actionPointType)
    {
        if (actionPoints.TryGetValue(actionPointType.ToString(), out var actionPoint)) ;
        return actionPoint;
    }

    public void TriggerActionPoint(ActionPointType actionPointType, IActionExecution actionExecution)
    {
        if(actionPoints.TryGetValue(actionPointType.ToString(), out var actionPoint))
        {
            actionPoint.TriggerAllActions(actionExecution);
        }
    }
}
