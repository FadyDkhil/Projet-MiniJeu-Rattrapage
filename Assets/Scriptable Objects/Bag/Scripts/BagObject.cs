using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Bag/New")]
public class BagObject : ScriptableObject
{
    public List<BagSlot> Container = new List<BagSlot>();

    public void AddGrocery(GroceryObject _grocery, int _amount){
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++){
            if(Container[i].grocery == _grocery){
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if(!hasItem){
            Container.Add(new BagSlot(_grocery, _amount)); 
        }
    }
}

[System.Serializable]
public class BagSlot
{
    public GroceryObject grocery;
    public int amount;
    public BagSlot(GroceryObject _grocery, int _amount){
        grocery = _grocery;
        amount = _amount;
    }
    public void AddAmount(int value){
        amount += value;
    }
}