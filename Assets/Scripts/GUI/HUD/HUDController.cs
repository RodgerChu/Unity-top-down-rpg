using UnityEngine;

public class HUDController : MonoBehaviour
{
    public HUDResourceCell woodCell;
    public HUDResourceCell foodCell;
    public HUDResourceCell ironCell;


    private void Start()
    {
        woodCell.SetAmount(0);
        foodCell.SetAmount(0);
        ironCell.SetAmount(0);
    }


    public void SetAmountForResource(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.WOOD:
                woodCell.SetAmount(amount);
                break;
            case ResourceType.FARM:                    
            case ResourceType.FISH:
                foodCell.SetAmount(amount);
                break;
            case ResourceType.ORE_DEPOSIT:
                ironCell.SetAmount(amount);
                break;
            default:
                Debug.LogWarning("Set amount was called for unknow resource type: " + resourceType);
                break;
        }
    }
}
