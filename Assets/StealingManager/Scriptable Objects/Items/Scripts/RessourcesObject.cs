using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ressource", menuName = "Inventory System/Items/ Ressources")]
public class RessourcesObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Ressources;
    }

}
