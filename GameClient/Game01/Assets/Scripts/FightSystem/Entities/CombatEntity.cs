/**********************************************************
文件：CombatEntity.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 10:39:27
功能：Nothing
/**********************************************************/

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 战斗实体
/// </summary>
public class CombatEntity : Entity
{
    public HealthPoint CurrentHealth { get; set; }

    #region 战斗实体物理属性
    /// <summary>
    /// 实体位置
    /// </summary>
    public Vector3 Postion { get; set; }

    /// <summary>
    /// 实体的方向
    /// </summary>
    public Quaternion Rotation { get; set; }

    public GameObject GameObject { get; set; }

    public Transform Transform { get; set; }
    #endregion

    #region 行动能力
    /// <summary>
    /// 附加效果的行动能力
    /// </summary>
    public EffectAssignAbility EffectAssignAbility { get; private set; }

    /// <summary>
    /// 技能施法的行动能力
    /// </summary>
    public SpellAbility SpellAbility { get; private set; }

    /// <summary>
    /// 移动的行动能力
    /// </summary>
    public MotionAbility MotionAbility { get; private set; }

    /// <summary>
    /// 造成伤害的行动能力
    /// </summary>
    public DamageAbility DamageAbility { get; private set; }

    /// <summary>
    /// 治疗的行动能力
    /// </summary>
    public CureAbility CureAbility { get; private set; }

    /// <summary>
    /// 添加状态的行动能力
    /// </summary>
    public AddStatusAbility AddStatusAbility { get; private set; }

    /// <summary>
    /// 执行普通攻击的行动能力
    /// </summary>
    public AttackAbility AttackAbility { get; private set; }

    /// <summary>
    /// 回合行动能力
    /// </summary>
    public RoundAbility RoundAbility { get; private set; }

    /// <summary>
    /// 起跳行动能力 
    /// </summary>
    public JumpToAbility JumpToAbility { get; private set; }
    #endregion

    #region 能力实体
    /// <summary>
    /// 攻击实体
    /// </summary>
    public AttackEntity AttackEntity { get; private set; }

    /// <summary>
    /// 技能实体
    /// </summary>
    public SkillEntity SkillEntity { get; private set; }

    /// <summary>
    /// 状态实体
    /// </summary>
    public StatusEntity StatusEntity { get; private set; }
    #endregion

    /// <summary>
    /// 技能执行体
    /// </summary>
    public SkillExecution SkillExecution { get; private set; }

    /// <summary>
    /// 技能字典
    /// </summary>
    public Dictionary<string, SkillEntity> Skills { get; private set; } = new Dictionary<string, SkillEntity>();

    /// <summary>
    /// 行为禁止的类型
    /// </summary>
    public ActionControlType ActionControlType { get; private set; }

    /// <summary>
    /// 禁止豁免的类型
    /// </summary>
    public ActionControlType ActionControlImmuneType { get; private set; }

    /// <summary>
    /// 挂载能力，技能、被动、buff等都通过接口挂载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="configObject"></param>
    /// <returns></returns>
    public T AttachAbility<T>(object configObject) where T : Entity, IAbilityEntity
    {
        var ability = AddChild<T>(configObject);
        ability.AddComponent<AbilityLevelComponent>();
        
        return ability;
    }

    /// <summary>
    /// 赋给行动能力
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T AttachAction<T>() where T : Entity, IActionAbility
    {
        var action = AddChild<T>();
        action.AddComponent<ActionComponent>();
        action.Enable = true;
        return action;
    }

    #region 行动点事件
    public void AddListenActionPoint(ActionPointType actionPointType, Action<IActionExecution> action)
    {
        GetComponent<ActionPointComponent>().AddListener(actionPointType, action);
    }

    public void RemoveListenActionPoint(ActionPointType actionPointType, Action<IActionExecution> action)
    {
        GetComponent<ActionPointComponent>().RemoveListener(actionPointType, action);
    }

    public void TriggerActionPoint(ActionPointType actionPointType, IActionExecution action)
    {
        GetComponent<ActionPointComponent>().TriggerActionPoint(actionPointType, action);
    }
    #endregion

    #region 条件事件
    public void AddListenCondition(ConditionType conditionType, Action action, object paramObj = null)
    {
        GetComponent<ConditionComponent>().AddListener(conditionType, action, paramObj);
    }

    public void RemoveListenCondition(ConditionType conditionType, Action action)
    {
        GetComponent<ConditionComponent>().RemoveListener(conditionType);
    }
    #endregion

    #region 生命值变化
    public void ReceiveDamage(IActionExecution combatAction)
    {
        var action = combatAction as DamageAction;
        CurrentHealth.Minus(action.DamageValue);
    }

    public void ReceiveCure(IActionExecution combatAction)
    {
        var cureAction = combatAction as CureAction;
        CurrentHealth.Add(cureAction.CureValue);
    }

    public bool IsDead()
    {
        return CurrentHealth.Value <= 0;
    }
    #endregion

    /// <summary>
    /// 添加组件
    /// </summary>
    public override void Awake()
    {
        AddComponent<AttributeComponent>();
        AddComponent<ActionPointComponent>();
        AddComponent<ConditionComponent>();

    }
}
