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

    public override void Awake(object initData)
    {
        base.Awake();
    }
}
