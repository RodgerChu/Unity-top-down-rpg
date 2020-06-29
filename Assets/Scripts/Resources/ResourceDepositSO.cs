using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceDeposit", menuName = "SO/Resource Deposit", order = 2)]
public class ResourceDepositSO: ScriptableObject
{
    #region Variables(Deposit)

    [SerializeField] private int harvestDifficulty;    
    [SerializeField] private ResourceSO resource;

    #endregion


    #region Getters

    public int HarvestDifficulty
    {
        get { return harvestDifficulty; }
    }

    public ResourceType ResourceType
    {
        get { return resource.resourceType; }
    }

    public ResourceSO Resource
    {
        get { return resource; }
    }

    #endregion


}
