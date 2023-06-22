using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Feature", menuName = "Inventory System/Items/ Features")]
public class FeatureObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Features;
    }

}
