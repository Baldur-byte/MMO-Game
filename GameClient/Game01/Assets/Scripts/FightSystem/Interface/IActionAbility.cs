/**********************************************************
文件：IActionAbility.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 10:46:17
功能：Nothing
/**********************************************************/

/// <summary>
/// 战斗行动能力
/// </summary>
public interface IActionAbility
{
    public CombatEntity OwnerEntity { set; get; }
    public bool Enable { get; set; }
}
