using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private List<DetectionElement> _interactionElement;
    [SerializeField] private GameObject panelE;
    [SerializeField] private Interactable objectInteratable;
    [SerializeField] private Inventory iventory;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectInteratable != null)
            {
                Item item = objectInteratable.GetComponent<Item>();

                iventory.RangeItem(item.itemScriptable);
            }
        }
    }

    public GameObject GetPanelE()
    {
        return panelE;
    }
    
    public List<DetectionElement> GetInteractionElement()
    {
        return _interactionElement;
    }
    
    public void SetObjectInteratable(Interactable _newObj)
    {
        objectInteratable =  _newObj;
    }
}
