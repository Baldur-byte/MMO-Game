/**********************************************************
文件：Component.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 11:24:59
功能：Nothing
/**********************************************************/

using System;

public class Component
{
    private bool enable = false;

    public virtual bool DefaultEnable { get; set; } = true;

    public bool IsDisposed { get; set; }

    public bool Enable 
    {
        get { return enable; }
        set
        {
            if (enable == value) return;
            enable = value;
            if(enable) OnEnable();
            else OnDisable();
        }
    }

    /// <summary>
    /// 组件所附着的实体
    /// </summary>
    public Entity Entity { get; set; }

    public T GetEntity<T>() where T : Entity
    {
        return Entity as T;
    }

    #region 组件的生命周期
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

    public virtual void OnEnable()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void OnDisable()
    {

    }

    public virtual void OnDestroy()
    {

    }

    public static void Destory(Component component)
    {
        try
        {
            component.OnDestroy();
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        component.dispose();
    }
    #endregion

    #region 公共接口
    public T Publish<T>(T TEvent) where T : class
    {
        Entity.Publish(TEvent);
        return TEvent;
    }
    #endregion

    private void dispose()
    {

    }
}
