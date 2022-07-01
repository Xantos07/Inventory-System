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
    private CraftSlotItem craftSlotItem;

    public List<InventoryItem> slotDivisionCount;
    public List<CraftSlotItem> slotCraftDivisionCount;
    
    private PointerEventData eventDataClick;
    private PointerEventData eventDataEnter;
    private bool isDragging = false;
    private int itemCount = 0;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inventoryItem = GetComponent<InventoryItem>();
        craftSlotItem = GetComponent<CraftSlotItem>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (!isDragging)
        {
            slotDivisionCount.Clear();
            slotCraftDivisionCount.Clear();
            itemCount = 0;
            return;   
        }

        transform.position = Input.mousePosition;
        transform.SetAsLastSibling();

                
        if (Input.GetMouseButtonDown(0))
        {
            if (eventDataClick.pointerClick != null &&
                eventDataClick.pointerClick.GetComponent<SlotDragAndDrop>() != null &&
                eventDataClick.pointerClick.GetComponent<InventoryItem>() != null && 
                inventoryItem !=null)
            {
                eventDataClick.pointerClick.GetComponent<InventoryItem>().AddItem(inventoryItem.GetImageItem().sprite,inventoryItem.GetAmountItem());
                eventDataClick.pointerClick.GetComponent<InventoryItem>().SetItem(inventoryItem.GetItem());
                inventoryItem.ResetSlot();
                
            } else if (eventDataClick.pointerClick != null &&
                       eventDataClick.pointerClick.GetComponent<SlotDragAndDrop>() != null &&
                       eventDataClick.pointerClick.GetComponent<InventoryItem>() != null &&
                       craftSlotItem != null)
            {
                eventDataClick.pointerClick.GetComponent<InventoryItem>().AddItem(craftSlotItem.GetImageItem().sprite,craftSlotItem.GetAmountItem());
                eventDataClick.pointerClick.GetComponent<InventoryItem>().SetItem(craftSlotItem.GetItem());
                craftSlotItem.ResetSlot();
            }
            else if (eventDataClick.pointerClick != null && inventoryItem !=null &&
                                    eventDataClick.pointerClick.GetComponent<CraftSlotItem>() != null)
            {
 
                eventDataClick.pointerClick.GetComponent<CraftSlotItem>().AddItem(inventoryItem.GetItem(),inventoryItem.GetImageItem().sprite,inventoryItem.GetAmountItem());
                inventoryItem.ResetSlot();
                
            }else if (eventDataClick.pointerClick != null && craftSlotItem !=null &&
                                eventDataClick.pointerClick.GetComponent<CraftSlotItem>() != null)
            {
 
                eventDataClick.pointerClick.GetComponent<CraftSlotItem>().AddItem(craftSlotItem.GetItem(),craftSlotItem.GetImageItem().sprite,craftSlotItem.GetAmountItem());
                craftSlotItem.ResetSlot();
            }
            
            GetComponent<RectTransform>().anchoredPosition = orinalPostion;
            canvasGroup.blocksRaycasts = isDragging;
            isDragging = !isDragging;
        }
        
        if (Input.GetMouseButton(1))
        {
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
            
            if (eventDataEnter.pointerEnter != null && 
                eventDataEnter.pointerEnter.GetComponent<CraftSlotItem>() != null
                && craftSlotItem.GetItem() !=null && craftSlotItem.GetAmountItem() != 1)
            {
                CraftSlotItem slot = eventDataEnter.pointerEnter.GetComponent<CraftSlotItem>();

                if (!slotCraftDivisionCount.Contains(craftSlotItem))
                {
                    slotCraftDivisionCount.Add(craftSlotItem);
                }
                
                if (!slotCraftDivisionCount.Contains(slot))
                {
                    slotCraftDivisionCount.Add(slot);
                    SplitCraft(slot);
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
    }
    
    void SplitCraft(CraftSlotItem _slot)
    {
        _slot.SetItem(craftSlotItem.GetItem());

        int num = itemCount / (slotCraftDivisionCount.Count );
        int numFinal= 0;

        foreach (CraftSlotItem slotDivision in slotCraftDivisionCount)
        {
            slotDivision.SliptItem(craftSlotItem.GetImageItem().sprite, num);
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
                slotCraftDivisionCount[i].AddItem(craftSlotItem.GetItem(),craftSlotItem.GetImageItem().sprite, 1);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerClick.GetComponent<SlotDragAndDrop>() == null)
            return;
        
        
        if (inventoryItem != null && inventoryItem.GetAmountItem() == 0 || 
            craftSlotItem != null && craftSlotItem.GetAmountItem() == 0 )
        {
            return;
        }
        
        if(eventData.pointerClick.GetComponent<InventoryItem>() != null )
        {
            itemCount = inventoryItem.GetAmountItem();
        }

        if (eventData.pointerClick.GetComponent<CraftSlotItem>() != null)
        {
            itemCount = craftSlotItem.GetAmountItem();
        }
        
        orinalPostion = rectTransform.anchoredPosition;

        canvasGroup.blocksRaycasts = isDragging;
        isDragging = !isDragging;
        
        eventDataClick = eventData;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        eventDataEnter = eventData;
    }
}
