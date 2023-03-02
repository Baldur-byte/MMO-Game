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
    private PlayerInfo playerInfo;

    public void Init(PlayerInfo info)
    {
        playerInfo = info;
        transform.position = ConfigData.PlayerBornPos;
        CreateRole("Model/Cike", playerInfo.Name);
    }
}
