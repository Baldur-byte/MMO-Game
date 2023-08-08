/**********************************************************
文件：IAbilityExecution.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 17:04:24
功能：Nothing
/**********************************************************/

/// <summary>
/// 能力执行体，是实际创建的、执行能力表现，触发能力效果
/// 存一些与表现执行相关的临时状态数据
/// </summary>
public interface IAbilityExecution
{
    /// <summary>
    /// 能力实体
    /// </summary>
    public IAbilityEntity AbilityEntity { get; set; }

    /// <summary>
    /// 战斗实体，拥有该技能的实体
    /// </summary>
    public CombatEntity OwnerEntity { get; set; }

    /// <summary>
    /// 开始执行
    /// </summary>
    public void BeginExecute();

    /// <summary>
    /// 结束执行
    /// </summary>
    public void EndExecute();
}
