/**********************************************************
文件：EffectTriggerType.cs
作者：auus
邮箱：#Email#
日期：2023/03/24 12:27:04
功能：Nothing
/**********************************************************/

/// <summary>
/// 效果触发类型
/// </summary>
public enum EffectTriggerType
{
    None = 0,

    /// <summary>
    /// 立即触发
    /// </summary>
    Instant = 1,

    /// <summary>
    /// 条件触发
    /// </summary>
    Condition = 2,

    /// <summary>
    /// 行动点触发
    /// </summary>
    ActionPoint = 3,

    /// <summary>
    /// 间隔触发
    /// </summary>
    Interval = 4,

    /// <summary>
    /// 行动点并且满足条件触发
    /// </summary>
    ConditionInActionPoint = 5,
}
