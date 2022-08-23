using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public GameObject panel;//Panel UI de la imagen. Sostiene todo.
    public Image imageUI;
    public Sprite splashImage;//Imagen que aparece despues de tomar el objeto
    [SerializeField] public string text;//Descripcion del Objeto.
    public TextMeshProUGUI textUI;//Text Mesh Pro.

    private bool show;

    private void Start()
    {
        show = false;
        panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SoundController.PlaySound("item");
            imageUI.sprite = splashImage;
            textUI.text = text;
            Debug.Log("Collider Activado");
            panel.SetActive(true);
            StartCoroutine(showImage());
            //Muestra la imagen por 2 segundos antes de darte la oportunidad de quitarla.
            DialogueManager.GetInstance().pickObject = true;
        }
    }

    private IEnumerator showImage()
    {
        yield return new WaitForSeconds(2.0f);
        show = true;
    }

    void Update()
    {
        if (show)
        {
            if (Input.GetButton("Submit"))
            {
                panel.SetActive(false);
                show = false;
                StartCoroutine(lockMovement());
            }
        }
    }

    private IEnumerator lockMovement()
    {
        yield return new WaitForSeconds(0.2f);
        DialogueManager.GetInstance().pickObject = false;
        Destroy(transform.parent.gameObject);
    }
}
