using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlotItem : MonoBehaviour
{
    [SerializeField] private Image itemImg;
    [SerializeField] private TextMeshProUGUI descriptionTxt;

    private void Awake()
    {
        itemImg.color = new Color(0,0,0,0);
    }

    public void SetSlot(Sprite _newSprite, string _newDescription)
    {
        itemImg.sprite = _newSprite;
        itemImg.color = new Color(255,255,255,255);

        descriptionTxt.text = _newDescription;
    }
}
