/**********************************************************
文件：IStates.cs
作者：auus
邮箱：#Email#
日期：2023/03/14 10:51:45
功能：Nothing
/**********************************************************/

using UnityEngine;

public interface IState
{
    float LookAngle();

    int LookAccurate();

    float LookDistance();

    void ChaseTarget(Transform transform);
}
