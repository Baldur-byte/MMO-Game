/**********************************************************
文件：CombatEntity.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 10:39:27
功能：Nothing
/**********************************************************/

using UnityEngine;
/// <summary>
/// 战斗实体
/// </summary>
public class CombatEntity : Entity
{
    /// <summary>
    /// 实体位置
    /// </summary>
    public Vector3 Postion { get; set; }

    /// <summary>
    /// 实体的方向
    /// </summary>
    public Quaternion Rotation { get; set; }

    #region 行动能力

    #endregion

    /// <summary>
    /// 挂载能力，技能、被动、buff等都通过接口挂载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="configObject"></param>
    /// <returns></returns>
    public T AttachAbility<T>(object configObject) where T : Entity, IAbilityEntity
    {
        var ability = AddChild<T>(configObject);
        ability.AddComponent<AbilityLevelComponent>();
        
        return ability;
    }

    /// <summary>
    /// 赋给行动能力
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T AttachAction<T>() where T : Entity, IActionAbility
    {
        var action = AddChild<T>();
        action.AddComponent<ActionComponent>();
        action.Enable = true;
        return action;
    }
}
