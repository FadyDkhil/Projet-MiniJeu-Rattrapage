using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Grocery", menuName = "Groceries/New")]
public class GroceryObject : ScriptableObject 
{
    public GameObject prefab;
    public string groceryName;
}
