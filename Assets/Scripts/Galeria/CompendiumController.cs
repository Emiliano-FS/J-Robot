using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompendiumController : MonoBehaviour
{
    public GameObject selectmenu;
    public GalleryControl gc;
    public bool active;
    float timer;

    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (active && timer > 0.3f)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    //True= Menu, False Galeria
    public void ToggleMenu(bool toggle)
    {
        if (toggle){
            active = true;
            selectmenu.SetActive(true);
            timer = 0;
        }
        else {
            active = false;
            selectmenu.SetActive(false);
        }
    }

    public void BotArt()
    {
        ToggleMenu(false);
        gc.activate(0);
    }

    public void GuitarArt()
    {
        ToggleMenu(false);
        gc.activate(1);
    }

    public void HackerArt()
    {
        ToggleMenu(false);
        gc.activate(3);
    }

    public void OxxoArt()
    {
        ToggleMenu(false);
        gc.activate(2);
    }

    public void UnusedArt()
    {
        ToggleMenu(false);
        gc.activate(4);
    }


}
