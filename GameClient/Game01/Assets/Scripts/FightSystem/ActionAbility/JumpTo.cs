/**********************************************************
文件：JumpTo.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 14:37:18
功能：Nothing
/**********************************************************/

public class JumpToAbility : IActionAbility
{
    public CombatEntity OwnerEntity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool Enable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}

public class JumpToAction : IActionExecution
{
    public IActionAbility ActionAbility { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity Creator { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
