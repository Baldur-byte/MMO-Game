/**********************************************************
文件：UIFactory.cs
作者：auus
邮箱：#Email#
日期：2023/02/24 11:13:38
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory : UIPool
{
    public UIScene CreateSceneUI(SceneType type, Transform sceneRoot)
    {
        if (scenePool.ContainsKey(type.ToString()))
        {
            return scenePool[type.ToString()];
        }
        else
        {
            UIScene scene = ResourceManager.Instance.Instantiate(ResourcesPath.SCENE_PATH + type.ToString(), sceneRoot).GetComponent<UIScene>();
            scene.gameObject.SetActive(false);
            scenePool.Add(type.ToString(), scene);
            return scene;
        }
    }

    public UIWindow CreateWindowUI(string name, Transform parent = null)
    {
        if (windowPool.ContainsKey(name))
        {
            return windowPool[name];
        }
        else
        {
            UIWindow window = ResourceManager.Instance.Instantiate(ResourcesPath.WINDOW_PATH + name, parent).GetComponent<UIWindow>();
            windowPool.Add(name, window);
            return window;
        }
    }
}
