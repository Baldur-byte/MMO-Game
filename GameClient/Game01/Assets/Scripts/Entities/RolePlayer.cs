/**********************************************************
文件：RolePlayer.cs
作者：auus
邮箱：#Email#
日期：2023/03/02 14:33:52
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RolePlayer : IRole
{
    public void Init(string name)
    {
        transform.position = ConfigData.PlayerBornPos;
        CreateRole("Model/Cike", name);
        gameObject.tag = "Player";
    }

    public Vector3 position()
    {
        return transform.position;
    }

    #region 受技能影响

    public void Fired()
    {
        throw new System.NotImplementedException();
    }

    public void Frozen()
    {
        throw new System.NotImplementedException();
    }

    public void None()
    {
        throw new System.NotImplementedException();
    }

    public void Resume()
    {
        throw new System.NotImplementedException();
    }

    public void SlowDown()
    {
        throw new System.NotImplementedException();
    }

    public void SpeedUp()
    {
        throw new System.NotImplementedException();
    }


    #endregion
}
