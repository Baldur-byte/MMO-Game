using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance != null) return instance;
            instance = FindObjectOfType<T>();
            if (instance != null) return instance;
            GameObject obj = GameObject.Find("GameManager");
            if (obj == null)
            {
                obj = new GameObject("GameManager");
                DontDestroyOnLoad(obj);
            }
            instance = obj.AddComponent<T>();
            return instance;
        }
    }
}
