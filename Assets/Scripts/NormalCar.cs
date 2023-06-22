using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCar : MonoBehaviour
{
    public float speed = 0.1f;
    float x = 17.2f;
    public GameObject Enemy;
    private Cashier cashier;
    // Start is called before the first frame update
    void Start()
    {
        cashier = Enemy.GetComponent<Cashier>();
        this.transform.position = new Vector3(17.2f, 0, 19.73f);
    }
    //-0.948f
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -58){
            x = 79;
            this.transform.position = new Vector3(79, 0, 19.73f);
        }
        x = x - speed;
		this.transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.SetActive(false);
            cashier.LoseGame();
        }
    }
}
