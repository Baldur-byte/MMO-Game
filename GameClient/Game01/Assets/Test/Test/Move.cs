/**********************************************************
文件：Move.cs
作者：auus
邮箱：#Email#
日期：2023/03/09 14:46:54
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool isMove = false;

    public GameObject test;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isMove = true;
        }
        if (isMove)
        {
            transform.Translate(100 * Time.deltaTime, 0, 0);
        }
    }
}
