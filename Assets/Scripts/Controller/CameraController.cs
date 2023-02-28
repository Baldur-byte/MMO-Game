/**********************************************************
文件：CameraController.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:08:41
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CameraController : MonoBehaviour, Interact
{
    [SerializeField]
    private Transform m_CameraTarget;
    [SerializeField]
    private Transform FallowAndRotation;
    [SerializeField]
    private Transform UpAndDown;
    [SerializeField]
    private Transform Zoom;

    private Vector2 lastPointerPostion;

    private float minZoom = -1;
    private float maxZoom = 1;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        cameraRotation(eventData.position.x - lastPointerPostion.x);
        cameraUpAndDown(lastPointerPostion.y - eventData.position.y);
        lastPointerPostion = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        lastPointerPostion = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    // Start is called before the first frame update
    void Start()
    {
        resetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        FallowAndRotation.position = m_CameraTarget.position;

        if (Input.GetMouseButtonDown(1))
        {
            cameraZoomWithAnim(1);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            cameraZoomWithAnim(-1);
        }
    }

    private void resetCamera()
    {
        FallowAndRotation.Rotate(Vector3.zero, Space.World);
        UpAndDown.Rotate(Vector3.zero, Space.Self);
        Zoom.localPosition = new Vector3(0, 0, minZoom);
    }

    private void cameraRotation(float value)
    {
        //Debug.Log(FallowAndRotation.rotation.eulerAngles.y);
        FallowAndRotation.Rotate(new Vector3(0, value / 50, 0), Space.World);
    }

    private void cameraUpAndDown(float value)
    {
        float x = UpAndDown.localRotation.eulerAngles.x + value / 50;
        if(x >180)
        {
            x -= 360;
        }
        UpAndDown.localRotation = Quaternion.Euler(Mathf.Clamp(x, -14, 65), 0, 0);
        //UpAndDown.Rotate(new Vector3(value / 50, 0, 0), Space.Self);
    }

    private void cameraZoomWithAnim(float value)
    {
        Zoom.DOComplete();
        float animTime = 0;
        float targetZoom = minZoom;
        if (value > 0)
        {
            targetZoom = maxZoom;
        }
        else
        {

        }
        animTime = Mathf.Abs(Zoom.localPosition.z - targetZoom) / 10;
        Zoom.DOLocalMoveZ(targetZoom, animTime);
    }

    private void cameraZoom(float value)
    {
        Zoom.localPosition = new Vector3(0, 0, Mathf.Clamp(value, minZoom, maxZoom));
    }
}
