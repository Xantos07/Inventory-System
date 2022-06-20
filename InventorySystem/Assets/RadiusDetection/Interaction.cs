using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private List<DetectionElement> _interactionElement;
    [SerializeField] private GameObject panelE;
    [SerializeField] private Interactable objectInteratable;
    [SerializeField] private Inventory inventory;
    [SerializeField] private DetectionController detectionController;
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        detectionController = GetComponent<DetectionController>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectInteratable != null)
            {
                Item item = objectInteratable.GetComponent<Item>();
                
                playerController.TakeObject();
                
                inventory.RangeItem(item);
                detectionController.RemoveObjectInterractable(objectInteratable.gameObject);
                Destroy(objectInteratable.gameObject);
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
