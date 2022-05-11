using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    private bool activationMenu = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            activationMenu = !activationMenu;
            inventoryUI.SetActive(activationMenu);
        }
    }
}
