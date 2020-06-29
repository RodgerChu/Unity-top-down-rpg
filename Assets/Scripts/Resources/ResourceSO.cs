using UnityEngine;

[CreateAssetMenu(fileName = "ResourceSO", menuName = "SO/Resource", order = 3)]
public class ResourceSO : ItemSO
{
    public ResourceType resourceType;
    public int amount;
}
