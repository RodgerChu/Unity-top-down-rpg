using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public Image icon;
    private ItemSO item;

    public void SetItem(ItemSO item)
    {
        this.item = item;
        icon.sprite = item.Icon;
        icon.gameObject.SetActive(true);
    }

    public void Clear()
    {
        item = null;
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
}
