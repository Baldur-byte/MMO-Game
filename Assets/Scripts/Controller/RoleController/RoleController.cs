/**********************************************************
文件：RoleController.cs
作者：auus
邮箱：#Email#
日期：2023/03/02 14:28:20
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    protected List<IEffected> _attackTargets;

    #region 添加攻击目标

    public void AddAttackTarget(IEffected target)
    {
        if (!_attackTargets.Contains(target))
        {
            _attackTargets.Add(target);
        }
        else
        {
            Debug.LogError("target exists!");
        }
    }

    public void AddAttackTarget(List<IEffected> targets)
    {
        foreach (IEffected target in targets)
        {
            AddAttackTarget(target);
        }
    }

    public void AddAttackTarget(IEffected[] targets)
    {
        foreach (IEffected target in targets)
        {
            AddAttackTarget(target);
        }
    }

    public void RemoveAttackTarget(IEffected target)
    {
        if (_attackTargets.Contains(target))
        {
            _attackTargets.Remove(target);
        }
        else
        {
            Debug.LogError("target donot exists!");
        }
    }

    public void RemoveAttackTarget(List<IEffected> targets)
    {
        foreach (IEffected target in targets)
        {
            RemoveAttackTarget(target);
        }
    }

    public void RemoveAttackTarget(IEffected[] targets)
    {
        foreach (IEffected target in targets)
        {
            RemoveAttackTarget(target);
        }
    }

    #endregion
}
