using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatSystem: MonoBehaviour
{
    [Header("Health points")]
    [SerializeField] private int currentHealthPoints;
    [SerializeField] private int maxHealthPoints;
    [SerializeField] private int minHealthPoints;

    [Header("Energy points")]
    [SerializeField] private int currentEnergyPoints;
    [SerializeField] private int maxEnergyPoints;
    [SerializeField] private int minEnergyPoints;


    [SerializeField] private int armor;
    [SerializeField] private int attack;

    [SerializeField] private int minePower;
    [SerializeField] private int axePower;

    private int currentExp;

    public PlayerController player;

    private void Start()
    {
        player.equipment.ItemEquipedEvent += HandleEquipItem;
        player.equipment.ItemUnequipedEvent += HandleUnequipItem;
    }

    private void HandleEquipItem(ItemSO item)
    {
        if (item.Type == ItemType.ARMOR)
        {
            armor += item.Armor;
        }
        else if (item.Type == ItemType.WEAPON || item.Type == ItemType.TOOL)
        {
            attack += item.AttackPower;
            minePower += item.MinePower;
            axePower += item.AxePower;
        }
    }

    private void HandleUnequipItem(ItemSO item)
    {
        if (item.Type == ItemType.ARMOR)
        {
            armor -= item.Armor;
        }
        else if (item.Type == ItemType.WEAPON || item.Type == ItemType.TOOL)
        {
            attack -= item.AttackPower;
            minePower -= item.MinePower;
            axePower -= item.AxePower;
        }
    }
}
