using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [Header("Craft or inventory")]
    [SerializeField] private SlotCategory slotCategory;
    
    [Header("General Part")]
    [SerializeField] private int amountItem;
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private Item item;
    
    [Header("Inventory Part")]
    [SerializeField] private InventoryItemUI itemUI;
    
    [Header("Crafting Part")]
    [SerializeField] private ItemPositionCraft positionCraft;
    [SerializeField] private Crafting crafting;

    //

    private void Start()
    {
        Transform child = transform.GetChild(0);
        itemImg = child.GetComponent<Image>();
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt = GetComponentInChildren<TextMeshProUGUI>();
        
        if(slotCategory == SlotCategory.slotInInventory)
            itemUI = GetComponent<InventoryItemUI>();
    }
    
    public void AddItem(Sprite sprite, int _amount)
    {
        amountItem += _amount;

        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
        
       // if(slotCategory == SlotCategory.slotInCrafting)
       //     crafting.verification();
    }
    
    public void SplitItem(Sprite sprite, int _amount)
    {
        amountItem = _amount;
        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
        
      //  if(slotCategory == SlotCategory.slotInCrafting)
       //     crafting.verification();
    }
    
    public void RemoveItem( int _amount)
    {
        amountItem -= _amount;

        itemNumberTxt.text = amountItem.ToString();
        
        if (amountItem <= 0)
        {
            itemNumberTxt.text = "";
            amountItem = 0;
            itemImg.color = new Color(0,0,0,0);
            itemImg.sprite = null;
            item = null;
        }
    }

    public Item GetItem()
    {
        return item;
    }
    public int GetAmountItem()
    {
        return amountItem;
    }
    
    public Image GetImageItem()
    {
        return itemImg;
    }

    public void SetItem(Item _newItem)
    {
        item = _newItem;

        gameObject.AddComponent(_newItem.GetType());
        item = GetComponent<Item>();
        
        item.name =_newItem.name;
        item.description =_newItem.description;
        
        if(slotCategory == SlotCategory.slotInInventory)
         itemUI.SetItem(item);
    }

    public void ResetSlot(Item _newItem)
    {
        amountItem = 0;
        itemImg.sprite = null;
        itemImg.color = new Color(0,0,0,0);
        Destroy(_newItem);
        itemNumberTxt.text = "";
        item = null;
    }
    
    public ItemPositionCraft GetItemPositionCraft()
    {
        return positionCraft;
    }
}

public enum SlotCategory
{
    slotInInventory = 0,
        slotInCrafting = 1
}