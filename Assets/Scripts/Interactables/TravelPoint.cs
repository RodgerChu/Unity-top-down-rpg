using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : Interactable
{
    public Transform destination;
    public Animator animator;
    public FadeTransitionObserver fadeTransitionObserver;
    


    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fade");
            fadeTransitionObserver.OnFadeIn += onFadeInComplete;
            GameManager.Instance.currentScene.ShowInteractKeyHint(false, transform);
        }
    }

    protected override void OnInteract()
    {
        animator.SetTrigger("Fade");
        fadeTransitionObserver.OnFadeIn += onFadeInComplete;
        GameManager.Instance.currentScene.ShowInteractKeyHint(false, transform);
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
