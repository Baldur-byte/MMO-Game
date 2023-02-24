/**********************************************************
文件：UIScene.cs
作者：auus
邮箱：#Email#
日期：2023/02/23 11:06:02
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : UIBase
{
    private Transform m_HidePageRoot;

    private Transform m_ShowPageRoot;

    protected override void OnAwake()
    {
        base.OnAwake();
        m_HidePageRoot = transform.Find("HidePageRoot");
        m_ShowPageRoot = transform.Find("ShowPageRoot");
    }

    public void ShowWindow(UIWindow window)
    {
        window.gameObject.SetActive(true);
        window.transform.parent = m_ShowPageRoot;
        window.OpenUI();
    }

    public void HideWindow(UIWindow window)
    {
        window.gameObject.SetActive(false);
        window.transform.parent = m_HidePageRoot;
        window.CloseUI();
    }
    
}
