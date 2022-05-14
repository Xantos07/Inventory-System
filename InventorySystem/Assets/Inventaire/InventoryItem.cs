using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private int amountItem;
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private Item item;
    [SerializeField] private Inventory inventory;
    
    private void Start()
    {
        Transform child = transform.GetChild(0);
        itemImg = child.GetComponent<Image>();
        inventory = GetComponentInParent<Inventory>();
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void AddItem(Sprite sprite, int _amount)
    {
        amountItem += _amount;

        /*
        if (amountItem > item.amountStockableMax)
        {
            int reste = amountItem - item.amountStockableMax;
            Debug.Log($"reste : {reste}");
        }
        */
        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
    }
    
    public void RemoveItem()
    {
        amountItem--;
        
        CheckType();
        
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

    public void SetItem(Item _newItem)
    {
        item = _newItem;
    }

    void CheckType()
    {
        switch (item)
        {
            case Weapon weapon:
                weapon.Equip();
                Debug.Log($"Vous avez pris une arme !"); 
                break;
            case Ressource resource:
                Debug.Log($"Vous avez pris une ressource !"); 
                break;
            case Equipement equipement:
                Debug.Log($"Vous avez pris une equipement !"); 
                break;
            case Potion potion:
                Debug.Log($"Vous avez pris une potion !"); 
                break;
            default:
                Debug.Log($"Vous n'avez rien pris ..."); 
                break;
        }
    }
}
