using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadordeEscena : MonoBehaviour
{

    public GameObject virtualCam;

    void Start(){

      Application.targetFrameRate = 80;

    }

    private void OnTriggerEnter2D(Collider2D other){

      if(other.CompareTag("Player") && !other.isTrigger){

        virtualCam.SetActive(true);
      }
    }

    private void OnTriggerExit2D(Collider2D other){

      if(other.CompareTag("Player") && !other.isTrigger){
        virtualCam.SetActive(false);
      }
    }

}
