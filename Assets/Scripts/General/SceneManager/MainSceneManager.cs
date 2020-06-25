using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainSceneManager: MonoBehaviour
{
    public PlayerController player;
    public MainSceneGUIManager guiManager;

    public void ShowInteractKeyHint(bool show)
    {
        guiManager.SwitchInteractKeyVisibility(show);
    }

    public void ShowPickUpKeyHing(bool show, bool inventoryFull)
    {
        guiManager.ShowPickUpKeyHing(show, inventoryFull);
    }

    public void UpdateInventory()
    {
        guiManager.UpdateInventory();
    }
}
