using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemParams", menuName = "SO/Item", order = 1)]
public class ItemSO : ScriptableObject
{

    #region Visual

    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject itemPrefab;

    #endregion

    #region Variables(item) 

    [Header("Name & Type")]
    [SerializeField] private string itemName;
    [SerializeField] private ItemType itemType;
    [SerializeField] private ItemSubtype itemSubtype;
    [Space]

    [Header("Params")]
    [SerializeField] private int attackPower;
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

    public bool AutoAttack
    {
        get { return autoAttack; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }

    #endregion

    #region Functions (public)

    public virtual void Attack()
    {

    }

    public virtual bool CanHarvest(ResourceDepositSO resource)
    {
        var harvestDifficulty = resource.HarvestDifficulty;
        switch (resource.ResourceType)
        {
            case ResourceType.ORE_DEPOSIT:
                return harvestDifficulty < miningPower;
            case ResourceType.WOOD:
                return harvestDifficulty < axePower;
            case ResourceType.FISH:
                return harvestDifficulty < fishingPower;
            default:
                return true;
        }
    }

    public virtual bool InAttackRange(Vector3 currentPosition, Vector3 enemyPosition)
    {
        var distance = Vector3.Distance(currentPosition, enemyPosition);
        return distance < attackRange;
    }

    public virtual GameObject LoadPrefab()
    {
        return Instantiate(itemPrefab);
    }

    #endregion
}
