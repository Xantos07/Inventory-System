using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SlotDragAndDrop : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    [SerializeField] private Vector2 orinalPostion;
    private CanvasGroup canvasGroup;
    private InventoryItem inventoryItem;

    public List<InventoryItem> slotDivisionCount;
    
    private PointerEventData eventDataEnter;
    private bool isDragging = false;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inventoryItem = GetComponent<InventoryItem>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (!isDragging)
            return;
        
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            if (eventDataEnter.pointerClick != null &&eventDataEnter.pointerClick.GetComponent<SlotDragAndDrop>() != null)
            {
                GetComponent<RectTransform>().anchoredPosition = eventDataEnter.pointerClick.GetComponent<SlotDragAndDrop>().GetOrinalPostion();
                eventDataEnter.pointerClick.GetComponent<SlotDragAndDrop>().SetOrinalPostion(orinalPostion);
            }
            else
            {
                GetComponent<RectTransform>().anchoredPosition = orinalPostion;   
            }

            canvasGroup.blocksRaycasts = isDragging;
            isDragging = !isDragging;
        }
        
        if (Input.GetMouseButton(1))
        {
Debug.Log("tu es entrain de diviser");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        orinalPostion = rectTransform.anchoredPosition;

        if(eventData.pointerClick.GetComponent<SlotDragAndDrop>() == null)
            return;

        canvasGroup.blocksRaycasts = isDragging;
        isDragging = !isDragging;
        
        eventDataEnter = eventData;
    }
    public void SetOrinalPostion(Vector2 _newPostion)
    {
        orinalPostion = _newPostion;
        rectTransform.anchoredPosition = orinalPostion;
    }
    
    public Vector2 GetOrinalPostion()
    {
        orinalPostion = rectTransform.anchoredPosition;
        return orinalPostion;
    }
}
