/**********************************************************
文件：IAbilityEntity.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 14:30:35
功能：Nothing
/**********************************************************/

/// <summary>
/// 能力实体，存储着某个具体能力的数据和状态
/// </summary>
public interface IAbilityEntity
{
    public bool Enable { get; set; }

    /// <summary>
    /// 尝试激活能力
    /// </summary>
    public void TryActivateAbility();

    /// <summary>
    /// 激活能力
    /// </summary>
    public void ActivateAbility();

    /// <summary>
    /// 禁用能力
    /// </summary>
    public void DeactivateAbility();

    /// <summary>
    /// 结束能力
    /// </summary>
    public void EndAbility();
}
