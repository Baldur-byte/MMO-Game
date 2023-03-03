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
    private List<Statuses> Statuses;
    private List<EffectTarget> Targets;

    public EffectProperties(List<Statuses> statuses, List<EffectTarget> targets)
    {
        Statuses = statuses;
        Targets = targets;
    }
}
