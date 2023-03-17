/**********************************************************
文件：Entity.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 10:59:04
功能：Nothing
/**********************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实体
/// </summary>
public abstract partial class Entity
{
    public static Entity NewEntity(Type entityType, long id = 0) 
    {
        var entity = Activator.CreateInstance(entityType) as Entity;

        return entity;
    }

    private static void SetUpEntity(Entity entity, Entity parent)
    {
        parent.SetChild(entity);
        entity.Awake();
        entity.Start();
    }

    private static void SetUpEntity(Entity entity, Entity parent, object initData)
    {
        parent.SetChild(entity);
        entity.Awake(initData);
        entity.Start(initData);
    }

    public static Entity Create(Type entityType, Entity parent)
    {
        var entity = NewEntity(entityType);
        SetUpEntity(entity, parent);
        return entity;
    }

    public static Entity Create(Type entityType, Entity parent, object initData)
    {
        var entity = NewEntity(entityType);
        SetUpEntity(entity, parent, initData);
        return entity;
    }

    public static void Destory(Entity entity)
    {
        try
        {
            entity.OnDestory();
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        entity.Dispose();
    }
}
