/**********************************************************
文件：StatusEntity.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 16:51:39
功能：Nothing
/**********************************************************/

/// <summary>
/// 状态实体
/// </summary>
public class StatusEntity : Entity, IAbilityEntity
{
    public bool Enable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void ActivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public void DeactivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public void EndAbility()
    {
        throw new System.NotImplementedException();
    }

    public void TryActivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public StatusConfig StatusConfig { get; set; }

    public AbilityEffectComponent AbilityEffectComponent { get; set; }
}
