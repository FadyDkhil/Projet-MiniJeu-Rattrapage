using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryImage;
    public GameObject craftingImage;

    public void Start(){
        inventory.Load();
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            inventoryImage.SetActive(true);
           inventory.Save();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            craftingImage.SetActive(true);
        }
    }
    public void OnTriggerEnter(Collider other){
        var item = other.GetComponent<GroundItem>();

        if(item){
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }
}
