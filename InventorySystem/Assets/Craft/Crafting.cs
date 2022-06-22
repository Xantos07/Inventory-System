using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private List<CraftSlotItem> craftSlotItem = new List<CraftSlotItem>();

    private void Start()
    {
        craftSlotItem = new List<CraftSlotItem>(GetComponentsInChildren<CraftSlotItem>());
    }
    
    
}
