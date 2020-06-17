using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : MonoBehaviour
{
    public Transform cellParent;
    private InventoryCell[] cells;

    private void Awake()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        cells = cellParent.GetComponentsInChildren<InventoryCell>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            UpdateInventoryVisibility();
        }
    }

    public void UodateGUI()
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
        gameObject.transform.localScale = gameObject.transform.localScale == Vector3.zero ? new Vector3(1, 1, 1) : Vector3.zero;
    }
}
