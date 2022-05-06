﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    
    public void RangeItem(ItemScriptable _itemScriptable)
    {
        foreach (var myInventoryItem in inventoryItems)
        {
            if (myInventoryItem._itemScriptable !=  null && myInventoryItem._itemScriptable.name == _itemScriptable.name)
            {
                Debug.Log("ajout d'un item deja existant !");
                myInventoryItem.AddItem(_itemScriptable.icon);
                 break;
            }

            if (myInventoryItem._itemScriptable == null)
            {
                Debug.Log("Nouveau item !");
                myInventoryItem._itemScriptable = _itemScriptable;
                myInventoryItem.AddItem(_itemScriptable.icon);   
                return;
            }
        }
    }
}
