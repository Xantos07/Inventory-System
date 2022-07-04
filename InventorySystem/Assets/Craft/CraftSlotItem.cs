using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlotItem : MonoBehaviour
{
    [SerializeField] private int amountItem;
    [SerializeField] private Item item;
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private ItemPositionCraft positionCraft;
    [SerializeField] private Crafting crafting;
    private void Start()
    {
        Transform child = transform.GetChild(0);
        itemImg = child.GetComponent<Image>();

        itemImg.color = new Color(0,0,0,0);
    }

    public void AddItem(Item _NewItem, Sprite sprite, int _amount)
    {
        amountItem += _amount;
        item = _NewItem;
        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
        
        crafting.verification();
    }
    
    public void SplitItem(Sprite sprite, int _amount)
    {
        amountItem = _amount;
        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
    }

    public int GetAmountItem()
    {
        return amountItem;
    }
    
    public Image GetImageItem()
    {
        return itemImg;
    }
    public Item GetItem()
    {
        return item;
    }
    
    public ItemPositionCraft GetItemPositionCraft()
    {
        return positionCraft;
    }
    public void SetItem(Item _newItem)
    {
        item = _newItem;

        gameObject.AddComponent(_newItem.GetType());
        item = GetComponent<Item>();
        
        item.name =_newItem.name;
        item.description =_newItem.description;
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
}
