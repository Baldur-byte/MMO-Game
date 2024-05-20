/**********************************************************
文件：AbilityEffectComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 16:03:57
功能：Nothing
/**********************************************************/

using System.Collections.Generic;
/// <summary>
/// 能力效果组件
/// </summary>
public class AbilityEffectComponent : Component
{
    public List<AbilityEffect> AbilityEffects { get; private set; } = new List<AbilityEffect>();
}
