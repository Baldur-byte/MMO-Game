/**********************************************************
文件：ConfigData.cs
作者：auus
邮箱：#Email#
日期：2023/03/01 18:07:01
功能：Nothing
/**********************************************************/

using UnityEngine;

public class ConfigData
{
    public const int MaxHealth = 100;
    public const int MaxMagic = 200;

    public static Vector3 PlayerBornPos = new Vector3(30, 1.2f, -30);

    //巡逻半径
    public const int patrolRadius = 5;
}
