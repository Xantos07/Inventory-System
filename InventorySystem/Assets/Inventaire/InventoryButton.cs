using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ActionButton
{
    Drop,
    Use,
    Equip
}

public class InventoryButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ActionButton actionButton;
    [SerializeField] private Item item;
    [SerializeField] private GameObject inventoryItem;
    private void OnEnable()
    {
        //A mettre verification de l'item
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        actionItem();
        inventoryItem.SetActive(false);
    }
    
    public void SetItem(Item _newItem)
    {
        item = _newItem;
    }
    
    public void actionItem()
    {
        switch (actionButton)
        {
            case ActionButton.Drop :
                Debug.Log("Action Drop");
                item.DropItem();
                break;
            case ActionButton.Use :
                Debug.Log("Action Use");
                CheckType();
                break;
            case ActionButton.Equip :
                Debug.Log("Action Equip");    
                CheckType();
                break;
            default : 
                Debug.Log("Nada");    
                break;
        }
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
                equipement.Equip();
                Debug.Log($"Vous avez pris une equipement !"); 
                break;
            case Potion potion:
                potion.Use();
                Debug.Log($"Vous avez pris une potion !"); 
                break;
            default:
                Debug.Log($"Vous n'avez rien pris ..."); 
                break;
        }
    }
}
