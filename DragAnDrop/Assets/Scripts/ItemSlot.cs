using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _glowSlot;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ITEM DROPPED");
        _glowSlot.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _glowSlot.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _glowSlot.SetActive(false);
    }
}

