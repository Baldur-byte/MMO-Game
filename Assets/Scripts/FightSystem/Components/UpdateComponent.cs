/**********************************************************
文件：UpdateComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 12:29:24
功能：Nothing
/**********************************************************/

/// <summary>
/// 更新组件
/// </summary>
public class UpdateComponent : Component
{
    //只有挂载此组件的实体才会执行更新方法
    public override void Update()
    {
        Entity.Update();
    }
}
