/**********************************************************
文件：GameSceneController.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:12:06
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSceneController : SceneController, Interact
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private PlayerController playerController;

    private UIGameScene gameSceneUI;

    private Vector2 lastPointerPostion;

    void Start()
    {
        UIManager.Instance.InitTouchArea(this);
        gameSceneUI = UIManager.Instance.GetCurSceneUI() as UIGameScene;
        cameraController.ResetCamera();
        playerController.CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        cameraController.CameraFallow(playerController.gameObject.transform);
    }

    #region 交互
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cameraController.CameraZoomWithAnim(1);
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            cameraController.CameraRotation(eventData.position.x - lastPointerPostion.x);
            cameraController.CameraUpAndDown(lastPointerPostion.y - eventData.position.y);
            lastPointerPostion = eventData.position;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            cameraController.CameraZoomWithAnim(1);
        }
        else if(eventData.button == PointerEventData.InputButton.Left)
        {
            lastPointerPostion = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cameraController.CameraZoomWithAnim(-1);
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer(LayerName.Ground)) && EventSystem.current.IsPointerOverGameObject() && eventData.pointerEnter.name == "TouchArea(Panel)")
            {
                playerController.Run(hit.point);
            }
        }
    }
    #endregion

    private void Test()
    {

    }
}
