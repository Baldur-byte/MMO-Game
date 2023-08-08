/**********************************************************
文件：HealthPoint.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 17:48:51
功能：Nothing
/**********************************************************/

public class HealthPoint
{
    public FloatNumeric HealthPointNumeric;
    public FloatNumeric HealthPointMaxNumeric;
    public int Value { get => (int)HealthPointNumeric.Value; }
    public int MaxValue { get => (int)HealthPointMaxNumeric.Value; }

    public void Reset()
    {
        HealthPointNumeric.SetBase(HealthPointMaxNumeric.Value);
    }

    public void SetMaxValue(int value)
    {
        HealthPointMaxNumeric.SetBase(value);
    }

    public void Minus(int value)
    {
        HealthPointNumeric.MinusBase(value);
    }

    public void Add(int value)
    {
        HealthPointNumeric.AddBase(value);
    }

    public float Percent()
    {
        return (float)Value / MaxValue;
    }

    public int PercentHealth(float pct)
    {
        return (int)(MaxValue * pct);
    }

    public bool IsFull()
    {
        return Value == MaxValue;
    }
}
