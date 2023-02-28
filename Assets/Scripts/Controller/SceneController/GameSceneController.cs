/**********************************************************
文件：GameSceneController.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:12:06
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : SceneController
{
    [SerializeField]
    private Transform cameraInteract;

    [SerializeField]
    private PlayerController playerController;

    void Start()
    {
        UIManager.Instance.InitTouchArea(cameraInteract.GetComponent<Interact>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
