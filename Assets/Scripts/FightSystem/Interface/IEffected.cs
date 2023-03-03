/**********************************************************
文件：IEffected.cs
作者：auus
邮箱：#Email#
日期：2023/03/03 14:29:40
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffected
{
    public abstract void None();
    public abstract void Fired();
    public abstract void Frozen();
    public abstract void SlowDown();
    public abstract void SpeedUp();
    public abstract void Resume();
    public abstract void Hurt();
    public abstract void Die();
}
