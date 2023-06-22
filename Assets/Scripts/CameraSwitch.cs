using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject normalCam;
    public GameObject supermarketCam;
    public bool camOnNormal;
    // Start is called before the first frame update
    void Start()
    {
        camOnNormal = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            if(camOnNormal){
                normalCam.SetActive(false);
                supermarketCam.SetActive(true);
                camOnNormal = false;
            }else{
                supermarketCam.SetActive(false);
                normalCam.SetActive(true);
                camOnNormal = true;
            }
            
        }
    }
}
