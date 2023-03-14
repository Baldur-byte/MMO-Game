/**********************************************************
文件：NormalState.cs
作者：auus
邮箱：#Email#
日期：2023/03/14 10:56:16
功能：Nothing
/**********************************************************/

using UnityEngine;

public class NormalState : IState
{
    public void ChaseTarget(Transform transform)
    {
        
    }

    public int LookAccurate()
    {
        return 2;
    }

    public float LookAngle()
    {
        return 90;
    }

    public float LookDistance()
    {
        return 100;
    }
}
