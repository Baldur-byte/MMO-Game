/**********************************************************
文件：Entity.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 11:20:52
功能：Nothing
/**********************************************************/

using System;
using System.Collections.Generic;

public abstract partial class Entity
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long InstanceId { get; set; }

    public Entity Parent { get; private set; }

    public List<Entity> Children { get; private set; } = new List<Entity>();

    /// <summary>
    /// 实体上附带的组件
    /// </summary>
    public Dictionary<Type, Component> Components { get; set; } = new Dictionary<Type, Component>();

    #region 生命周期
    public virtual void Awake()
    {

    }

    public virtual void Awake(object initData)
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Start(object initData)
    {

    }

    public virtual void Update()
    {

    }

    public virtual void OnDestory()
    {

    }

    private void Dispose()
    {
        if (Children.Count > 0)
        {
            for (int i = Children.Count - 1; i >= 0; i--)
            {
                Destory(Children[i]);
            }
            Children.Clear();
        }

        Parent?.RemoveChild(this);

        foreach(var component in Components.Values)
        {
            Component.Destory(component);
        }
        Components.Clear();
    }

    public virtual void OnSetParent(Entity preParent, Entity nowParent)
    {

    }
    #endregion

    /// <summary>
    /// 执行订阅的事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="TEvent"></param>
    /// <returns></returns>
    public T Publish<T>(T TEvent) where T : class
    {
        var eventComponent = GetComponent<EventComponent>();
        if(eventComponent == null)
        {
            return TEvent;
        }
        eventComponent.Publish(TEvent);
        return TEvent;
    }

    public void Subscribe<T>(Action<T> action) where T : class
    {
        var eventComponent = GetComponent<EventComponent>();
        if(eventComponent == null)
        {
            eventComponent = AddComponent<EventComponent>();
        }

        eventComponent.Subscribe(action);
    }

    public void UnSubscribe<T>(Action<T> action) where T : class
    {
        var eventComponent = GetComponent<EventComponent>();
        if(eventComponent != null)
        {
            eventComponent.UnSubscribe(action);
        }
    }

    #region 处理子组件
    public T AddComponent<T>() where T : Component
    {
        var component = Activator.CreateInstance<T>();
        component.Entity = this;
        component.IsDisposed = false;
        Components.Add(typeof(T), component);

        //执行生命和周期
        component.Awake();
        component.Start();
        component.Enable = component.DefaultEnable;

        return component;
    }

    public T AddComponent<T>(object initData) where T : Component
    {
        var component = Activator.CreateInstance<T>();
        component.Entity = this;
        component.IsDisposed = false;
        Components.Add(typeof(T), component);

        //执行生命和周期
        component.Awake(initData);
        component.Start(initData);
        component.Enable = component.DefaultEnable;

        return component;
    }

    public void RemoveComponent<T>() where T : Component
    {
        var component = Components[typeof(T)];
        if(component.Enable) component.Enable = false;
        Component.Destory(component);
        Components.Remove(typeof(T));
    }

    public T GetComponent<T>() where T : Component
    {
        if(Components.TryGetValue(typeof(T), out var component))
        {
            return component as T;
        }
        return null;
    }

    public bool TryGet<T>(out T component) where T : Component
    {
        if(Components.TryGetValue(typeof(T), out var c))
        {
            component = c as T;
            return true;
        }
        component = null;
        return false;
    }

    #endregion

    #region 处理子实体
    private void SetParent(Entity parent)
    {
        var preParent = Parent;
        preParent?.RemoveChild(this);
        this.Parent = parent;
        OnSetParent(preParent, parent);
    }

    /// <summary>
    /// 用来由子实体向父实体添加新的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetParent<T>() where T : Entity
    {
        return Parent as T;
    }

    public void SetChild(Entity child)
    {
        Children.Add(child);
        child.SetParent(this);
    }

    public T AddChild<T>() where T : Entity
    {
        return AddChild<T>(typeof(T));
    }

    public T AddChild<T>(object initData) where T : Entity
    {
        return AddChild(typeof(T), initData) as T;
    }

    public Entity AddChild(Type entityType)
    {
        var entity = NewEntity(entityType);
        SetUpEntity(entity, this);
        return entity;
    }

    public Entity AddChild(Type entityType, object initData)
    {
        var entity = NewEntity(entityType);
        SetUpEntity(entity, this, initData);
        return entity;
    }

    public void RemoveChild(Entity child)
    {
        Children.Remove(child);
    }
    #endregion
}
