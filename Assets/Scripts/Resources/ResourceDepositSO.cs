using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceDeposit", menuName = "SO/Resource Deposit", order = 2)]
public class ResourceDepositSO: ScriptableObject
{
    #region Variables(Deposit)

    [SerializeField] private int harvestDifficulty;
    [SerializeField] private ResourceType resourceType;

    #endregion


    #region Getters

    public int HarvestDifficulty
    {
        get { return harvestDifficulty; }
    }

    public ResourceType ResourceType
    {
        get { return resourceType; }
    }

    #endregion


}
