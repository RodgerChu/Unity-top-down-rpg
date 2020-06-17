using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : BaseState
{
    public override void OnStateEnter(PlayerController player)
    {
        var shiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        var hInp = Input.GetAxis("Vertical");
        var vInp = Input.GetAxis("Horizontal");
        var userInput = new Vector3(vInp, 0, hInp);

        HandlePlayerInput(userInput, player);
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

        if (!shiftPressed && userInput != Vector3.zero)
        {
            player.TransitionToState(player.RunState);
        }
        else if (shiftPressed && userInput != Vector3.zero)
        {
            HandlePlayerInput(userInput, player);
        }
        else
        {
            player.TransitionToState(player.IdleState);
        }
    }

    private void HandlePlayerInput(Vector3 userInput, PlayerController player)
    {
        var cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;

        var cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
        var lookForward = cameraRelativeRotation * userInput;

        var lookRay = new Ray(player.transform.position, lookForward);
        player.transform.LookAt(lookRay.GetPoint(1));

        userInput *= 1.5f;
        
        player.MoveTo(userInput / 13);
    }
}
