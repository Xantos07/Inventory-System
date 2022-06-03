using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] private int amountItem;
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private Item item;
    //
    [SerializeField] private RectTransform choicePanel;
    [SerializeField] private ChoiceActionItem choiceActionItem;
    [SerializeField] private RectTransform descriptionPanel;
    private TextMeshProUGUI descriptionText;
    //
    
    private void Start()
    {
        Transform child = transform.GetChild(0);
        itemImg = child.GetComponent<Image>();
        itemImg.color = new Color(0,0,0,0);
        itemNumberTxt = GetComponentInChildren<TextMeshProUGUI>();
        descriptionText = descriptionPanel.GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void AddItem(Sprite sprite, int _amount)
    {
        amountItem += _amount;

        itemImg.sprite = sprite;
        itemImg.color = new Color(255,255,255,255);
        itemNumberTxt.text = amountItem.ToString();
    }
    
    public void RemoveItem()
    {
        amountItem--;

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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            choicePanel.gameObject.SetActive(true);
            
            choiceActionItem.SetItem(item);
            choiceActionItem.UpdateViewButton();
            
            descriptionPanel.gameObject.SetActive(false);
            
            // non par rapport a la dimention de l'écran
            choicePanel.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log($"choicePanel.anchoredPosition : {choicePanel.anchoredPosition}");
            return;
        }
        
        choicePanel.gameObject.SetActive(false);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.gameObject.SetActive(false);
        choicePanel.gameObject.SetActive(false);
        
        if (item != null)
        {
            descriptionPanel.gameObject.SetActive(true);
            descriptionText.text = item.description;
            
            // non par rapport a la dimention de l'écran
            descriptionPanel.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log($"descriptionPanel.anchoredPosition : {descriptionPanel.anchoredPosition}");
            return;
        }
        
        descriptionPanel.gameObject.SetActive(false);
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

        gameObject.AddComponent(_newItem.GetType());
        item = GetComponent<Item>();
        
        item.name =_newItem.name;
        item.description =_newItem.description;
    }
}
