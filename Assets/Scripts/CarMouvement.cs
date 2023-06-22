using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMouvement : MonoBehaviour
{
    public float speed = 0.1f;
    float x = -58;
    public GameObject Enemy;
    private Cashier cashier;
    // Start is called before the first frame update
    void Start()
    {
        cashier = Enemy.GetComponent<Cashier>();
        this.transform.position = new Vector3(-58, 0.95f, 15.88f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 80){
            x = -58f;
            this.transform.position = new Vector3(-58, 0.95f, 15.88f);
        }
        x = x + speed;
		this.transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.SetActive(false);
            cashier.LoseGame();
        }
    }
}
