using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool interactable = false;
    public PlayerController player;

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.F))
        {
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {
        Debug.LogError("Interact not implemented!!!");
    }



    private void OnTriggerEnter(Collider other)
    {
        var gameObject = other.gameObject;
        if (gameObject.CompareTag(player.gameObject.tag))
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(true, transform);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var gameObject = other.gameObject;
        if (gameObject.CompareTag(player.gameObject.tag))
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(false, null);
        }
    }
}
