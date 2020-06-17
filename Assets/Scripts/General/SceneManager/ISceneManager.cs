using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneManager : Singleton<ISceneManager>
{
    #region Variables

    public PlayerController player;

    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    #region Functions

    virtual public void ShowInteractKeyHint(bool show) { }

    #endregion
}
