/**********************************************************
文件：IndividualOfEffect.cs
作者：auus
邮箱：#Email#
日期：2023/03/03 12:20:01
功能：Nothing
/**********************************************************/

using UnityEngine;

public class IndividualOfEffect : IEffectBase
{
    private SectorDetect detect;

    public IndividualOfEffect(EffectProperties properties) : base(properties)
    {
        detect = new SectorDetect(_properties.Radius);
    }

    public override void Effect(IEffected effected)
    {

    }


    public override void isInRange()
    {
        throw new System.NotImplementedException();
    }
}
