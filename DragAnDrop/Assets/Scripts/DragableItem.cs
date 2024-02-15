using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IPointerDownHandler,IBeginDragHandler ,IDragHandler, IDropHandler, IEndDragHandler
{
    [Header("Drag Settings")]

    [SerializeField]
    private float _smoothTime;
    [SerializeField]
    private float _onDragAlpha;

    private RectTransform _draggingItem;
    private CanvasGroup _canvasGroup;

    private Vector3 _globalMousePosition;
    private Vector3 _velocity = Vector3.zero;

    private void OnValidate()
    {
        _draggingItem = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = _onDragAlpha;
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetItemPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }

    private void SetItemPosition(PointerEventData eventData)
    {
        if(_draggingItem != null)
        {
            
            //Here we need to transform the touch mouse position in relation of the rectransform of the object and the camera, to the world point to be able to movement the item
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingItem, eventData.position, eventData.pressEventCamera, out _globalMousePosition))
            {
                //SmoothDamp makes the movement of the dragging item be more confortable and soft
                _draggingItem.position = Vector3.SmoothDamp(_draggingItem.position, _globalMousePosition, ref _velocity, _smoothTime);
            }            
        }
    }
}
