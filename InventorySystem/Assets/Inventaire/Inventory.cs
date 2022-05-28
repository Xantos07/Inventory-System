using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    private int extraItem = 0;

    public void RangeItem(Item _item)
    {
        foreach (var myInventoryItem in inventoryItems)
        {
            Debug.Log($"JE récupere un item dans mon inventaire ");

            if (myInventoryItem.GetItem() != null &&
                myInventoryItem.GetAmountItem() != _item.amountStockableMax &&
                myInventoryItem.GetItem().name == _item.name)
            {
                Debug.Log("ajout d'un item deja existant !");
                //myInventoryItem.AddItem(_item.icon,_item.amount);
                VerificationAmountItem(myInventoryItem, _item);
                 break;
            }
            

            if (myInventoryItem.GetItem() == null)
            {
                Debug.Log("Nouveau item !" + _item);
                myInventoryItem.SetItem(_item);
                //myInventoryItem.AddItem(_item.icon,_item.amount);   
                VerificationAmountItem(myInventoryItem, _item);
                return;
            }
        }
    }

    public void VerificationAmountItem(InventoryItem _inventoryItem, Item _item)
    {
        //75 - (100 - 75) = 50
        extraItem = _item.amount - (_item.amountStockableMax - _inventoryItem.GetAmountItem());
        Debug.Log("extraItem : " + extraItem);
        
        if(extraItem <= 0)
        {
            _inventoryItem.AddItem(_item.icon,_item.amount);
            extraItem = 0;
        }

        if (extraItem > 0)
        {
            //75 - 50 = 25
            _inventoryItem.AddItem(_item.icon,_item.amount - extraItem);
            _item.amount = extraItem;
        }
        
        if (extraItem > 0)
        {
            RangeItem(_item);
            _item.amount = extraItem;
        }
    }
    
    /*
    
    public void VerificationAmountItem(InventoryItem _inventoryItem, Item _item)
    {
        extraItem = _item.amount - (_item.amountStockableMax - _inventoryItem.GetAmountItem());

        if(extraItem <= 0)
        {
            extraItem = 0;
            _inventoryItem.AddItem(_item.icon,_item.amount);
        }

        if (_inventoryItem.GetAmountItem() != _item.amountStockableMax)
        {
            Debug.LogWarning($"Tu passes avec {extraItem }");
        }

        if (extraItem > 0)
        {
            _inventoryItem.AddItem(_item.icon,_item.amount - extraItem);  
            
            foreach (var myInventoryItem in inventoryItems)
            {
                Debug.LogWarning($"Tu passes avec {extraItem }");
                if (myInventoryItem.GetItem() != null &&
                    myInventoryItem.GetItem().name == _item.name &&
                    myInventoryItem.GetAmountItem() < 100)
                {
                    Debug.Log("Je rajoute l'item dans mon inventaire de type " + _item);
                    myInventoryItem.AddItem(_item.icon,_item.amount - extraItem);  
                    extraItem = _item.amount - (_item.amountStockableMax - _inventoryItem.GetAmountItem());
                }

                if(myInventoryItem.GetItem() == null && extraItem <= 0)
                {
                    Debug.Log("Je rajoute les reste dans mon inventaire " );
                    extraItem = 0;
                    myInventoryItem.AddItem(_item.icon,_item.amount);
                    break;
                }
                
                _item.amount = extraItem;
            }
        }

        if (extraItem > 0)
        {
            RangeItem(_item);
            _item.amount = extraItem;
        }
        
    }
    */
}
