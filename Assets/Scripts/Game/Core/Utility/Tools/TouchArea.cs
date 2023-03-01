/**********************************************************
文件：TouchArea.cs
作者：auus
邮箱：#Email#
日期：2023/02/28 17:08:26
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchArea : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Interact activeInteract;

    private int curPointerId;

    private MonoBehaviour pointer;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (eventData.pointerId != curPointerId) return;
        //if(eventData.)
        activeInteract.OnDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        curPointerId = eventData.pointerId;
        activeInteract.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        if (eventData.pointerId != curPointerId) return;
        activeInteract.OnPointerUp(eventData);
    }

    public void SetActiveInteract(Interact interact)
    {
        activeInteract = interact;
    }

    private bool IsTouchedUI()
    {
        bool touchedUI = false;
        if (Application.isMobilePlatform)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                touchedUI = true;
            }
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            touchedUI = true;
        }
        return touchedUI;
    }

    private bool IsOnTouchArea()
    {
        Debug.Log(EventSystem.current.gameObject.name);
        return false;
    }
}
