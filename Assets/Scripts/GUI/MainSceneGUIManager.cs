﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneGUIManager : MonoBehaviour
{
    [Header("GUI elements")]
    public GameObject interactHint;
    public GameObject pickUpHint;
    public GameObject inventoryFullMessage;
    public InventoryGUI inventoryGUI;

    private void Awake()
    {
        interactHint.SetActive(false);
        pickUpHint.SetActive(false);
        inventoryFullMessage.SetActive(false);
    }

    public void SwitchInteractKeyVisibility(bool visible)
    {
        interactHint.SetActive(visible);
    }

    public void ShowPickUpKeyHing(bool show, bool inventoryFull)
    {
        pickUpHint.SetActive(show);
        inventoryFullMessage.SetActive(inventoryFull);
    }

    public void UpdateInventory()
    {
        inventoryGUI.UodateGUI();
    }

    public void UpdateInventoryVisibility()
    {

    }
}
