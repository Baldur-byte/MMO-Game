/**********************************************************
文件：EffectAttributeModifyComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/27 20:42:22
功能：Nothing
/**********************************************************/

/// <summary>
/// 属性修饰效果组件
/// </summary>
public class EffectAttributeModifyComponent : Component
{
    public override bool DefaultEnable => false;

    public AttributeModifyEffect AttributeModifyEffect { get; set; }

    public FloatModifier AttributeModifier { get; set; }
}
