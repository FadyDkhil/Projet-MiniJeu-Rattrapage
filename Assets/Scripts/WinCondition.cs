using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public BagObject bag;
    public GameObject oneStar;
    public GameObject twoStars;
    public GameObject threeStars;

    void Start(){
        this.gameObject.SetActive(false);
        oneStar.SetActive(false);
        twoStars.SetActive(false);
        threeStars.SetActive(false);
    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            
            if(bag.Container.Count == 1 || bag.Container.Count == 2){
                oneStar.SetActive(true);
            }else if(bag.Container.Count == 3){
                twoStars.SetActive(true);
            }else{
                threeStars.SetActive(true);
            }
            bag.Container.Clear();
            //if one star
            
            //if 2 & 3
        }
    }
}
