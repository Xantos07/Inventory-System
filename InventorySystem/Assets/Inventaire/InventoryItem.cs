using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private int amountItem;
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;

    public ItemScriptable _itemScriptable;
    //public ItemScriptable _itemScriptable { get; private set; }

    private void Start()
    {
        Transform t = gameObject.transform.GetChild(0);
        itemImg = t.GetComponent<Image>();
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddItem(Sprite sprite)
    {
        amountItem++;
        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
    }

    public void RemoveItem()
    {
        amountItem--;
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt.text = amountItem.ToString();
        if (amountItem <= 0)
        {
            itemImg.sprite = null;
        }
    }
    
}
