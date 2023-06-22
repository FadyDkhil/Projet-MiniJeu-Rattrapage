using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/ Inventory")]
public class InventoryObject : ScriptableObject //ISerializationCallbackReceiver
{
    public ItemDataBaseObject database;
    public Inventory container;
    public string savePath;
    public void AddItem(Item item, int amount){
        for(int i = 0; i<container.Items.Count ; i++){
            if(container.Items[i].item.id == item.id){
                container.Items[i].addAmount(amount);
                return;
            }
        }
        //container.Add(new InventorySlot(database.GetID[item], item, amount));
        container.Items.Add(new InventorySlot(item.id, item, amount));
    
    }
        public void OnAfterDeserialize(){
            // for(int i = 0; i < container.Items.Count; i++){
            //    //container.Items[i].item = database.GetItem[container.Items[i].ID];
            //    container.Items[i].item = database.GetItem[container.Items[i].ID];
            // }
            
    }

    public void OnBeforeSerialize(){
        
    }

    //  SAVE - LOAD - CLEAR 
    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
           Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < container.Items.Count; i++)
            {
                container.Items[i].UpdateSlot(newContainer.Items[i].ID, newContainer.Items[i].item, newContainer.Items[i].amount);
            }
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        container = new Inventory();
    }
    
}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
    
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;

    //ctor
    public InventorySlot(int ID, Item item, int amount){
        this.ID = ID;
        this.item = item;
        this.amount = amount;
    }
      public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void addAmount(int value){
        amount += value;
    }
}