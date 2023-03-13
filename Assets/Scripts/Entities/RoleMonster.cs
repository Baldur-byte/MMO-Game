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

public class RoleMonster : IRole, IEffected
{
    private float waitTime = 0f;

    private bool isInitilized = false;

    private Vector3 bornPos;

    public void Init(string name, Vector3 bornPos)
    {
        this.bornPos = bornPos;
        transform.position = bornPos;
        CreateRole("Model/Qinbing", name);
        gameObject.tag = "Monster";

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
        Vector3 target = new Vector3(bornPos.x + offsetX, bornPos.y, bornPos.z + offsetZ);
        Run(target);
    }

    public Vector3 position()
    {
        return transform.position;
    }

    #region 受技能影响

    public void Fired()
    {
        throw new System.NotImplementedException();
    }

    public void Frozen()
    {
        throw new System.NotImplementedException();
    }

    public void None()
    {
        throw new System.NotImplementedException();
    }

    public void Resume()
    {
        throw new System.NotImplementedException();
    }

    public void SlowDown()
    {
        throw new System.NotImplementedException();
    }

    public void SpeedUp()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
