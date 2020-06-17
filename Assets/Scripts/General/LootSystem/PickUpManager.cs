using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public PlayerController player;

    public bool PickUpItem(ItemSO item)
    {
        return player.AddToInventory(item);
    }
}
