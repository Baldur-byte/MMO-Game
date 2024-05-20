/**********************************************************
文件：EventComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 11:44:22
功能：Nothing
/**********************************************************/

using System;
using System.Collections.Generic;

/// <summary>
/// 事件组件
/// </summary>
public class EventComponent : Component
{
    private Dictionary<string, List<object>> EventNameToActionLists = new Dictionary<string, List<object>>();
    //private Dictionary<string, List<object>> EventNameToActionLists = new Dictionary<string, List<object>>();

    public new T Publish<T>(T TEvent) where T : class
    {
        if(EventNameToActionLists.TryGetValue(typeof(T).Name, out List<object> list))
        {
            foreach(Action<T> item in list)
            {
                item.Invoke(TEvent); 
            }
        }
        return TEvent;
    }

    public void Execute<T>(string eventName, T TEvent) where T : class
    {
        if (EventNameToActionLists.TryGetValue(eventName, out List<object> list))
        {
            foreach (Action<T> item in list)
            {
                item.Invoke(TEvent);
            }
        }
    }

    public void Subscribe<T>(Action<T> action) where T : class
    {
        var name = typeof(T).Name;
        if(!EventNameToActionLists.TryGetValue(name, out List<object> list))
        {
            list = new List<object>();
            EventNameToActionLists.Add(name, list);
        }
        list.Add(action);
    }

    public void UnSubscribe<T>(Action<T> action) where T : class
    {
        if(EventNameToActionLists.TryGetValue(typeof(T).Name, out var list))
        {
            list.Remove(action);
        }
    }
}
