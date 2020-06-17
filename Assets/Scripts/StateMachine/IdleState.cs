using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.StopMoving();
    }

    public override void OnStateExit(PlayerController player)
    {
        
    }

    public override void Update(PlayerController player)
    {
        var shiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        var hInp = Input.GetAxis("Vertical");
        var vInp = Input.GetAxis("Horizontal");
        var userInput = new Vector3(vInp, 0, hInp);

        if (userInput.x != 0.0 || userInput.y != 0.0 || userInput.z != 0.0)
        {
            player.TransitionToState(shiftPressed ? player.SprintState : player.RunState);
        }
    }
}
