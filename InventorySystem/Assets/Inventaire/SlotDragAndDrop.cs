using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    [SerializeField] private Vector2 orinalPostion;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        orinalPostion = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        orinalPostion = rectTransform.anchoredPosition;
        Debug.Log($"alros vous etes en {orinalPostion} + {name}");
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        canvasGroup.blocksRaycasts = false;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null || eventData.pointerEnter != null &&
            eventData.pointerEnter.GetComponent<SlotDragAndDrop>() == null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = orinalPostion;   
        }
        
        
        
        CraftSlotItem craft = eventData.pointerEnter.GetComponent<CraftSlotItem>();
        
        if (craft != null)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            craft.AddItem(inventoryItem.GetItem(),inventoryItem.GetImageItem().sprite,inventoryItem.GetAmountItem());
            inventoryItem.ResetSlot();
        }

        canvasGroup.blocksRaycasts = true;

    }

    public void OnDrop(PointerEventData eventData)
    {
        // Je drag sur celui que je pointe 
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition;
        
        GetComponent<SlotDragAndDrop>().SetOrinalPostion(eventData.pointerDrag.GetComponent<SlotDragAndDrop>().GetOrinalPostion());
    }

    public void SetOrinalPostion(Vector2 _newPostion)
    {
        orinalPostion = _newPostion;
        rectTransform.anchoredPosition = orinalPostion;
    }
    
    public Vector2 GetOrinalPostion()
    {
        return orinalPostion;
    }
}
