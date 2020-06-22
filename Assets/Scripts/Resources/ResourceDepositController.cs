using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDepositController : MonoBehaviour
{
    public ResourceDepositSO resourceInfo;
    public string playerTag;

    private bool canInteract = false;


    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetButtonDown("Interact"))
            {
                var resourceType = resourceInfo.ResourceType;
                var player = GameManager.Instance.currentScene.player;
                var equipedItem = player.equipment.GetEquipedItemAt(ItemPositions.LEFT_HAND);
                if (equipedItem == null) { return; }
                switch (resourceType)
                {
                    case ResourceType.FARM:
                        break;
                    case ResourceType.ORE_DEPOSIT:
                        if (equipedItem.Subtype == ItemSubtype.PICKAXE)
                        {
                            player.TransitionToState(player.MineState);
                            GameManager.Instance.currentScene.ShowInteractKeyHint(false);
                        }
                        break;
                    default:
                        Debug.LogWarning("Unknown type of resources");
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var gameObject = other.gameObject;
        if (gameObject.tag == playerTag)
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(true);
            canInteract = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        var gameObject = other.gameObject;
        if (gameObject.tag == playerTag)
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(false);
            canInteract = false;
        }
    }
}
