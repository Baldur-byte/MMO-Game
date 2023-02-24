/**********************************************************
文件：UIManager.cs
作者：auus
邮箱：#Email#
日期：2023/02/24 10:59:35
功能：Nothing
/**********************************************************/

/**********************************************************
文件：UIManager.cs
作者：auus
邮箱：#Email#
日期：2023/02/22 21:01:23
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private SceneType curSceneType = SceneType.None;

    private UIScene curScene;

    //private UIFactory factory;

    private Dictionary<string, UIWindow> windowDic = new Dictionary<string, UIWindow>();

    private void Awake()
    {
        
    }

    public void LoadScene(SceneType target)
    {
        if(curSceneType != SceneType.None && curSceneType != target)
        {
            Destroy(curScene.gameObject);
        }

        curScene = ResourceManager.Instance.Instantiate(ResourcesPath.SCENE_PATH + target.ToString(), curScene.gameObject.transform).GetComponent<UIScene>();

        curSceneType = target;
    }

    public void ShowWindowInScene(string target)
    {
        UIWindow window = null;
        if (!windowDic.ContainsKey(target))
        {
            window = ResourceManager.Instance.Instantiate(ResourcesPath.WINDOW_PATH + target).GetComponent<UIWindow>();
            windowDic[target] = window;
        }
        curScene.ShowWindow(window);
    }

    public void HideWindowInScene(string target)
    {
        if (!windowDic.ContainsKey(target))
        {
            return;
        }
        curScene.HideWindow(windowDic[target]);
    }
}
