using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IPointerClickHandler
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

    private void EquipItem()
    {
        var player = GameManager.Instance.currentScene.player;
        player.equipment.EquipItem(item);
        player.RemoveFromInventory(item);
        GameManager.Instance.currentScene.UpdateInventory();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
                EquipItem();
        }
    }
}
