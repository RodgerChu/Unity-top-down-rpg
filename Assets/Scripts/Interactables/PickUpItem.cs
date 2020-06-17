using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSO))]
public class PickUpItem : MonoBehaviour
{
    private ItemSO item;
    private bool interactable = false;

    private void Awake()
    {
        item = GetComponent<ItemSO>();
    }

    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {                
                if (GameManager.Instance.currentScene.player.AddToInventory(item))
                {
                    GameManager.Instance.currentScene.ShowInteractKeyHint(false);
                    Destroy(gameObject);
                }
                else
                {
                    // TODO: No free space, handle it somehow?
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Utils.isPlayer(other.gameObject))
        {
            interactable = true;
            var invFull = GameManager.Instance.currentScene.player.IsInventoryFull();
            GameManager.Instance.currentScene.ShowPickUpKeyHing(true, invFull);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Utils.isPlayer(other.gameObject))
        {
            Debug.Log(GameManager.Instance);
            Debug.Log(GameManager.Instance.currentScene);
            interactable = false;
            GameManager.Instance.currentScene.ShowPickUpKeyHing(false, false);
        }
    }

}
