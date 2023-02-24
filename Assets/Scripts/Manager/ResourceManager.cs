/**********************************************************
文件：ResourceManager.cs
作者：auus
邮箱：#Email#
日期：2023/02/22 20:06:50
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoSingleton<ResourceManager>
{
    private Dictionary<string, GameObject> prefabPool = new Dictionary<string, GameObject>();

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load(path) as T;
    }

    public GameObject Instantiate(string InPrefabPath, Transform InParent = null, bool InStorePool = true)
    {
        GameObject prefabAsset;
        if (InStorePool)
        {
            if(!prefabPool.TryGetValue(InPrefabPath, out prefabAsset))
            {
                prefabAsset = Load<GameObject>(InPrefabPath);
                prefabPool.Add(InPrefabPath, prefabAsset);
            }
        }
        else
        {
            prefabAsset = Load<GameObject>(InPrefabPath);
        }

        if (prefabAsset == null)
        {
            Debug.LogError(InPrefabPath + " is Not Found!!");
            return null;
        }

        GameObject resultObject = Object.Instantiate(prefabAsset, InParent);
        return resultObject;
    }

    public T CreatePrefab<T>(string path, Transform parent) where T : MonoBehaviour
    {
        GameObject obj = Instantiate(path, parent);
        T t = obj.GetComponent<T>();
        if (t != null)
        {
            return t;
        }
        return obj.AddComponent<T>();
    }
}
