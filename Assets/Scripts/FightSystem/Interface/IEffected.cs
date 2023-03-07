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
    void None();
    void Fired();
    void Frozen();
    void SlowDown();
    void SpeedUp();
    void Resume();
    void Hurt();
    void Die();
}
