using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterViewScript : MonoBehaviour
{
    public GameObject walls;
    public GameObject refs;
    public GameObject ceiling;
    public bool playerInside;
    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
    }

    private void OnTriggerEnter(Collider col){
       // Debug.Log("betterview");
        if(col.gameObject.tag == "Player"){
            //Debug.Log("player");
            if(!playerInside){
                ceiling.SetActive(false);
                walls.SetActive(false);
                refs.SetActive(false);
                playerInside = true;
            }else{
                ceiling.SetActive(true);
                walls.SetActive(true);
                refs.SetActive(true);
                playerInside = false;
            }
        }
    }
}
