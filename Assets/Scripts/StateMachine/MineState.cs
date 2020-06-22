using UnityEngine;

public class MineState : BaseState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.StartMining();
    }

    public override void OnStateExit(PlayerController player)
    {
        player.StopMining();
    }

    public override void Update(PlayerController player)
    {
        player.IdleState.Update(player);
    }
}
