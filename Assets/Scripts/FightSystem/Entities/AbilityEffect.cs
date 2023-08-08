/**********************************************************
文件：AbilityEffect.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 18:25:27
功能：Nothing
/**********************************************************/

/// <summary>
/// 能力的效果，如伤害、治疗、施加状态等和技能数值状态相关的效果
/// </summary>
public class AbilityEffect : Entity
{
    public bool Enable { get; set; }

    public Effect EffectConfig { get; set; }

    public IAbilityEntity OwnerAbility => Parent as IAbilityEntity;

    public CombatEntity OwnerEntity => OwnerAbility.OwnerEntity;

    public override void Awake(object initData)
    {
        this.EffectConfig = initData as Effect;

        //行为禁制
        if(this.EffectConfig is ActionControlEffect)
        {
            AddComponent<EffectActionControlComponent>();
        }

        //属性修饰
        if(this.EffectConfig is AttributeModifyEffect)
        {
            AddComponent<EffectAttributeModifyComponent>();
        }

        //伤害效果
        if(this.EffectConfig is DamageEffect)
        {
            AddComponent<EffectDamageComponent>();
        }

        //治疗效果
        if(this.EffectConfig is CureEffect)
        {
            AddComponent<EffectCureComponent>();
        }

        //施加状态效果
        if(this.EffectConfig is AddStatusEffect)
        {
            AddComponent<EffectAddStatusComponent>();
        }

        //自定义效果
        if(this.EffectConfig is CustomEffect)
        {
            AddComponent<EffectCureComponent>();
        }

        //效果修饰
        AddComponent<EffectDecoratosComponent>();

        bool triggable = !(this.EffectConfig is ActionControlEffect) && !(this.EffectConfig is AttributeModifyEffect);

        if (triggable)
        {
            //立即触发
            if(EffectConfig.TriggerType == EffectTriggerType.Instant)
            {
                TryAssignEffectToParent();
            }


        }
    }

    /// <summary>
    /// 将效果赋给父对象
    /// </summary>
    private void TryAssignEffectToParent()
    {

    }

    /// <summary>
    /// 将效果赋给战斗实体
    /// </summary>
    private void TryAssignEffectTo(CombatEntity targetEntity)
    {
        if(OwnerEntity.EffectAssignAbility.TryAttachAction(out EffectAssignAction action))
        {
            action.Target = targetEntity;
            action.SourceAbility = OwnerAbility;
            action.AbilityEffect = this;
            action.ApplyEffectAssign();
        }
    }

    /// <summary>
    /// 赋给效果
    /// </summary>
    public void StartAssignEffect()
    {
        //执行效果
        this
    }
}
