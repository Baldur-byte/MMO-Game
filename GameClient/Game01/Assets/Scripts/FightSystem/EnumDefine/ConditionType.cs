/**********************************************************
文件：ConditionType.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 12:19:00
功能：Nothing
/**********************************************************/

/// <summary>
/// 条件类型
/// </summary>
public enum ConditionType
{
    /// <summary>
    /// 自定义条件
    /// </summary>
    CustomCondition,

    /// <summary>
    /// 当生命值低于
    /// </summary>
    WhenHPLower,

    /// <summary>
    /// 当生命值低于百分比
    /// </summary>
    WhenHPctLower,

    /// <summary>
    /// 当n秒内没有受伤
    /// </summary>
    WhenInTimeNoDamage
}
