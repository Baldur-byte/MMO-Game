/**********************************************************
文件：MonsterController.cs
作者：auus
邮箱：#Email#
日期：2023/03/01 20:25:47
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : RoleController
{
    private List<RoleMonster> roleMonsters = new List<RoleMonster>();

    [SerializeField]
    private List<Transform> MonsterBornPos = new List<Transform>();

    public void CreateMonster(MonsterInfo info)
    {
        RoleMonster monster = ResourceManager.Instance.CreatePrefab<RoleMonster>("Prefabs/Role/Role");
        monster.Init(info.Name, info.BornPos);
        roleMonsters.Add(monster);
    }

    public void CreateMonsterRandom(int count)
    {
        for(int i = 0; i < count; i++)
        {
            if(MonsterBornPos.Count <= 0)
            {
                Debug.LogError("没有怪物重生点");
                return;
            }
            int posIndex = Random.Range(0, MonsterBornPos.Count);
            MonsterInfo info = new MonsterInfo();
            info.BornPos = MonsterBornPos[posIndex].position;
            CreateMonster(info);
        }
    }

    public void Patrol()
    {
        for(int i = 0; i < roleMonsters.Count; i++)
        {
            RoleMonster monster = roleMonsters[i];
            //monster.
        }
    }

    private IEnumerator RandomMove()
    {
        yield return null;
    }
}
