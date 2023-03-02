/**********************************************************
文件：PlayerController.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:09:02
功能：Nothing
/**********************************************************/

using UnityEngine;

public class PlayerController : RoleController
{
    private RolePlayer _player;

    public void CreatePlayer()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        _player = ResourceManager.Instance.CreatePrefab<RolePlayer>("Prefabs/Role/Role");
        _player.Init(playerInfo);
    }

    public void MoveTo(Vector3 target)
    {
        _player.Run(target);
    }

    public Transform RolePos()
    {
        return _player.gameObject.transform;
    }
}
