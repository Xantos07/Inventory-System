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
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private ItemPositionCraft positionCraft;
    [SerializeField] private Crafting crafting;
    private void Start()
    {
        Transform child = transform.GetChild(0);
        img = child.GetComponent<Image>();

        img.color = new Color(0,0,0,0);
    }

    public void AddItem(Item _NewItem, Sprite sprite, int _amount)
    {
        amountItem += _amount;
        item = _NewItem;
        img.sprite = sprite;
        img.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
        
        crafting.verification();
    }

    public Item GetItem()
    {
        return item;
    }
    
    public ItemPositionCraft GetItemPositionCraft()
    {
        return positionCraft;
    }
}
