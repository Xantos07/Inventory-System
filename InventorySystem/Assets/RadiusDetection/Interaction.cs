using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private List<DetectionElement> _interactionElement;
    [SerializeField] private GameObject panelE;
    [SerializeField] private Interactable objectInteratable;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectInteratable != null)
            {
                Debug.Log($"Object pris et mis dans 'l'invantaire ! ");
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
