/**********************************************************
文件：UIBase.cs
作者：auus
邮箱：#Email#
日期：2023/02/23 11:05:28
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    #region Unity消息
    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
    #endregion

    #region 虚方法
    protected virtual void OnAwake()
    {

    }

    protected virtual void OnStart()
    {

    }

    protected virtual void OnUpdate()
    {

    }

    protected virtual void OnFixedUpdate()
    {

    }

    public virtual void OnOpen()
    {

    }

    public virtual void OnClose()
    {

    }

    protected virtual void OnDestroy()
    {

    }

    public virtual void RegisterEvents()
    {

    }

    public virtual void UnRegisterEvents()
    {

    }
    #endregion
}
