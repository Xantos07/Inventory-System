using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] private Item item;
    //
    [SerializeField] private RectTransform offsetParent;
    [SerializeField] private RectTransform choicePanel;
    [SerializeField] private ChoiceActionItem choiceActionItem;
    [SerializeField] private RectTransform descriptionPanel;
    private TextMeshProUGUI descriptionText;

    private void Start()
    {
        descriptionText = descriptionPanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetItem(Item _newItem)
    {
        item = _newItem;
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
            RectTransform rect = GetComponent<RectTransform>();
            choicePanel.anchoredPosition = rect.anchoredPosition+new Vector2(offsetParent.offsetMin.x, offsetParent.offsetMax.y);

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
            RectTransform rect = GetComponent<RectTransform>();
            descriptionPanel.anchoredPosition = rect.anchoredPosition+new Vector2(offsetParent.offsetMin.x, offsetParent.offsetMax.y);

            return;
        }
        
        descriptionPanel.gameObject.SetActive(false);
    }
}
