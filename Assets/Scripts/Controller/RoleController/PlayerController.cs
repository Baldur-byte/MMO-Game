/**********************************************************
文件：PlayerController.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:09:02
功能：Nothing
/**********************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : RoleController
{
    private RolePlayer _player;

    public void CreatePlayer()
    {
        PlayerInfo _playerInfo = new PlayerInfo();

        _player = ResourceManager.Instance.CreatePrefab<RolePlayer>("Prefabs/Role/Role");
        _player.Init(_playerInfo.Name);

        
    }

    public void Update()
    {

    }

    #region 行为
    public void MoveTo(Vector3 target)
    {
        _player.Run(target);
    }

    public Transform RolePos()
    {
        return _player.gameObject.transform;
    }

    public void Hurt(int damage)
    {
        _player.Hurt();
    }

    //添加攻击间隔的判定，避免一次动画多次伤害
    public void Attack(int attackType)
    {
        if (_player.Attack(attackType))//攻击成功
        {
            TriangleDetect detect = new TriangleDetect(5, 10);
            
            //播放特效

            //进行技能范围检验
        }
    }

    #endregion
}
