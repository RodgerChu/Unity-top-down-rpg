using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharSheetCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private EquipableItemSO item;

    private void Start()
    {
        icon.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                var player = GameManager.Instance.currentScene.player;
                player.equipment.UnequipItemAt(item.ItemPosition);
                item = null;
                RemoveIcon();
            }
        }
    }

    public void SetItem(EquipableItemSO item)
    {
        this.icon.sprite = item.Icon;
        this.icon.enabled = true;

        this.item = item;
    }

    public void RemoveIcon()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
