/**********************************************************
文件：UIUserLogin.cs
作者：auus
邮箱：#Email#
日期：2023/02/24 15:19:42
功能：Nothing
/**********************************************************/

/**********************************************************
文件：UIUserLogin.cs
作者：auus
邮箱：#Email#
日期：2023/02/23 20:32:18
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUserLogin : UIWindow
{
    [SerializeField]
    private Button loginButton;

    [SerializeField]
    private Button registerButton;

    [SerializeField]
    private Button closeButton;

    protected override void OnAwake()
    {
        base.OnAwake();
    }

    public override void RegisterEvents()
    {
        loginButton.onClick.AddListener(LoginButton_clicked);
        registerButton.onClick.AddListener(RegisterButton_clicked);
        closeButton.onClick.AddListener(CloseButton_clicked);
    }

    public override void UnRegisterEvents()
    {
        loginButton.onClick.RemoveListener(LoginButton_clicked);
        registerButton.onClick.RemoveListener(RegisterButton_clicked);
        closeButton.onClick.RemoveListener(CloseButton_clicked);
    }

    #region 按钮事件
    private void LoginButton_clicked()
    {
        SceneLoadManager.Instance.LoadSceneAsync(SceneType.Game);
    }

    private void RegisterButton_clicked()
    {
        UIManager.Instance.OpenWindow(UiName.UI_USER_REGISTER);
    }

    private void CloseButton_clicked()
    {
        UIManager.Instance.CloseWindow(this);
    }
    #endregion
}
