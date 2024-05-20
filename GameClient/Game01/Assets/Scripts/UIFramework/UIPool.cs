/**********************************************************
文件：UIPool.cs
作者：auus
邮箱：#Email#
日期：2023/02/24 11:42:11
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPool
{
    public Dictionary<string, UIScene> scenePool = new Dictionary<string, UIScene>();

    public Dictionary<string, UIWindow> windowPool = new Dictionary<string, UIWindow>();
}
