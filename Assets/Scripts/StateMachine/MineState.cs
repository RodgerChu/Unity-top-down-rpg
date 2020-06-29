using System.Collections;
using UnityEngine;

public class MineState : BaseState
{
    public ResourceSO resourceToMine;

    public override void OnStateEnter(PlayerController player)
    {
        player.StartMining();
        player.StartBackgroundTask(MiningProcess(player));
    }

    public override void OnStateExit(PlayerController player)
    {
        player.StopMining();
        player.StopCoroutine(MiningProcess(player));
    }

    public override void Update(PlayerController player)
    {
        player.IdleState.Update(player);
    }

    private IEnumerator MiningProcess(PlayerController player)
    {
        while(true)
        {
            var elapsedTime = 0f;
            while (elapsedTime < 2f)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            resourceToMine.amount = Random.Range(1, 3);
            var resourceToAdd = new ResourceSO();
            resourceToAdd.amount = resourceToMine.amount;
            resourceToAdd.resourceType = resourceToMine.resourceType;
            resourceToAdd.SetIcon(resourceToMine.Icon);
            resourceToAdd.SetPrefab(resourceToMine.ItemPrefab);
            player.AddToInventory(resourceToAdd);
            GameManager.Instance.currentScene.UpdateInventory();
            yield return null;
        }
    }
}
