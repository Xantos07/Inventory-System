using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private int amountItem;
    [SerializeField] private Image img;
    [SerializeField] private Text txt;

    public ItemScriptable _itemScriptable;
    //public ItemScriptable _itemScriptable { get; private set; }

    private void Start()
    {
        img = GetComponent<Image>();
        txt = GetComponentInChildren<Text>();
    }

    public void AddItem(Sprite sprite)
    {
        amountItem++;
        img.sprite = sprite;
        txt.text = amountItem.ToString();
    }

    public void RemoveItem()
    {
        amountItem--;
        txt.text = amountItem.ToString();
        if (amountItem <= 0)
        {
            img.sprite = null;
        }
    }
    
}
