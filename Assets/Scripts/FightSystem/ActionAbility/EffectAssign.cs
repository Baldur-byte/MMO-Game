/**********************************************************
文件：EffectAssign.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 17:53:18
功能：Nothing
/**********************************************************/

/// <summary>
/// 附加效果的能力
/// </summary>
public class EffectAssignAbility : Entity, IActionAbility
{
    public bool Enable { get ; set; }
    public CombatEntity OwnerEntity { get => GetParent<CombatEntity>(); set { } }

    public bool TryAttachAction(out EffectAssignAction action)
    {
        if (Enable)
        {
            action = OwnerEntity.AddChild<EffectAssignAction>();
            action.ActionAbility = this;
            action.Creator = OwnerEntity;
        }
        else
        {
            action = null;
        }
        return Enable;
    }
}

/// <summary>
/// 附加效果能力的实施
/// </summary>
public class EffectAssignAction : Entity, IActionExecution
{
    /// <summary>
    /// 行动发起者
    /// </summary>
    public CombatEntity Creator { get ; set; }

    /// <summary>
    /// 行动的目标对象
    /// </summary>
    public CombatEntity Target { get; set; }

    /// <summary>
    /// 行动能力
    /// </summary>
    public IActionAbility ActionAbility { get; set; }

    /// <summary>
    /// 创建这个行动的源能力
    /// </summary>
    public IAbilityEntity SourceAbility { get; set; }

    /// <summary>
    /// 目标行动
    /// </summary>
    public IActionExecution TargetAction { get; set; }

    /// <summary>
    /// 前置处理
    /// </summary>
    private void PreProcess()
    {

    }

    /// <summary>
    /// 后置处理
    /// </summary>
    private void PostProcess()
    {

    }

    /// <summary>
    /// 结束后处理
    /// </summary>
    private void FinishAction()
    {

    }

    public void ApplyEffectAssign()
    {
        PreProcess();
    }
}