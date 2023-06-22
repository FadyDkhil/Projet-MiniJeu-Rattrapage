using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Ressources,
    Features
}
public abstract class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite imageDisplay;
    public ItemType type;
    public string itemName; 

}

[System.Serializable]
public class Item
{
    public string Name;
    public int id; 
    public Item(ItemObject item){
        Name = item.itemName;
        id = item.ID;
    }
    
}
