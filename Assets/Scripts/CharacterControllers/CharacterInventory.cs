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
        if (item is ResourceSO)
        {
            for (int index = 0; index < items.Count; index++)
            {
                var listItem = items[index];
                if (listItem is ResourceSO)
                {
                    if (((ResourceSO)listItem).resourceType == ((ResourceSO)item).resourceType)
                    {
                        Debug.Log("Found item in inventory with type and amount: " + ((ResourceSO)item).resourceType + " " + ((ResourceSO)listItem).amount);
                        Debug.Log("Incrementing it with " + ((ResourceSO)item).amount);
                        ((ResourceSO)listItem).amount += ((ResourceSO)item).amount;
                        GameManager.Instance.currentScene.SetAmountForResource(((ResourceSO)item).resourceType, ((ResourceSO)listItem).amount);
                        Debug.Log("Incremented resource amount: " + ((ResourceSO)listItem).amount);
                        items[index] = listItem;
                        return true;                        
                    }
                }
            }

            if (!IsInventoryFull())
            {
                items.Add(item);
                GameManager.Instance.currentScene.SetAmountForResource(((ResourceSO)item).resourceType, ((ResourceSO)item).amount);                
                return true;
            }
        }
        else if (!IsInventoryFull())
        {
            items.Add(item);
            return true;
        }

        return false;
    }

    public bool RemoveItem(EquipableItemSO item)
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

    public List<ItemSO> GetItems()
    {
        return items;
    }


}
