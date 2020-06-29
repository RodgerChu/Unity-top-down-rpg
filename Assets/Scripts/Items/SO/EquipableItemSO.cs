using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItemSO : ItemSO
{

    #region Variables(item) 

    [Header("Name & Type")]
    [SerializeField] private string itemName;
    [SerializeField] private ItemType itemType;
    [SerializeField] private ItemSubtype itemSubtype;
    [SerializeField] private ItemPositions itemPosition;
    [Space]

    [Header("Params")]
    [SerializeField] private int attackPower;
    [SerializeField] private int armor;
    [Tooltip("Number of attack per second")]
    [SerializeField] private int attackSpeed;
    [SerializeField] private int attackRange;
    [SerializeField] private int resourceHarvestPenalty;
    [SerializeField] private bool autoAttack;
    [Space]

    [Header("Tool params")]
    [SerializeField] [Range(0, 100)] private int miningPower;
    [SerializeField] [Range(0, 100)] private int axePower;
    [SerializeField] [Range(0, 100)] private int fishingPower;
    #endregion

    #region Variables(System)

    private bool isAttacking = false;

    #endregion

    #region Getters

    public string ItemName
    {
        get { return itemName; }
    }

    public ItemType Type
    {
        get { return itemType; }
    }

    public ItemSubtype Subtype
    {
        get { return itemSubtype; }
    }

    public ItemPositions ItemPosition
    {
        get { return itemPosition; }
    }

    public bool AutoAttack
    {
        get { return autoAttack; }
    }

    public int AttackPower
    {
        get { return attackPower; }
    }

    public int Armor
    {
        get { return armor; }
    }

    public int MinePower
    {
        get { return miningPower; }
    }

    public int AxePower
    {
        get { return axePower; }
    }

    public int FishingPower
    {
        get { return fishingPower; }
    }

    #endregion
}
