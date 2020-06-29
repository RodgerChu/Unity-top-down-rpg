using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSheetController : MonoBehaviour
{
    public CharSheetCell headItemCell;
    public CharSheetCell bodyItemCell;
    public CharSheetCell leftArmItemCell;
    public CharSheetCell rightArmItemCell;
    public CharSheetCell legsItemCell;

    private bool shown = false;

    private void Start()
    {
        var player = GameManager.Instance.currentScene.player;
        player.equipment.ItemEquipedEvent += SetItemIcon;
        player.equipment.ItemUnequipedEvent += ClearItemIconFor;

        gameObject.transform.localScale = Vector3.zero;

    }    

    private void Update()
    {
        if (Input.GetButtonDown("CharSheet"))
        {
            SwitchCharSheetVisibility();
        }
    }

    private void SwitchCharSheetVisibility()
    {
        gameObject.transform.localScale = shown ? Vector3.zero : new Vector3(1, 1, 1);
        shown = !shown;
    }

    private void SetItemIcon(EquipableItemSO item)        
    {
        var itemPosition = item.ItemPosition;
        var icon = item.Icon;

        switch (itemPosition)
        {
            case ItemPositions.BODY:
                bodyItemCell.SetItem(item);
                break;
            case ItemPositions.HEAD:
                headItemCell.SetItem(item);
                break;
            case ItemPositions.LEGS:
                headItemCell.SetItem(item);
                break;
            case ItemPositions.LEFT_HAND:
                leftArmItemCell.SetItem(item);
                break;
            case ItemPositions.BOTH_HANDS:
                leftArmItemCell.SetItem(item);
                rightArmItemCell.SetItem(item);
                break;
            default:
                rightArmItemCell.SetItem(item);
                break;
        }
    }

    private void ClearItemIconFor(EquipableItemSO item)
    {
        var itemPosition = item.ItemPosition;
        switch (itemPosition)
        {
            case ItemPositions.BODY:
                bodyItemCell.RemoveIcon();
                break;
            case ItemPositions.HEAD:
                headItemCell.RemoveIcon();
                break;
            case ItemPositions.LEGS:
                headItemCell.RemoveIcon();
                break;
            case ItemPositions.LEFT_HAND:
                leftArmItemCell.RemoveIcon();
                break;
            case ItemPositions.BOTH_HANDS:
                leftArmItemCell.RemoveIcon();
                rightArmItemCell.RemoveIcon();
                break;
            default:
                rightArmItemCell.RemoveIcon();
                break;
        }
    }
}
