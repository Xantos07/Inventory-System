using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    private SlotDragAndDrop slotDragAndDrop;

    private bool isDragging = false;
    private bool canSplit = false;
    
    private InventoryItem inventoryItemSelected;
    private CraftSlotItem craftSlotItemSelected;
    public List<InventoryItem> slotDivisionCount;
    public Crafting crafting;
    
    private float key;
    private int itemCount = 0;
    private void Update()
    {
        if (!isDragging)
        {
            slotDivisionCount.Clear();
            canSplit = false;
            key = 0;
            return;
        }
        
        slotDragAndDrop.transform.position = Input.mousePosition;
        slotDragAndDrop.transform.SetAsLastSibling();

        if (Input.anyKey && ! Input.GetMouseButton(0))
        {
            ResetSlot();
            
            canSplit = false;
            key = 0;
        }
    }

    public void ResetSlot()
    {
        if(slotDragAndDrop == null)
            return;
        
        slotDragAndDrop.ResetPosition();
        isDragging = !isDragging;
        slotDragAndDrop = null;
    }

    public void AddToSlot(InventoryItem _newInventoryItem)
    {
        _newInventoryItem.AddItem(inventoryItemSelected.GetImageItem().sprite,inventoryItemSelected.GetAmountItem());
        
        if(_newInventoryItem.GetItem() == null)
         _newInventoryItem.SetItem(inventoryItemSelected.GetItem());
        
        inventoryItemSelected.ResetSlot(inventoryItemSelected.GetItem());
        //
        ResetSlot();
        
        crafting.verification();
    }
    
    public void Split(InventoryItem _slot)
    {
        _slot.SetItem(inventoryItemSelected.GetItem());

        int num = itemCount / (slotDivisionCount.Count );
        int numFinal= 0;

        foreach (InventoryItem slotDivision in slotDivisionCount)
        {
            slotDivision.SplitItem(inventoryItemSelected.GetImageItem().sprite, num);
            numFinal += num;
        } 
        
        if (numFinal != itemCount)
        {
            int extra = itemCount - numFinal;
            for (int i = 0; i < extra; i++)
            {
                slotDivisionCount[i].AddItem(inventoryItemSelected.GetImageItem().sprite, 1);
            }
        }
        
        crafting.verification();
    }
    
    public void SetSlot(SlotDragAndDrop _newSlot, InventoryItem _newInventoryItem)
    {
        inventoryItemSelected = _newInventoryItem;
        itemCount = _newInventoryItem.GetAmountItem();
        slotDragAndDrop = _newSlot;
        isDragging = !isDragging;
    }

    public SlotDragAndDrop GetSlot()
    {
        return slotDragAndDrop;
    }

    public void OnCancelSlot(InputValue value)
    {
        Debug.Log("CancelSlot" + value.Get<float>());
        key = value.Get<float>();
    }

    public void SetDivisionCount(InventoryItem _inventoryItem)
    {       
        //Debug.LogWarning("canSplit" + canSplit);
        if(canSplit == false)
            return;
        
        if(inventoryItemSelected.GetAmountItem() <= 1)
            return;
        
        if (!slotDivisionCount.Contains(inventoryItemSelected))
        {
            slotDivisionCount.Add(inventoryItemSelected);
        }
        
        if (!slotDivisionCount.Contains(_inventoryItem))
        {
            slotDivisionCount.Add(_inventoryItem);
            Split(_inventoryItem);
        }
    }
    
    public void OnHoldClick(InputValue value)
    {
        if (value.Get<float>() == 1) canSplit = true;
    }
    
    public void OnStopHoldClick(InputValue value)
    {
        if (value.Get<float>() == 0) canSplit = false;

    }
}
