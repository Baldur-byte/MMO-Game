/**********************************************************
文件：GameApplication.cs
作者：auus
邮箱：#Email#
日期：2023/02/22 19:51:52
功能：Nothing
/**********************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApplication : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Start()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.Start);
    }
}
