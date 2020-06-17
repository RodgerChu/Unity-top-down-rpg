using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public MainSceneManager currentScene;

    override protected void Awake()
    {
        Debug.Log("Game manager awake");
        base.Awake();
    }


}
