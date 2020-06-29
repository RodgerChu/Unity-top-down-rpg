using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public InventoryItemsButtonsController InventoryActionButtons;
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
        if (item is EquipableItemSO)
        {
            var player = GameManager.Instance.currentScene.player;
            player.equipment.EquipItem((EquipableItemSO)item);
            player.RemoveFromInventory((EquipableItemSO)item);
            GameManager.Instance.currentScene.UpdateInventory();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
                EquipItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            var position = new Vector3(transform.position.x - 60, transform.position.y, transform.position.z);
            InventoryActionButtons.ShowOnPosition(position, item);
        }
    }
}
