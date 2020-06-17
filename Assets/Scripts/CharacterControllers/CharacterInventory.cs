using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private int inventoryBaseSize = 16;
    [SerializeField] private int inventoryBooster = 0;

    int inventoryTotalMaxSize
    {
        get { return inventoryBaseSize + inventoryBooster; }
    }

    private List<ItemSO> items = new List<ItemSO>();


    public bool AddToInventory(ItemSO item)
    {        
        if (!IsInventoryFull())
        {
            items.Add(item);
            return true;
        }

        return false;
    }

    public bool RemoveItem(ItemSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            return true;
        }

        return false;
    }

    public bool IsInventoryFull()
    {
        return items.Count >= inventoryTotalMaxSize;
    }
}
