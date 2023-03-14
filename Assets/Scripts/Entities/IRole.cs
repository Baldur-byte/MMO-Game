/**********************************************************
文件：IRole.cs
作者：auus
邮箱：#Email#
日期：2023/03/02 14:32:29
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class IRole : MonoBehaviour
{
    private CharacterController characterController;

    private float m_MoveSpeed = 15f;

    private float m_RotateSpeed = 0.5f;

    private bool isFighting = false;

    private bool isRuning = false;

    private bool isDead = false;

    private bool isAttacking = false;

    private Animator m_Animator;

    private AnimatorStateInfo stateInfo;

    private Vector3 positionTarget;

    private Quaternion rotationTarget;

    private bool isInitialized = false;

    private RoleHP showHP;

    private float destoryTime = 5f;

    public RoleInfo roleInfo { get; private set; }

    public IState curState { get; private set; }

    public List<StateType> States { get; set; }

    protected void CreateRole(string path, RoleInfo info)
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

        showHP = transform.Find("HP").GetComponent<RoleHP>();

        curState = new NormalState();
        roleInfo = info;

        isInitialized = true;
    }

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

        showHP = transform.Find("HP").GetComponent<RoleHP>();

        curState = new NormalState();

        isInitialized = true;
    }

    protected virtual void Update()
    {
        if (!isInitialized) return;

        if (isDead)
        {
            destoryTime -= Time.deltaTime;
            if(destoryTime < 0)
            {
                gameObject.SetActive(false);
                Destroy(this);
            }
            return;
        }

        stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1 && stateInfo.IsTag("Attack"))
        {
            isAttacking = false;
            m_Animator.SetInteger(AnimatorParameters.PhyAttack.ToString(), 0);
            Debug.Log(stateInfo.normalizedTime);
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

        //血条面向摄像头
        showHP.transform.rotation = Quaternion.LookRotation(showHP.transform.position - Camera.main.transform.position);
        showHP.Refresh((float)roleInfo.CurHealth / (float)roleInfo.MaxHealth);
    }

    #region 动作
    public void Run(Vector3 target)
    {
        if(isDead) return;
        positionTarget = target;
        rotationTarget = Quaternion.LookRotation(new Vector3(target.x - transform.position.x, 0, target.z - transform.position.z));
        m_RotateSpeed = 0.5f;
    }

    public void Hurt()
    {
        if (isDead) return;
        Debug.Log("Hurt");
        Fight();
        m_Animator.SetTrigger(AnimatorParameters.Hurt.ToString());
    }

    public virtual bool Attack(int attackType)
    {
        if (isDead) return false;
        if (isAttacking) return false;
        isAttacking = true;
        Debug.Log("Attack" + attackType);
        Fight();
        m_Animator.SetInteger(AnimatorParameters.PhyAttack.ToString(), attackType);
        return true;
    }

    public void Die()
    {
        if (isDead) return;
        Debug.Log("Die");
        Fight();
        m_Animator.SetTrigger(AnimatorParameters.Die.ToString());
        isDead = true;
    }

    public void Fight()
    {
        if (isDead) return;
        if (isFighting) return;
        isFighting = true;
        m_Animator.SetBool(AnimatorParameters.Fight.ToString(), isFighting);
    }

    public void ExitFight()
    {
        if (isDead) return;
        if (!isFighting) return;
        isFighting = false;
        m_Animator.SetBool(AnimatorParameters.Fight.ToString(), isFighting);
    }

    public void LevelUp(int value)
    {
        if (isDead) return;
    }

    public void GetExp(int value)
    {
        if (isDead) return;
    }

    public void UseSkill(int value)
    {
        if (isDead) return;
    }
    #endregion

    public bool IsAlive()
    {
        return roleInfo.CurHealth > 0;
    }
    
    public bool isMoving()
    {
        return isRuning;
    }


}
