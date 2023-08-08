/**********************************************************
文件：AttributeComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 20:02:55
功能：Nothing
/**********************************************************/
using System.Collections.Generic;

/// <summary>
/// 属性更新事件
/// </summary>
public class AttributeUpdateEvent { public FloatNumeric Numeric; }

/// <summary>
/// 战斗属性数值组件，管理角色所有属性数值的存储、变更和刷新；
/// </summary>
public class AttributeComponent : Component
{
    private readonly Dictionary<string, FloatNumeric> attributeFloatNumerics = new Dictionary<string, FloatNumeric>();

    private readonly AttributeUpdateEvent attributeUpdateEvent = new AttributeUpdateEvent();

    #region 属性
    /// <summary>
    /// 最大生命值
    /// </summary>
    public FloatNumeric HealthPointMax { get => attributeFloatNumerics[AttributeType.HealthPointMax.ToString()]; }

    /// <summary>
    /// 当前生命值
    /// </summary>
    public FloatNumeric HealthPoint { get => attributeFloatNumerics[AttributeType.HealthPoint.ToString()]; }

    /// <summary>
    /// 物理攻击力
    /// </summary>
    public FloatNumeric PhysicsAttackPower { get => attributeFloatNumerics[AttributeType.PhysicsAttackPower.ToString()]; }

    /// <summary>
    /// 魔法攻击力
    /// </summary>
    public FloatNumeric MagicAttackPower { get => attributeFloatNumerics[AttributeType.MagicAttackPower.ToString()]; }

    /// <summary>
    /// 物理防御力
    /// </summary>
    public FloatNumeric PhysicsDefense { get => attributeFloatNumerics[AttributeType.PhysicsDefense.ToString()]; }

    /// <summary>
    /// 魔法防御力
    /// </summary>
    public FloatNumeric MagicDefense { get => attributeFloatNumerics[AttributeType.MagicDefense.ToString()]; }

    /// <summary>
    /// 吸血能力
    /// </summary>
    public FloatNumeric SuckBlood { get => attributeFloatNumerics[AttributeType.SuckBlood.ToString()]; }

    /// <summary>
    /// 暴击概率
    /// </summary>
    public FloatNumeric CritProbability { get => attributeFloatNumerics[AttributeType.CritProbability.ToString()]; }

    /// <summary>
    /// 移动速度
    /// </summary>
    public FloatNumeric MoveSpeed { get => attributeFloatNumerics[AttributeType.MoveSpeed.ToString()]; }

    /// <summary>
    /// 护盾值
    /// </summary>
    public FloatNumeric ShieldValue { get => attributeFloatNumerics[AttributeType.ShieldValue.ToString()]; }
    #endregion

    #region 管理自定义浮点数
    public FloatNumeric AddFloatNumeric(AttributeType attributeType, float baseValue)
    {
        var numeric = Entity.AddChild<FloatNumeric>();
        numeric.SetBase(baseValue);
        attributeFloatNumerics.Add(attributeType.ToString(), numeric);
        return numeric;
    }

    public FloatNumeric GetFloatNumeric(string attributeName)
    {
        return attributeFloatNumerics[attributeName];
    }

    public void FloatNumericUpdate(FloatNumeric numeric)
    {
        attributeUpdateEvent.Numeric = numeric;
        Entity.Publish(attributeUpdateEvent);
    }
    #endregion

    public override void Awake()
    {
        AddFloatNumeric(AttributeType.HealthPointMax, 0);
        AddFloatNumeric(AttributeType.HealthPoint, 0);
        AddFloatNumeric(AttributeType.PhysicsAttackPower, 0);
        AddFloatNumeric(AttributeType.MagicAttackPower, 0);
        AddFloatNumeric(AttributeType.PhysicsDefense, 0);
        AddFloatNumeric(AttributeType.MagicDefense, 0);
        AddFloatNumeric(AttributeType.SuckBlood, 0);
        AddFloatNumeric(AttributeType.CritProbability, 0);
        AddFloatNumeric(AttributeType.MoveSpeed, 0);
        AddFloatNumeric(AttributeType.ShieldValue, 0);
    }
}
