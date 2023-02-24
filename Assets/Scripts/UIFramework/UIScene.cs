/**********************************************************
文件：UIScene.cs
作者：auus
邮箱：#Email#
日期：2023/02/23 11:06:02
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : UIBase
{
    [HideInInspector]
    public Transform HidePageRoot;

    [HideInInspector]
    public Transform ShowPageRoot;

    protected override void OnAwake()
    {
        base.OnAwake();
        HidePageRoot = transform.Find("HidePageRoot");
        ShowPageRoot = transform.Find("ShowPageRoot");
    }
}
