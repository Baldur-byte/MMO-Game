/**********************************************************
文件：UIUserRegister.cs
作者：auus
邮箱：#Email#
日期：2023/02/24 15:19:42
功能：Nothing
/**********************************************************/

using UnityEngine;
using UnityEngine.UI;

public class UIUserRegister : UIWindow
{
    [SerializeField]
    private Button backToLoginButton;

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
        backToLoginButton.onClick.AddListener(BacktoLoginButton_clicked);
        registerButton.onClick.AddListener(RegisterButton_clicked);
        closeButton.onClick.AddListener(CloseButton_clicked);
    }

    public override void UnRegisterEvents()
    {
        backToLoginButton.onClick.RemoveListener(BacktoLoginButton_clicked);
        registerButton.onClick.RemoveListener(RegisterButton_clicked);
        closeButton.onClick.RemoveListener(CloseButton_clicked);
    }

    #region 按钮事件
    private void BacktoLoginButton_clicked()
    {
        UIManager.Instance.OpenWindow(UiName.UI_USER_LOGIN);
    }

    private void RegisterButton_clicked()
    {
        UIManager.Instance.OpenWindow(UiName.UI_USER_REGISTER);
    }

    private void CloseButton_clicked()
    {
        Application.Quit();
    }
    #endregion

    private bool checkPlayerInfo()
    {
        return true;
        return false;
    }
}
