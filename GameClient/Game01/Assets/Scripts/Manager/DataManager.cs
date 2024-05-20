/**********************************************************
文件：DataManager.cs
作者：auus
邮箱：#Email#
日期：2023/02/28 20:14:49
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public static PlayerInfo PlayerData;

    public void Init()
    {
        PlayerData = new PlayerInfo();
    }
}
