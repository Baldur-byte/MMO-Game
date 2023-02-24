/**********************************************************
文件：UIStartScene.cs
作者：auus
邮箱：#Email#
日期：2023/02/23 20:32:02
功能：Nothing
/**********************************************************/

using UnityEngine;
using UnityEngine.UIElements;

public class UIStartScene : UIScene
{
    private Button startButton;

    private Button settingButton;

    private Button exitButton;

    protected override void OnAwake()
    {
        base.OnAwake();
    }

    protected override void OnOpen()
    {
        base.OnOpen();
        UIManager.Instance.ShowWindowInScene(UiName.UI_USER_LOGIN);
    }

    protected override void RegisterEvents()
    {
        startButton.clicked += StartButton_clicked;
        settingButton.clicked += SettingButton_clicked;
        exitButton.clicked += ExitButton_clicked;
    }

    protected override void UnRegisterEvents()
    {
        startButton.clicked -= StartButton_clicked;
        settingButton.clicked -= SettingButton_clicked;
        exitButton.clicked -= ExitButton_clicked;
    }

    #region 按钮事件
    private void StartButton_clicked()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.Game);
    }

    private void SettingButton_clicked()
    {
        UIManager.Instance.ShowWindowInScene(UiName.UI_SET);
    }

    private void ExitButton_clicked()
    {
        Application.Quit();
    }
    #endregion
}
