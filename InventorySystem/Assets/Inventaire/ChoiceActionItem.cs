using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceActionItem : MonoBehaviour
{
    [SerializeField] private List<InventoryButton> buttonsPanel;
    [SerializeField] private Item item;
    [SerializeField] private RectTransform buttonsPanelUI;
    [Range(0,500)]
    [SerializeField] private float HeightBtwButton = 75f;
    private int baseHeight = 0;

    public void ScalePanel()
    {
        buttonsPanelUI.sizeDelta = new Vector2(buttonsPanelUI.sizeDelta.x, baseHeight * HeightBtwButton);
        
        baseHeight = 0;
    }
    
    public void UpdateViewButton()
    {
        foreach (InventoryButton myButton in buttonsPanel)
        {
            myButton.SetItem(item);
            myButton.gameObject.SetActive(false);
        }
        
        buttonsPanel[0].gameObject.SetActive(true);
        checkType();
        ScalePanel();
    }

    public void SetItem(Item _newItem)
    {
        item = _newItem;
    }
    
    void checkType()
    {
        switch (item)
        {
            case Weapon weapon:
                buttonsPanel[1].gameObject.SetActive(true);
                baseHeight++;
                break;
            case Ressource resource:
                Debug.Log($"resource !"); 
                baseHeight++;
                break;
            case Equipement equipement:
                equipement.Equip();
                buttonsPanel[1].gameObject.SetActive(true);
                Debug.Log($"equipement !"); 
                baseHeight++;
                break;
            case Potion potion:
                potion.Use();
                buttonsPanel[2].gameObject.SetActive(true);
                Debug.Log($"potion !"); 
                baseHeight++;
                break;
            default:
                Debug.Log($"Vous n'avez rien pris ..."); 
                break;
        }
    }
}
