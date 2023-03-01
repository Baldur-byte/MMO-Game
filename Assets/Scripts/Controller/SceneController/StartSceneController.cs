/**********************************************************
文件：StartSceneController.cs
作者：auus
邮箱：#Email#
日期：2023/02/22 20:58:03
功能：Nothing
/**********************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

public class StartSceneController : SceneController
{
    private List<Action> InitTask = new List<Action>();
    private void Start()
    {
        InitTask.Clear();

        AddInitTask(() => { DataManager.Instance.Init(); });

        StartCoroutine(ExcuteInit());
    }

    private void AddInitTask(Action pInitAction)
    {
        InitTask.Add(pInitAction);
    }

    private IEnumerator ExcuteInit()
    {
        foreach (var action in InitTask)
        {
            action.Invoke();
            yield return null;
        }
    }
}
