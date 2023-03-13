/**********************************************************
文件：EffectProperties.cs
作者：auus
邮箱：#Email#
日期：2023/03/03 12:26:01
功能：Nothing
/**********************************************************/

using System.Collections.Generic;

public struct EffectProperties
{
    public List<Statuses> Statuses { get; private set; }
    public List<EffectTarget> Targets { get; private set; }

    public float Radius { get; private set; }

    public EffectProperties(List<Statuses> statuses, List<EffectTarget> targets, float radius)
    {
        Statuses = statuses;
        Targets = targets;
        Radius = radius;
    }
}
