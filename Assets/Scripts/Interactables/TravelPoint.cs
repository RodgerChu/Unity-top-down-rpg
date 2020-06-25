using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : MonoBehaviour
{
    public Transform destination;
    public Animator animator;
    public FadeTransitionObserver fadeTransitionObserver;
    public PlayerController player;
    

    private bool interactable = false;

    private void Start()
    {
        
    }


    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fade");
            fadeTransitionObserver.OnFadeIn += onFadeInComplete;
            GameManager.Instance.currentScene.ShowInteractKeyHint(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        var gameObject = other.gameObject;
        if (gameObject.CompareTag(player.gameObject.tag))
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(true);
            interactable = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var gameObject = other.gameObject;
        if (gameObject.CompareTag(player.gameObject.tag))
        {
            GameManager.Instance.currentScene.ShowInteractKeyHint(false);
        }
    }


    private void onFadeInComplete()
    {
        player.TranslateTo(destination.position);        
        animator.SetTrigger("Fade");
        fadeTransitionObserver.OnFadeIn -= onFadeInComplete;
        interactable = false;
    }

    private void onFadeOutComplete()
    {

    }

}
