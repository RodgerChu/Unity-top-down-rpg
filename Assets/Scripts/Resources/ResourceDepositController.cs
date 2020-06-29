using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDepositController : Interactable
{
    public ResourceDepositSO resourceInfo;


    protected override void OnInteract()
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
                    var position = new Vector3(transform.position.x, 0, transform.position.z);
                    
                    player.StartMiningResource(resourceInfo.Resource, position);
                    interactable = false;
                    GameManager.Instance.currentScene.ShowInteractKeyHint(false, null);
                }
                break;
            default:
                Debug.LogWarning("Unknown type of resources");
                break;
        }
    }
}
