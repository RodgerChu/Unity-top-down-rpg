using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState {
    public abstract void OnStateEnter(PlayerController player);
    public abstract void Update(PlayerController player);
    public abstract void OnStateExit(PlayerController player);
}
