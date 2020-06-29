using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneGUIManager : MonoBehaviour
{
    [Header("GUI elements")]
    [SerializeField] private GameObject interactHint;
    [SerializeField] private GameObject pickUpHint;
    [SerializeField] private GameObject inventoryFullMessage;
    [SerializeField] private InventoryGUI inventoryGUI;
    [SerializeField] private HUDController hudControlelr;


    private Transform interactableObjectPosition;

    private void Awake()
    {
        interactHint.SetActive(false);
        pickUpHint.SetActive(false);
        inventoryFullMessage.SetActive(false);
    }

    private void Update()
    {
        if (interactHint.activeInHierarchy)
        {
            var interactablePosition = Camera.main.WorldToScreenPoint(interactableObjectPosition.position);
            var playerPosition = GameManager.Instance.currentScene.player.transform.position;
            var playerPositionOnScreen = Camera.main.WorldToScreenPoint(playerPosition);
            interactHint.transform.position = (playerPositionOnScreen + interactablePosition) / 2;
        }
    }

    public void SwitchInteractKeyVisibility(bool visible, Transform interactable)
    {
        interactableObjectPosition = interactable;
        interactHint.SetActive(visible);        
    }

    public void ShowPickUpKeyHing(bool show, bool inventoryFull, Transform interactable)
    {
        SwitchInteractKeyVisibility(show, interactable);
        inventoryFullMessage.SetActive(inventoryFull);
    }

    public void UpdateInventory()
    {
        inventoryGUI.UpdateGUI();
    }

    public void SetAmountForResource(ResourceType resourceType, int amount)
    {
        hudControlelr.SetAmountForResource(resourceType, amount);
    }
}
