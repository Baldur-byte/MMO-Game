/**********************************************************
文件：RoleMonster.cs
作者：auus
邮箱：#Email#
日期：2023/03/02 14:34:23
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMonster : IRole
{
    private MonsterInfo monsterInfo;

    private float waitTime = 0f;

    private bool isInitilized = false;

    public void Init(MonsterInfo info)
    {
        monsterInfo = info;
        transform.position = info.BornPos;
        CreateRole("Model/Qinbing", monsterInfo.Name);

        isInitilized = true;
    }

    protected override void Update()
    {
        base.Update();
        if (!isInitilized) return;
        if(waitTime <= 0f)
        {
            GetRandomTarget();
            waitTime = Random.Range(0, 1) * 15 + 5;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void GetRandomTarget()
    {
        float offsetX = Random.Range(-1, 1) * ConfigData.patrolRadius;
        float offsetZ = Random.Range(-1, 1) * ConfigData.patrolRadius;
        Vector3 target = new Vector3(monsterInfo.BornPos.x + offsetX, monsterInfo.BornPos.y, monsterInfo.BornPos.z + offsetZ);
        Run(target);
        Debug.Log(target);
    }
}
