/**********************************************************
文件：Interact.cs
作者：auus
邮箱：#Email#
日期：2023/02/28 16:45:38
功能：Nothing
/**********************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

public interface Interact
{
    public abstract void OnDrag(PointerEventData eventData);

    public abstract void OnPointerDown(PointerEventData eventData);

    public abstract void OnPointerUp(PointerEventData eventData);
}
