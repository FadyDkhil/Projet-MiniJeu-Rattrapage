using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedItem : MonoBehaviour
{
    public GameObject Enemy;
    public bool canPick;
    private Cashier cashier;
    public GameObject MessageClickE;
    // Start is called before the first frame update
    void Start()
    {
        canPick = false;
        cashier = Enemy.GetComponent<Cashier>();
        MessageClickE.SetActive(false);
    }


    void Update(){
        if(canPick){
            pickItem();
        }
    }
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            MessageClickE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                cashier.startRun = true;
                //add item to bag
                MessageClickE.SetActive(false);
                Destroy(this.gameObject);
            }

        }
        
    }

    private void pickItem(){
            if(Input.GetKeyDown(KeyCode.E)){
                cashier.startRun = true;
                //add item to bag
                MessageClickE.SetActive(false);
                canPick = false;
                Destroy(this.gameObject);
            }
    }
    //09889727

}
