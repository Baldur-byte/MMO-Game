/**********************************************************
文件：Motion.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 14:36:14
功能：Nothing
/**********************************************************/

public class MotionAbility : IActionAbility
{
    public CombatEntity OwnerEntity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool Enable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
public class MotionAction : IActionExecution
{
    public IActionAbility ActionAbility { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity Creator { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}