/**********************************************************
文件：ActionPointType.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 11:28:49
功能：Nothing
/**********************************************************/

/// <summary>
/// 行动点类型
/// </summary>
public enum ActionPointType
{
    None,

    /// <summary>
    /// 造成攻击前
    /// </summary>
    BeforeCauseDamage = 1 << 1,

    /// <summary>
    /// 承受伤害前
    /// </summary>
    BeforeReceiveDamage = 1 << 2,

    /// <summary>
    /// 造成伤害后
    /// </summary>
    AfterCauseDamage = 1 << 3,

    /// <summary>
    /// 承受伤害后
    /// </summary>
    AfterReceiveDamage = 1 << 4,

    /// <summary>
    /// 给予治疗后
    /// </summary>
    AfterGiveCure = 1 << 5,

    /// <summary>
    /// 接受治疗后
    /// </summary>
    AfterReceiveCure = 1 << 6,

    /// <summary>
    /// 附加技能效果
    /// </summary>
    AssignEffect = 1 << 7,

    /// <summary>
    /// 接受技能效果
    /// </summary>
    ReceiveEffect = 1 << 8,

    /// <summary>
    /// 附加状态后
    /// </summary>
    AfterGiveStatus = 1 << 9,

    /// <summary>
    /// 承受状态后
    /// </summary>
    AfterReceiveStatus = 1 << 10,

    /// <summary>
    /// 给予普通攻击前
    /// </summary>
    BeforeGiveAttack = 1 << 11,

    /// <summary>
    /// 给予普通攻击后
    /// </summary>
    AfterGiveAttack = 1 << 12,

    /// <summary>
    /// 承受普通攻击前
    /// </summary>
    BeforeReceiveAttack = 1 << 13,

    /// <summary>
    /// 承受普通攻击后
    /// </summary>
    AfterReceiveAttack = 1 << 14,

    /// <summary>
    /// 起跳前
    /// </summary>
    BeforeJumpTo = 1 << 15,

    /// <summary>
    /// 起跳后
    /// </summary>
    AfterJumpTo = 1 << 16,

    /// <summary>
    /// 施法前
    /// </summary>
    BeforeSpell = 1 << 17,

    /// <summary>
    /// 施法后
    /// </summary>
    AfterSpell = 1 << 18,

    /// <summary>
    /// 附加普通攻击效果前
    /// </summary>
    BeforeGiveAttackEffect = 1 << 19,

    /// <summary>
    /// 附加普通攻击后
    /// </summary>
    AfterGiveAttackEffect = 1 << 20,

    /// <summary>
    /// 承受普通攻击效果前
    /// </summary>
    BeforeReceiveAttackEffect = 1 << 21,

    /// <summary>
    /// 承受普通攻击效果后
    /// </summary>
    AfterReceiveAttackEffect = 1 << 22,

    Max,
}
