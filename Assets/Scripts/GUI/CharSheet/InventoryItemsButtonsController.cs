using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemsButtonsController : MonoBehaviour
{
    public Button closeButton;
    public InventoryActionButton useAction;
    public InventoryActionButton dropActtion;

    private ItemSO clickedItem;
    private bool shown = false;
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(Hide);
        useAction.onClickAction += UseItem;
        dropActtion.onClickAction += DropItem;

        transform.localScale = Vector3.zero;
    }

    private void DropItem()
    {

    }

    private void UseItem()
    {
        if (clickedItem is EquipableItemSO)
        {
            GameManager.Instance.currentScene.player.equipment.EquipItem((EquipableItemSO)clickedItem);
            Hide();
        }
    }

    public void ShowOnPosition(Vector3 position, ItemSO item)
    {
        clickedItem = item;
        transform.localScale = new Vector3(1, 1, 1);
        transform.localPosition = position;
        shown = true;
        transform.position = position;
    }

    public void Hide()
    {
        clickedItem = null;
        transform.localScale = Vector3.zero;
        shown = false;
    }
}
