using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FadeTransitionObserver : MonoBehaviour
{
    public Action OnFadeIn;
    public Action OnFadeOut;

    public void FireOnFadeInEvent()
    {
        OnFadeIn?.Invoke();
    }

    public void FireOnFadeOutEvent()
    {
        OnFadeOut?.Invoke();
    }
}
