/**********************************************************
文件：ActionControlType.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 16:11:04
功能：Nothing
/**********************************************************/

/// <summary>
/// 行为控制的类型
/// </summary>
public enum ActionControlType
{
    None = 0,

    /// <summary>
    /// 移动禁止
    /// </summary>
    MoveForbid = 1 << 1,

    /// <summary>
    /// 技能禁止
    /// </summary>
    SkillForbid = 1 << 2,

    /// <summary>
    /// 攻击禁止
    /// </summary>
    AttackForbid = 1 << 3,

    /// <summary>
    /// 移动控制
    /// </summary>
    MoveControl = 1 << 4,

    /// <summary>
    /// 攻击控制
    /// </summary>
    AttackControl = 1 << 5,
}
