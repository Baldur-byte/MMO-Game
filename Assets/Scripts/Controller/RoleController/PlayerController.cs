/**********************************************************
文件：PlayerController.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:09:02
功能：Nothing
/**********************************************************/

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 positionTarget;

    private Quaternion rotationTarget;

    private float m_MoveSpeed = 7f;

    private float m_RotateSpeed = 0.5f;

    private bool isFighting = false;

    private bool isRuning = false;

    [SerializeField]
    private Animator m_Animator;

    private AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.SimpleMove(Vector3.zero);

        m_Animator.SetBool(AnimatorParameters.Fight.ToString(), isFighting);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer(LayerName.Ground)) && EventSystem.current.IsPointerOverGameObject())
            {
                positionTarget = hit.point;
                rotationTarget = Quaternion.LookRotation(new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z));
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Hurt();
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Die();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Attack(1);
        }

        stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.normalizedTime > 1 && stateInfo.IsTag("Attack"))
        {
            m_Animator.SetInteger(AnimatorParameters.PhyAttack.ToString(), 0);
        }

        MoveTo(positionTarget);
    }

    public void MoveTo(Vector3 position)
    {
        if (position == Vector3.zero) return;
        if (CommonMethod.GetHorizonDistance(transform.position, position) < 0.1f)
        {
            if (isRuning)
            {
                m_Animator.SetTrigger(AnimatorParameters.Idle.ToString());
                isRuning = false;
            }
            return;
        }
        //else if(CommonMethod.GetHorizonDistance(transform.position, position) < 0.5f)
        //{
        //    if (stateInfo.IsName("Run"))
        //    {
        //        m_MoveSpeed = 2.3f;
        //        m_Animator.SetTrigger(AnimatorParameters.Idle.ToString());
        //        isRuning = false;
        //    }
        //    else if(!stateInfo.IsTag("Idle"))
        //    {
        //        m_Animator.SetTrigger(AnimatorParameters.Run.ToString());
        //        isRuning = true;
        //        m_RotateSpeed = 0.5f;
        //        m_MoveSpeed = 5f;
        //    }
        //}
        else
        {
            if (!isRuning)
            {
                m_Animator.SetTrigger(AnimatorParameters.Run.ToString());
                isRuning = true;
                m_RotateSpeed = 0.5f;
                m_MoveSpeed = 5f;
            }
        }
        characterController.SimpleMove(Vector3.Normalize(position - transform.position) * m_MoveSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotationTarget, m_RotateSpeed * Time.deltaTime);
        m_RotateSpeed += 0.5f;
        if (Quaternion.Angle(transform.rotation, rotationTarget) < 0.1f)
        {
            m_RotateSpeed = 1;
            transform.rotation = rotationTarget;
        }
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
}
