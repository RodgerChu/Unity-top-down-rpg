using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUI : MonoBehaviour
{
    public Transform cellParent;
    public Button button;
    public InventoryItemsButtonsController actionButtons;
    private InventoryCell[] cells;

    private void Awake()
    {
        gameObject.transform.localScale = Vector3.zero;
        button.onClick.AddListener(UpdateInventoryVisibility);
    }

    private void Start()
    {
        cells = cellParent.GetComponentsInChildren<InventoryCell>();
        var player = GameManager.Instance.currentScene.player;
        player.equipment.ItemEquipedEvent += (item) => UpdateGUI();
        player.equipment.ItemUnequipedEvent += (item) => UpdateGUI();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            UpdateInventoryVisibility();
        }
    }

    public void UpdateGUI()
    {
        var player = GameManager.Instance.currentScene.player;
        var items = player.GetItems();

        for (int i = 0; i < cells.Length; i++)
        {
            var cell = cells[i];
            if (i < items.Count)
            {
                var item = items[i];
                cell.SetItem(item);
            }
            else
            {
                cell.Clear();
            }
        }
    }

    public void UpdateInventoryVisibility()
    {
        Debug.Log("Update called");
        gameObject.transform.localScale = gameObject.transform.localScale == Vector3.zero ? new Vector3(1, 1, 1) : Vector3.zero;
        if (gameObject.transform.localScale == Vector3.zero)
        {
            actionButtons.Hide();
        }
    }
}
