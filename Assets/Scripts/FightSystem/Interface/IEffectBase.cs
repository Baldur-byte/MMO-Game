/**********************************************************
文件：IEffectBase.cs
作者：auus
邮箱：#Email#
日期：2023/03/03 14:36:31
功能：Nothing
/**********************************************************/

public abstract class IEffectBase
{
    protected EffectProperties _properties;

    public IEffectBase(EffectProperties properties)
    {
        _properties = properties;
    }

    public abstract void Effect(IEffected effected);

    public abstract void isInRange();
}
