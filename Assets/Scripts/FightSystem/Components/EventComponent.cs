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
    private Dictionary<Type, List<object>> TypeEvent2ActionLists = new Dictionary<Type, List<object>>();

    //private Dictionary<string, List<object>> 

    public new T Publish<T>(T TEvent) where T : class
    {
        if(TypeEvent2ActionLists.TryGetValue(typeof(T), out List<object> list))
        {
            foreach(Action<T> item in list)
            {
                item.Invoke(TEvent);
            }
        }
        return TEvent;
    }

    public void Subscribe<T>(Action<T> action) where T : class
    {
        var type = typeof(T);
        if(!TypeEvent2ActionLists.TryGetValue((Type)type, out List<object> list))
        {
            list = new List<object>();
            TypeEvent2ActionLists.Add(type, list);
        }
        list.Add(action);
    }

    public void UnSubscribe<T>(Action<T> action) where T : class
    {
        if(TypeEvent2ActionLists.TryGetValue(typeof(T), out var list))
        {
            list.Remove(action);
        }
    }
}
