using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryControl : MonoBehaviour
{
    public CompendiumController cc;
    public Image image;
    bool displaying;
    float timer;
    public Text textUI;

    //Lista de Sprites.
    public Sprite botBig;
    public Sprite botSheet;
    public Sprite botMenu;
    public Sprite botMenu2;
    public Sprite botConcept;

    //Guitar
    public Sprite guitarIdle;
    public Sprite Guitar1;
    public Sprite Guitar2;
    public Sprite Guitar3;
    public Sprite GuitarConcept;
    ////Oxxo
    public Sprite OxxoIdle;
    public Sprite Oxxo1;
    public Sprite Oxxo2;
    public Sprite Oxxo3;
    public Sprite OxxoConcept;
    ////Hacker
    public Sprite HackerIdle;
    public Sprite Hacker1;
    public Sprite Hacker2;
    public Sprite Hacker3;
    public Sprite HackerConcept;
    //Unused
    public Sprite Unused1;
    public Sprite Unused2;
    public Sprite Unused3;
    public Sprite UnusedOxxo;
    public Sprite UnusedHacker;


    private RectTransform picture;
    private Sprite[] tail;
    private int pos;
    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "";
        timer = 0;
        displaying = false;
        cc.ToggleMenu(true);
        image.enabled = false;
        picture = image.GetComponent<RectTransform>();
    }

    //True: Galeria, False: Main menu
    public void ToggleGallery(bool type)
    {
        if (type)
        {
            displaying = true;
            image.enabled = true;
            cc.ToggleMenu(false);
            textUI.text = "W,A,S,D: Mover     M=Zoom In     N=Zoom Out    B= Reiniciar     Spacebar= Siguiente    ESC= Regresar";
        }
        else
        {
            displaying = false;
            image.enabled = false;
            cc.ToggleMenu(true);
            textUI.text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (displaying){
            timer += Time.deltaTime;
            if (timer > 0.4f) {
                if (Input.GetKey("space"))
                {
                    resetPosition();
                    next();
                    timer = 0;
                }
                if (Input.GetKey(KeyCode.Escape))
                {
                    ToggleGallery(false);
                    timer = 0;
                }
            }
            if (Input.GetKey("a"))
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x - 0.65f, picture.anchoredPosition.y);
            }
            if (Input.GetKey("d"))
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x + 0.65f, picture.anchoredPosition.y);
            }
            if (Input.GetKey("s"))
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x , picture.anchoredPosition.y - 0.65f);
            }
            if (Input.GetKey("w"))
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x , picture.anchoredPosition.y + 0.65f);
            }
            if (Input.GetKey("m"))//Zoom IN
            {
                picture.sizeDelta = new Vector2(picture.sizeDelta.x+ 0.65f, picture.sizeDelta.y + 0.65f);
            }
            if (Input.GetKey("n"))//Zoom Out
            {
                picture.sizeDelta = new Vector2(picture.sizeDelta.x- 0.65f, picture.sizeDelta.y - 0.65f);
            }
            if (Input.GetKey("b"))
            {
                resetPosition();
            }
        }
    }

    public void activate(int art)
    {
        resetPosition();
        pos = 0;
        ToggleGallery(true);
        switch (art)
        {
            case 1:
                image.sprite = guitarIdle;
                tail= new Sprite[] {Guitar1,Guitar2 , Guitar3, GuitarConcept, guitarIdle};
                break;
            case 2:
                image.sprite = OxxoIdle;
                tail = new Sprite[] { Oxxo1, Oxxo2, Oxxo3, OxxoConcept, OxxoIdle };
                break;
            case 3:
                image.sprite = HackerIdle;
                tail = new Sprite[] { Hacker1, Hacker2, Hacker3, HackerConcept, HackerIdle};
                break;
            case 4:
                image.sprite = Unused1;
                tail = new Sprite[] { Unused2, Unused3, UnusedOxxo ,UnusedHacker, Unused1 };
                break;
            default:
                image.sprite = botBig;
                tail = new Sprite[] { botSheet, botMenu, botMenu2, botConcept, botBig };
                break;
        }
    }

    public void next()
    {
        if (tail.Length-1 < pos) { pos = 0; }
        image.sprite = tail[pos];
        pos += 1;
    }

    public void resetPosition()
    {
        picture.anchoredPosition = new Vector2(0,0);
        picture.sizeDelta = new Vector2(600,1000);
    }

}
