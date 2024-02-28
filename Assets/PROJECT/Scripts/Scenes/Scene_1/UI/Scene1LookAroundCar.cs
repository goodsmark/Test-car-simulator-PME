using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Scene1LookAroundCar : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private bool canFade;
    
    private float rotationSpeed = 5f;
    private Vector2 dragOrigin;
    private List<CanvasGroup> _visibleWindows = new();
    
    [Inject] private Scene1Controller _controller;
    
    public void AddViewForHide(CanvasGroup c)
    {
        _visibleWindows.Add(c);
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        DoAnim(false);
        dragOrigin = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DoAnim(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RotateCamera(eventData);
    }

    private void DoAnim(bool needEnable)
    {
        if (!canFade) return;
        
        foreach (var v in _visibleWindows)
        {
            v.blocksRaycasts = needEnable;
            v.DOFade(needEnable ? 1 : 0, 0.35f);
        }
    }
    
    private void RotateCamera(PointerEventData eventData)
    {
        var dragDelta = (eventData.position - dragOrigin) * Time.deltaTime * rotationSpeed;
        var cum = CameraC.Camera.transform;
        var spawnPos = _controller.CameraSettings.carPositionSpawn.position;
            
        cum.RotateAround(spawnPos, Vector3.up, dragDelta.x);
        cum.LookAt(spawnPos);

        dragOrigin = eventData.position;
    }
}