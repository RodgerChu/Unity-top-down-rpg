using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public PlayerController player;

    public bool PickUpItem(EquipableItemSO item)
    {
        return player.AddToInventory(item);
    }
}
