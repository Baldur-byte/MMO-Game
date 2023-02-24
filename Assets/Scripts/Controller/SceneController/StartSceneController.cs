/**********************************************************
文件：StartSceneController.cs
作者：auus
邮箱：#Email#
日期：2023/02/22 20:58:03
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StartSceneController : SceneController
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickStartGame()
    {
        SceneLoadManager.Instance.LoadSceneAsync(SceneType.Game);
    }
}
