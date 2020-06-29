using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainSceneManager: MonoBehaviour
{
    public PlayerController player;
    public MainSceneGUIManager guiManager;

    public void ShowInteractKeyHint(bool show, Transform interactable)
    {
        guiManager.SwitchInteractKeyVisibility(show, interactable);
    }

    public void ShowPickUpKeyHing(bool show, bool inventoryFull, Transform interactable)
    {
        guiManager.ShowPickUpKeyHing(show, inventoryFull, interactable);
    }

    public void UpdateInventory()
    {
        guiManager.UpdateInventory();
    }

    public  void SetAmountForResource(ResourceType resourceType, int amount)
    {
        guiManager.SetAmountForResource(resourceType, amount);
    }
}
