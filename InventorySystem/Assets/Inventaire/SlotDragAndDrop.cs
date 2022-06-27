using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SlotDragAndDrop : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    [SerializeField] private Vector2 orinalPostion;
    private CanvasGroup canvasGroup;
    private InventoryItem inventoryItem;

    public List<InventoryItem> slotDivisionCount;
    
    private PointerEventData eventDataClick;
    private PointerEventData eventDataEnter;
    private bool isDragging = false;
    private int itemCount = 0;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inventoryItem = GetComponent<InventoryItem>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (!isDragging)
        {
            slotDivisionCount.Clear();
            itemCount = 0;
            return;   
        }

        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            if (eventDataClick.pointerClick != null &&eventDataClick.pointerClick.GetComponent<SlotDragAndDrop>() != null)
            {
                GetComponent<RectTransform>().anchoredPosition = eventDataClick.pointerClick.GetComponent<SlotDragAndDrop>().GetOrinalPostion();
                eventDataClick.pointerClick.GetComponent<SlotDragAndDrop>().SetOrinalPostion(orinalPostion);
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
            if (eventDataEnter.pointerEnter != null && 
                eventDataEnter.pointerEnter.GetComponent<InventoryItem>() != null
                && inventoryItem.GetItem() !=null && inventoryItem.GetAmountItem() != 1)
            {
                InventoryItem slot = eventDataEnter.pointerEnter.GetComponent<InventoryItem>();

                if (!slotDivisionCount.Contains(inventoryItem))
                {
                    slotDivisionCount.Add(inventoryItem);
                }
                
                if (!slotDivisionCount.Contains(slot))
                {
                    slotDivisionCount.Add(slot);
                    Split(slot);
                }
            }
        }
    }

    void Split(InventoryItem _slot)
    {
        _slot.SetItem(inventoryItem.GetItem());

        int num = itemCount / (slotDivisionCount.Count );
        int numFinal= 0;

        foreach (InventoryItem slotDivision in slotDivisionCount)
        {
            slotDivision.SliptItem(inventoryItem.GetImageItem().sprite, num);
            Debug.LogWarning("Tu passes au suicant");
            numFinal += num;
        } 

        Debug.LogWarning($"num : {num} / numFinal : {numFinal}");
        
        if (numFinal != itemCount)
        {
            int extra = itemCount - numFinal;
            Debug.LogWarning($"extra {extra}");
            for (int i = 0; i < extra; i++)
            {
                slotDivisionCount[i].AddItem(inventoryItem.GetImageItem().sprite, 1);
            }
        }

        numFinal = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        itemCount = inventoryItem.GetAmountItem();
        Debug.LogWarning(itemCount);
        
        orinalPostion = rectTransform.anchoredPosition;

        if(eventData.pointerClick.GetComponent<SlotDragAndDrop>() == null)
            return;

        canvasGroup.blocksRaycasts = isDragging;
        isDragging = !isDragging;
        
        eventDataClick = eventData;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
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
