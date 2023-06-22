using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int  X_SPACE_BETWEEN_ITEMS;
    public int  Y_SPACE_BETWEEN_ITEMS;
    public int X_START;
    public int Y_START;
    public int NUMBER_OF_COLUMN;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start(){
        CreateDisplay();
    }

    void Update(){
       UpdateDisplay();
    }

    public void UpdateDisplay(){
        for(int i = 0; i < inventory.container.Items.Count; i++){

            InventorySlot slot = inventory.container.Items[i];
            if(itemsDisplayed.ContainsKey(slot)){
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            }else{
            //setting the world position
            //var obj = Instantiate(inventory.container[i].item.imageDisplay, Vector3.zero, Quaternion.identity, transform);
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.id].imageDisplay;
            //setting the welcome position
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            //setting the amount Text
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0"); 
            //adding to dic
            itemsDisplayed.Add(inventory.container.Items[i], obj);
            }
        } 
    }

    public void CreateDisplay(){
        for(int i = 0;i < inventory.container.Items.Count; i++)
        {
            InventorySlot slot = inventory.container.Items[i];
            //setting the world position
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.id].imageDisplay;
            //setting the welcome position
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            //setting the amount Text
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0"); 
            itemsDisplayed.Add(slot, obj);
        }
    }

    public Vector3 GetPosition(int i){
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}