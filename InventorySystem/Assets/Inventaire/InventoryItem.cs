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
    [SerializeField] private int amountItem;
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private Item item;
    [SerializeField] private InventoryItemUI itemUI;
    //

    private void Start()
    {
        Transform child = transform.GetChild(0);
        itemImg = child.GetComponent<Image>();
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt = GetComponentInChildren<TextMeshProUGUI>();
        
        itemUI = GetComponent<InventoryItemUI>();
    }
    
    public void AddItem(Sprite sprite, int _amount)
    {
        amountItem += _amount;

        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
    }
    
    public void SliptItem(Sprite sprite, int _amount)
    {
        amountItem = _amount;
        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
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
        
        itemUI.SetItem(item);
    }

    public void ResetSlot()
    {
        amountItem = 0;
        itemImg.sprite = null;
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt.text = "";
        item = null;
    }
}
