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
    protected override void OnStart()
    {
        base.OnStart();
        UIManager.Instance.OpenWindow(UiName.UI_USER_LOGIN);
    }
}
