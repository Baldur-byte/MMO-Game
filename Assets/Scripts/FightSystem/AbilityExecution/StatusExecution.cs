/**********************************************************
文件：StatusExecution.cs
作者：auus
邮箱：#Email#
日期：2023/03/20 17:13:06
功能：Nothing
/**********************************************************/

/// <summary>
/// 状态执行体
/// </summary>
public class StatusExecution : IAbilityExecution
{
    public IAbilityEntity AbilityEntity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CombatEntity OwnerEntity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void BeginExecute()
    {
        throw new System.NotImplementedException();
    }

    public void EndExecute()
    {
        throw new System.NotImplementedException();
    }
}
