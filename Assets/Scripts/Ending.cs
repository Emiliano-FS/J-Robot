using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject panel;//Panel UI de la imagen. Sostiene todo.
    public bool end=false;

    private void Start()
    {
        panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SoundController.PlaySound("Start");
            Debug.Log("Collider Activado");
            panel.SetActive(true);
            //Muestra la imagen por 2 segundos antes de darte la oportunidad de quitarla.
            end = true;
        }
    }

    void Update()
    {
        if (end)
        {
            if (Input.GetButton("Submit"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
