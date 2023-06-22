using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Inventory System/ Database")]
public class ItemDataBaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;

   // public Dictionary<ItemObject, int> GetID = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize(){
        //GetID = new Dictionary<ItemObject, int>();
        //GetItem = new Dictionary<int, ItemObject>();
        for(int i = 0; i < Items.Length; i++){
            //GetID.Add(Items[i], i);
            Items[i].ID = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize(){
        GetItem = new Dictionary<int, ItemObject>();
        
    }
}
