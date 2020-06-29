using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable
{
    public EquipableItemSO item;

    protected override void OnInteract()
    {
        if (GameManager.Instance.currentScene.player.AddToInventory(item))
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(false, null);
            GameManager.Instance.currentScene.UpdateInventory();
            Destroy(gameObject);
        }
        else
        {
            // TODO: No free space, handle it somehow?
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Utils.isPlayer(other.gameObject))
        {
            interactable = true;
            var invFull = GameManager.Instance.currentScene.player.IsInventoryFull();
            GameManager.Instance.currentScene.ShowPickUpKeyHing(true, invFull, transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Utils.isPlayer(other.gameObject))
        {
            Debug.Log(GameManager.Instance);
            Debug.Log(GameManager.Instance.currentScene);
            interactable = false;
            GameManager.Instance.currentScene.ShowPickUpKeyHing(false, false, null);
        }
    }

}
