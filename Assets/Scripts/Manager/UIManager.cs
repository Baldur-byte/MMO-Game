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
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class UIManager : MonoSingleton<UIManager>
{
    private SceneType curSceneType = SceneType.None;

    private UIScene curScene;

    [SerializeField]
    private Transform loading;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TouchArea touchArea;

    //private UIFactory factory;

    private Dictionary<string, UIWindow> windowDic = new Dictionary<string, UIWindow>();

    private List<UIWindow> showingWindows = new List<UIWindow>();

    private void Awake()
    {
        loading.gameObject.SetActive(false);

        if(curSceneType == SceneType.None)
        {
            curScene = ResourceManager.Instance.Instantiate(ResourcesPath.SCENE_PATH + "StartScene", transform).GetComponent<UIScene>();

            curSceneType = SceneType.Start;
        }

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
    }

    public void Loading(float progress)
    {
        if (!loading.gameObject.activeSelf)
        {
            loading.gameObject.SetActive(true);
        }

        if (slider.value < progress)
        {
            slider.value = progress;
        }
        else
        {
            slider.value = 0.028f;
        }
    }

    public IEnumerator LoadScene(SceneType target, AsyncOperation async)
    {
        loading.gameObject.SetActive(true);
        //async.allowSceneActivation = false;
        slider.value = 0.028f;
        slider.maxValue = 0.9f;
        while (!async.isDone)
        {
            if(async.progress >= slider.value)
            {
                slider.value = async.progress / 0.9f;
            }
            if(async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
        loading.gameObject.SetActive(false);

        if (curSceneType != SceneType.None && curSceneType != target)
        {
            curScene.OnClose();
            curScene.UnRegisterEvents();
            Destroy(curScene.gameObject);
        }

        curScene = ResourceManager.Instance.Instantiate(ResourcesPath.SCENE_PATH + target.ToString() + "Scene", transform).GetComponent<UIScene>();

        curSceneType = target;
        curScene.RegisterEvents();
        curScene.OnOpen();
    }

    #region UI操作方法
    public void OpenWindow(string target, WindowAnimType windowAnimType = WindowAnimType.None, bool isStorePool = true)
    {
        UIWindow window = null;
        if (!windowDic.ContainsKey(target))
        {
            window = ResourceManager.Instance.Instantiate(ResourcesPath.WINDOW_PATH + target).GetComponent<UIWindow>();
            windowDic[target] = window;
        }
        else
        {
            window = windowDic[target];
        }

        if (showingWindows.Contains(window))
        {
            reOpenWindow(window);
        }
        else
        {
            window.gameObject.transform.parent = curScene.ShowPageRoot;

            window.gameObject.transform.localPosition = Vector3.zero;
            window.gameObject.transform.localScale = Vector3.one;
            window.gameObject.transform.rotation = Quaternion.identity;

            window.RegisterEvents();
            window.OnOpen();
            window.gameObject.SetActive(true);

            while (showingWindows.Count > 0)
            {
                CloseWindow(showingWindows[0]);
            }

            showingWindows.Add(window);
        }
    }

    public void CloseWindow(UIWindow window, bool isStorePool = true)
    {
        window.OnClose();
        window.UnRegisterEvents();
        window.gameObject.SetActive(false);
        showingWindows.Remove(window);
        if (!windowDic.ContainsValue(window) || !isStorePool)
        {
            Destroy(window.gameObject);
        }
        else
        {
            window.gameObject.transform.parent = curScene.HidePageRoot;
        }
    }

    private void reOpenWindow(UIWindow window)
    {
        window.OnClose();
        window.UnRegisterEvents();
        window.gameObject.transform.parent = curScene.ShowPageRoot;
        window.gameObject.transform.localPosition = Vector3.zero;
        window.gameObject.transform.localScale = Vector3.one;
        window.gameObject.transform.rotation = Quaternion.identity;
        window.RegisterEvents();
        window.OnOpen();
        window.gameObject.SetActive(true);
    }
    #endregion

    public void InitTouchArea(Interact interact)
    {
        touchArea.SetActiveInteract(interact);
    }

    public UIScene GetCurSceneUI()
    {
        return curScene;
    }
}
