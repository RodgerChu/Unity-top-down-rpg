using System;


public class PlayerEquipment
{
    private EquipableItemSO headItem;
    private EquipableItemSO bodyItem;
    private EquipableItemSO leftArmItem;
    private EquipableItemSO rightArmItem;
    private EquipableItemSO legsItem;

    public Action<EquipableItemSO> ItemEquipedEvent;
    public Action<EquipableItemSO> ItemUnequipedEvent;

    public EquipableItemSO GetEquipedItemAt(ItemPositions itemPosition)
    {
        switch (itemPosition)
        {
            case ItemPositions.BODY:
                return bodyItem;                
            case ItemPositions.HEAD:
                return headItem;
            case ItemPositions.LEGS:
                return legsItem;
            case ItemPositions.LEFT_HAND:
                return leftArmItem;
            default:
                return rightArmItem;
        }
    }

    public bool IsItemEquiped(ItemPositions itemPosition)
    {
        return GetEquipedItemAt(itemPosition) != null;
    }

    public void EquipItem(EquipableItemSO item)
    {
        switch (item.ItemPosition)
        {
            case ItemPositions.BODY:
                bodyItem = item;
                break;
            case ItemPositions.HEAD:
                headItem = item;
                break;
            case ItemPositions.LEGS:
                legsItem = item;
                break;
            case ItemPositions.LEFT_HAND:
                leftArmItem = item;
                break;
            case ItemPositions.BOTH_HANDS:
                leftArmItem = item;
                rightArmItem = item;
                break;
            default:
                rightArmItem = item;
                break;
        }

        ItemEquipedEvent(item);
    }

    public void UnequipItemAt(ItemPositions itemPosition)
    {
        EquipableItemSO unequipedItem;
        switch (itemPosition)
        {
            case ItemPositions.BODY:
                unequipedItem = bodyItem;
                bodyItem = null;
                break;
            case ItemPositions.HEAD:
                unequipedItem = headItem;
                headItem = null;
                break;
            case ItemPositions.LEGS:
                unequipedItem = legsItem;
                legsItem = null;
                break;
            case ItemPositions.LEFT_HAND:
                unequipedItem = leftArmItem;
                leftArmItem = null;
                break;
            case ItemPositions.BOTH_HANDS:
                unequipedItem = leftArmItem;
                leftArmItem = null;
                rightArmItem = null;
                break;
            default:
                unequipedItem = rightArmItem;
                rightArmItem = null;
                break;
        }

        ItemUnequipedEvent(unequipedItem);
    }
}
