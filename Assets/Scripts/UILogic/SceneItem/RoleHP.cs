/**********************************************************
文件：RoleHP.cs
作者：auus
邮箱：#Email#
日期：2023/03/08 11:26:12
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RoleHP : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer curBlood;

    /// <summary>
    /// 刷新血量显示
    /// </summary>
    /// <param name="value"></param>
    public void Refresh(float value)
    {
        curBlood.size = new Vector2(value, 1);
        if(value < 0.02)
        {
            gameObject.SetActive(false);
        }
    }
}
