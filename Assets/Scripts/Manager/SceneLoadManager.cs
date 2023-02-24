/**********************************************************
文件：SceneLoadManager.cs
作者：auus
邮箱：#Email#
日期：2023/02/22 20:40:24
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoSingleton<SceneLoadManager>
{
    public void LoadScene(SceneType scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(scene.ToString(), mode);
        UIManager.Instance.LoadScene(scene);
    }

    public void LoadSceneAsync(SceneType scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene.ToString(), mode);
        UIManager.Instance.LoadScene(scene);
    }
}
