/**********************************************************
文件：FloatNumeric.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 17:55:35
功能：Nothing
/**********************************************************/
using System.Collections.Generic;

/// <summary>
/// 浮点型修饰器
/// </summary>
public class FloatModifier
{
    public float Value;
}

/// <summary>
/// 浮点型修饰器集合
/// </summary>
public class FloatModifierCollection 
{
    public float TotalValue { get; private set; }

    private List<FloatModifier> modifiers { get; } = new List<FloatModifier>();

    public float AddModifier(FloatModifier modifier)
    {
        modifiers.Add(modifier);
        Update();
        return TotalValue;
    }

    public float RemoveModifier(FloatModifier modifier)
    {
        modifiers.Remove(modifier);
        Update();
        return TotalValue;
    }

    public void Update()
    {
        TotalValue = 0f;
        foreach (FloatModifier modifier in modifiers)
        {
            TotalValue += modifier.Value;
        }
    }
}


/// <summary>
/// 浮点数值
/// </summary>
public class FloatNumeric : Entity
{
    public float Value { get; private set; }

    public float baseValue { get; private set; }

    public float add { get; private set; }

    public float pctAdd { get; private set; }

    public float finalAdd { get; private set; }

    public float finalPctAdd { get; private set; }

    private FloatModifierCollection addCollection { get; } = new FloatModifierCollection();

    private FloatModifierCollection pctAddCollection { get; } = new FloatModifierCollection();

    private FloatModifierCollection finalAddCollection { get; } = new FloatModifierCollection();

    private FloatModifierCollection finalPctAddCollection { get; } = new FloatModifierCollection();

    public override void Awake()
    {
        baseValue = add = pctAdd = finalAdd = finalPctAdd = 0f;
    }

    private void UpdateValue()
    {
        var value1 = baseValue;
        var value2 = (value1 + add) * (100 + pctAdd) / 100f;
        var value3 = (value2 + finalAdd) * (100 + finalPctAdd) / 100f;
        Value = value3;

        Parent.GetComponent<AttributeComponent>().FloatNumericUpdate(this);
    }

    public float SetBase(float value)
    {
        baseValue = value;
        UpdateValue();
        return baseValue;
    }

    public float AddBase(float value)
    {
        baseValue += value;
        UpdateValue();
        return baseValue;
    }

    public float MinusBase(float value)
    {
        baseValue -= value;
        if (baseValue < 0) baseValue = 0f;
        UpdateValue();
        return baseValue;
    }

    public void AddAddModifier(FloatModifier modifier)
    {
        add = addCollection.AddModifier(modifier);
        UpdateValue();
    }

    public void AddPctAddModifier(FloatModifier modifier)
    {
        pctAdd = addCollection.AddModifier(modifier);
        UpdateValue();
    }

    public void AddFinalAddModifier(FloatModifier modifier)
    {
        finalAdd = finalAddCollection.AddModifier(modifier);
        UpdateValue();
    }

    public void AddFinalPctAddModifier(FloatModifier modifier)
    {
        finalPctAdd = finalPctAddCollection.AddModifier(modifier);
        UpdateValue();
    }

    public void RemoveAddModifier(FloatModifier modifier)
    {
        add = addCollection.RemoveModifier(modifier);
        UpdateValue();
    }

    public void RemovePctAddModifier(FloatModifier modifier)
    {
        pctAdd = pctAddCollection.RemoveModifier(modifier);
        UpdateValue();
    }

    public void RemoveFinalAddModifier(FloatModifier modifier)
    {
        finalAdd = finalAddCollection.RemoveModifier(modifier);
        UpdateValue();
    }

    public void RemoveFinalPctAddModifier(FloatModifier modifier)
    {
        finalPctAdd = finalPctAddCollection.RemoveModifier(modifier);
        UpdateValue();
    }
}
