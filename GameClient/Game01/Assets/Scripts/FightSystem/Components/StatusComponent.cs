/**********************************************************
文件：StatusComponent.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 15:15:32
功能：Nothing
/**********************************************************/

using System.Collections.Generic;
/// <summary>
/// 附带的状态组件
/// </summary>
public class StatusComponent : Component
{
    /// <summary>
    /// 获取状态附着的战斗实体
    /// </summary>
    public CombatEntity CombatEntity => GetEntity<CombatEntity>();

    /// <summary>
    /// 所带有的状态集合
    /// </summary>
    public Dictionary<string, List<StatusEntity>> Statuses = new Dictionary<string, List<StatusEntity>>();

    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="configObject"></param>
    /// <returns></returns>
    public StatusEntity AttachStatus(object configObject)
    {
        //将状态作为技能实体添加
        var status = CombatEntity.AttachAbility<StatusEntity>(configObject);
        if (Statuses.ContainsKey(status.StatusConfig.ID))
        {
            Statuses.Add(status.StatusConfig.ID, new List<StatusEntity>());
        }
        Statuses[status.StatusConfig.ID].Add(status);
        return status;
    }

    /// <summary>
    /// 移除状态、并且触发状态移除事件
    /// </summary>
    /// <param name="statusEntity"></param>
    public void OnStatusRemove(StatusEntity statusEntity)
    {
        Statuses[statusEntity.StatusConfig.ID].Remove(statusEntity);
        if(Statuses[statusEntity.StatusConfig.ID].Count == 0)
        {
            Statuses.Remove(statusEntity.StatusConfig.ID);
        }
        this.Publish(new RemoveStatusEvent() { CombatEntity = CombatEntity, Status = statusEntity, StatusId = statusEntity.Id });
    }

    /// <summary>
    /// 状态改变
    /// </summary>
    public void OnStatusesChanged(StatusEntity statusEntity)
    {
        foreach(var status in Statuses)
        {
            foreach(var item in status.Value)
            {
                if (!item.Enable)
                {
                    continue;
                }
                foreach(var effect in item.AbilityEffectComponent.AbilityEffects)
                {
                    //if(effect != null && effect.Enable && effect.TryGet(out Effect))
                    {

                    }
                }
            }
        }

        //CombatEntity.ActionControlType
    }
}

public class RemoveStatusEvent
{
    public CombatEntity CombatEntity { get; set; }
    public StatusEntity Status { get; set; }
    public long StatusId { get; set; }
}
