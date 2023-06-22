using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public float distanceInteraction = 1.4f;
    public float distance;
    public GameObject MessageClickE;
    public GameObject Player;

    public GameObject Enemy;
    private Cashier cashier;

    public GameObject winCondition;

    public Grocery grocery;
    public BagObject bag;
    // Start is called before the first frame update
    void Start()
    {
        cashier = Enemy.GetComponent<Cashier>();
        MessageClickE.SetActive(false);
        distance = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance <= distanceInteraction){
            MessageClickE.SetActive(true);
        }else{
            MessageClickE.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            if(distance <= distanceInteraction){
                Collect();
            }
        }
    }

    private void Collect(){
        bag.AddGrocery(grocery.grocery, 1);
        cashier.startRun = true;
        MessageClickE.SetActive(false);
        winCondition.SetActive(true);
        Destroy(this.gameObject);
    }
}
