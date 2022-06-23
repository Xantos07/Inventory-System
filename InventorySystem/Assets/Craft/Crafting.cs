using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private List<CraftSlotItem> craftSlotItem = new List<CraftSlotItem>();
    [SerializeField] private List<CraftScriptable> craftScriptable = new List<CraftScriptable>();
    
    public CraftingSlotItem craftingSlotItem;
    public int count = 0;
    private void Start()
    {

        craftSlotItem = new List<CraftSlotItem>(GetComponentsInChildren<CraftSlotItem>());
        
        for (int i = 0; i < craftScriptable.Count; i++)
        {
            count = 0;
            
            for (int j = 0; j < craftScriptable[i].ressource.Count; j++)
            {
                for (int k = 0; k < craftSlotItem.Count; k++)
                {
                    if (craftScriptable[i].ressource[j].positionCraft == craftSlotItem[k].GetItemPositionCraft() &&
                        craftSlotItem[k].GetItem() == craftScriptable[i].ressource[j].item)
                    {
                        count++;
                        Debug.Log(count);
                    }
                }   
            }

            if (count == craftScriptable[i].ressource.Count)
            {
                Debug.Log("vous pouvez craft un " + craftScriptable[i].CraftingItemImage.name);
                craftingSlotItem.SetSlot(craftScriptable[i].CraftingItemImage, craftScriptable[i].CraftingItemDescription);
            }
        }
    }

    public void verification()
    {

    }
}