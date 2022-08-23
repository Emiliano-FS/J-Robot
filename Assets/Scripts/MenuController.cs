using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Animator anim;//Animator Fondo

    public Image image;
    public Animator intro;// Animator Intro
    public GameObject introPanel;
    public GameObject introTextInstruc;
    public GameObject gameButton;
    public GameObject gallery;
    public GameObject exitBtn;

    float timer = 0;
    bool playingIntro = false;
    int current = 1;

    public Sprite comic0;
    public Sprite comic1;
    public Sprite comic2;
    public Sprite comic3;
    public Sprite comic4;
    public Sprite comic5;
    public Sprite comic6;
    public Sprite comic7;
    public Sprite comic8;

    //Nos lleva a la escena principal
    void Start()
    {
        introTextInstruc.SetActive(false);
    }

    public void buttonNewGame()
    {
        SoundController.PlaySound("start");
        anim.SetBool("NewGame", true);
        playingIntro = true;
        introPanel.SetActive(true);
        intro.SetBool("Intro", true);
        gameButton.SetActive(false);
        gallery.SetActive(false);
        exitBtn.SetActive(false);
        StartCoroutine(IntroComic());
    }

    private IEnumerator IntroComic()
    {
        yield return new WaitForSeconds(2.5f);
        introTextInstruc.SetActive(true);
    }

    //Nos lleva a la escena principal
    public void buttonLoad()
    {
        SoundController.PlaySound("start");
        anim.SetBool("Load", true);

    }

    //Nos lleva al Compedio
    public void buttonCompendium()
    {
        SoundController.PlaySound("button");
        SceneManager.LoadScene(2);
    }

    //Adivina que hace.
    public void buttonQuit()
    {
        Application.Quit();
    }

    private IEnumerator Sync()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (playingIntro)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                if (Input.GetButton("Submit"))
                {
                    order(current);
                    current += 1;
                    timer = 0;
                }
                if (Input.GetButtonDown("Cancel"))
                {
                    order(100);
                    timer = 0;
                    current = 100;
                }
            }

        }
    }

    private void order(int i)
    {
        switch (i)
        {
            case 0:
                image.sprite = comic0;
                break;
            case 1:
                image.sprite = comic1;
                break;
            case 2:
                image.sprite = comic2;
                break;
            case 3:
                image.sprite = comic3;
                break;
            case 4:
                image.sprite = comic4;
                break;
            case 5:
                image.sprite = comic5;
                break;
            case 6:
                image.sprite = comic6;
                break;
            case 7:
                image.sprite = comic7;
                break;
            default:
                SoundController.PlaySound("Button");
                //intro.SetBool("IntroFinish", true);
                image.sprite = comic8;
                introTextInstruc.SetActive(false);
                StartCoroutine(Sync());
                break;
        }
    }
}
