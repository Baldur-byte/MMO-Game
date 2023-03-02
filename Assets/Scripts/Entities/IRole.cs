/**********************************************************
文件：IRole.cs
作者：auus
邮箱：#Email#
日期：2023/03/02 14:32:29
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IRole : MonoBehaviour
{
    private CharacterController characterController;

    private float m_MoveSpeed = 15f;

    private float m_RotateSpeed = 0.5f;

    private bool isFighting = false;

    private bool isRuning = false;

    private Animator m_Animator;

    private AnimatorStateInfo stateInfo;

    private Vector3 positionTarget;

    private Quaternion rotationTarget;

    private bool isInitialized = false;

    protected void CreateRole(string path, string name)
    {
        characterController = GetComponent<CharacterController>();
        GameObject obj = ResourceManager.Instance.Instantiate(path, transform.Find("Container"));
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;
        obj.name = name;
        m_Animator = obj.GetComponent<Animator>();
        m_Animator.SetBool(AnimatorParameters.Fight.ToString(), isFighting);

        positionTarget = obj.transform.position;
        rotationTarget = obj.transform.rotation;

        isInitialized = true;
    }

    protected virtual void Update()
    {
        if (!isInitialized) return;
        stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime > 1 && stateInfo.IsTag("Attack"))
        {
            m_Animator.SetInteger(AnimatorParameters.PhyAttack.ToString(), 0);
        }

        if (CommonMethod.GetHorizonDistance(transform.position, positionTarget) >= 0.1f && positionTarget != Vector3.zero)
        {
            if (!isRuning)
            {
                isRuning = true;
                m_Animator.SetTrigger(AnimatorParameters.Run.ToString());
            }
            characterController.SimpleMove(Vector3.Normalize(positionTarget - transform.position) * m_MoveSpeed * Time.deltaTime * 100);
        }
        else if (CommonMethod.GetHorizonDistance(transform.position, positionTarget) <= 1f)
        {
            if (isRuning)
            {
                isRuning = false;
                m_Animator.SetTrigger(AnimatorParameters.Idle.ToString());
            }
        }

        if (Quaternion.Angle(transform.rotation, rotationTarget) > 0.1f)
        {
            m_RotateSpeed += 0.5f;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationTarget, m_RotateSpeed * Time.deltaTime);
        }
    }

    #region 动作
    public void Run(Vector3 target)
    {
        positionTarget = target;
        rotationTarget = Quaternion.LookRotation(new Vector3(target.x - transform.position.x, 0, target.z - transform.position.z));
        m_RotateSpeed = 0.5f;
    }

    public void Hurt()
    {
        Debug.Log("Hurt");
        Fight();
        m_Animator.SetTrigger(AnimatorParameters.Hurt.ToString());
    }

    public void Attack(int attackType)
    {
        Debug.Log("Attack" + attackType);
        Fight();
        m_Animator.SetInteger(AnimatorParameters.PhyAttack.ToString(), attackType);
        //m_Animator.
        //m_Animator.SetInteger(AnimatorParameters.PhyAttack.ToString(), 0);
    }

    public void Die()
    {
        Debug.Log("Die");
        Fight();
        m_Animator.SetTrigger(AnimatorParameters.Die.ToString());
    }

    public void Fight()
    {
        if (isFighting) return;
        isFighting = true;
        m_Animator.SetBool(AnimatorParameters.Fight.ToString(), isFighting);
    }

    public void ExitFight()
    {
        if (!isFighting) return;
        isFighting = false;
        m_Animator.SetBool(AnimatorParameters.Fight.ToString(), isFighting);
    }

    public void LevelUp(int value)
    {

    }

    public void GetExp(int value)
    {

    }

    public void UseSkill(int value)
    {

    }
    #endregion

    public bool isMoving()
    {
        return isRuning;
    }
}
