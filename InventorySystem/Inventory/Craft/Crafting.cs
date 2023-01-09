using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> craftSlotItem = new List<InventoryItem>();
    [SerializeField] private List<CraftScriptable> craftScriptable = new List<CraftScriptable>();
    
    public CraftingSlotItem craftingSlotItem;
    public int count = 0;
    private void Start()
    {
        craftSlotItem = new List<InventoryItem>(GetComponentsInChildren<InventoryItem>());
    }

    public void verification()
    {
        for (int i = 0; i < craftScriptable.Count; i++)
        {
            count = 0;
            
            for (int j = 0; j < craftScriptable[i].ressource.Count; j++)
            {
                for (int k = 0; k < craftSlotItem.Count; k++)
                {
                    if (craftScriptable[i].ressource[j].positionCraft == craftSlotItem[k].GetItemPositionCraft() &&
                        craftSlotItem[k].GetItem() != null &&
                        craftSlotItem[k].GetItem().GetType() == craftScriptable[i].ressource[j].item.GetType())
                    {
                        count++;
                        Debug.LogWarning("Emplacement Correct en " + count);
                    }
                }   
            }

            if (count == craftScriptable[i].ressource.Count)
            {
                Debug.Log("vous pouvez craft un " + craftScriptable[i].CraftImage.name);
                craftingSlotItem.SetSlot(craftScriptable[i].CraftImage, craftScriptable[i].CraftDescription);
                return;
            }

            craftingSlotItem.ResetSlot();
            
        }
    }
}
