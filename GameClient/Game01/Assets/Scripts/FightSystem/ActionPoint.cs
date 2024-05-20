/**********************************************************
文件：ActionPoint.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 11:49:45
功能：Nothing
/**********************************************************/

using System;
using System.Collections.Generic;

/// <summary>
/// 行动点定义，一次战斗行动<see cref="IActionExecution"/>会触发战斗实体一系列的行动点<see cref="ActionPoint"/>
/// </summary>
public sealed class ActionPoint
{
    public List<Action<IActionExecution>> Actions { get; set; } = new List<Action<IActionExecution>>();

    public void AddListener(Action<IActionExecution> action)
    {
        Actions.Add(action);
    }

    public void RemoveListener(Action<IActionExecution> action)
    {
        Actions.Remove(action);
    }

    public void TriggerAllActions(IActionExecution actionExecution)
    {
        if(Actions.Count == 0)
        {
            return;
        }
        for(int i = Actions.Count - 1; i >= 0; i--)
        {
            Action<IActionExecution> action = Actions[i];
            action.Invoke(actionExecution);
        }
    }
}
