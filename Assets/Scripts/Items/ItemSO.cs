using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject itemPrefab;

    public Sprite Icon
    {
        get { return icon; }
    }

    public GameObject ItemPrefab
    {
        get { return itemPrefab; }
    }

    public void SetIcon(Sprite sprite)
    {
        icon = sprite;
    }

    public void SetPrefab(GameObject prefab)
    {
        itemPrefab = prefab;
    }
}
