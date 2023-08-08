/**********************************************************
文件：Damage.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 14:36:23
功能：Nothing
/**********************************************************/

public class DamageAbility : IActionAbility
{
    public CombatEntity OwnerEntity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool Enable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}

public class DamageAction : IActionExecution
{
    #region 数值相关
    /// <summary>
    /// 伤害数值
    /// </summary>
    public int DamageValue { get;set; }
    #endregion
    public IActionAbility ActionAbility { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity Creator { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
