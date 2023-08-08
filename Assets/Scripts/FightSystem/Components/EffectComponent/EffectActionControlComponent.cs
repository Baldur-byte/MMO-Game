/**********************************************************
文件：EffectActionControlComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/23 14:17:46
功能：Nothing
/**********************************************************/

/// <summary>
/// 行动禁制效果组件
/// </summary>
public class EffectActionControlComponent : Component
{
    public override bool DefaultEnable => false;

    public ActionControlEffect ActionControlEffect { get; set; }

    public ActionControlType ActionControlType { get; set; }

    public override void Awake()
    {
        ActionControlEffect = GetEntity<AbilityEffect>().EffectConfig as ActionControlEffect;
    }

    public override void OnEnable()
    {
        Entity.Parent.Parent.GetComponent<StatusComponent>().OnStatusesChanged(Entity.GetParent<StatusEntity>());
    }

    public override void OnDisable()
    {
        Entity.Parent.Parent.GetComponent<StatusComponent>().OnStatusesChanged(Entity.GetParent<StatusEntity>());
    }
}
