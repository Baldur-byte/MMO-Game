/**********************************************************
文件：AttributeType.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 10:39:49
功能：Nothing
/**********************************************************/

/// <summary>
/// 角色属性类型
/// </summary>
public enum AttributeType
{
    /// <summary>
    /// 空
    /// </summary>
    None,

    /// <summary>
    /// 最大生命值
    /// </summary>
    HealthPointMax,

    /// <summary>
    /// 当前生命值
    /// </summary>
    HealthPoint,

    /// <summary>
    /// 物理攻击力
    /// </summary>
    PhysicsAttackPower,

    /// <summary>
    /// 魔法攻击力
    /// </summary>
    MagicAttackPower,

    /// <summary>
    /// 物理防御力
    /// </summary>
    PhysicsDefense,

    /// <summary>
    /// 魔法防御力
    /// </summary>
    MagicDefense,

    /// <summary>
    /// 吸血能力
    /// </summary>
    SuckBlood,

    /// <summary>
    /// 暴击概率
    /// </summary>
    CritProbability,

    /// <summary>
    /// 移动速度
    /// </summary>
    MoveSpeed,

    /// <summary>
    /// 护盾值
    /// </summary>
    ShieldValue,
}
