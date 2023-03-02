/**********************************************************
文件：MonsterInfo.cs
作者：auus
邮箱：#Email#
日期：2023/03/02 17:34:24
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : RoleInfo
{

    private Vector3 bornPos;

    public Vector3 BornPos
    {
        get
        {
            return bornPos;
        }
        set
        {
            bornPos = value;
        }
    }
}
