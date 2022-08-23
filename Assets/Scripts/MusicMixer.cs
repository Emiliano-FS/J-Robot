using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMixer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            GetComponent<AudioSource>().minDistance = 30;
        }
    }

    private void OnTriggerExit2D(Collider2D collider){

      if(collider.gameObject.tag == "Player"){
        GetComponent<AudioSource>().minDistance = 10;
      }
    }
}
