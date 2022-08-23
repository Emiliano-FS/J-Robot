using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Image image;
    public Animator anim;
    float timer = 0;
    int current = 0;

    public Sprite comic0;
    public Sprite comic1;
    public Sprite comic2;
    public Sprite comic3;
    public Sprite comic4;
    public Sprite comic5;
    public Sprite comic6;
    public Sprite comic7;
    public Sprite comic8;
    public Sprite comic9;
    public Sprite comic10;
    public Sprite comic11;

    void Start()
    {
        anim.SetBool("Intro", true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            if (Input.GetButton("Submit"))
            {
                order(current);
                current=+ 1;
            }
            if (Input.GetButtonDown("Cancel"))
            {
                order(100);
                current = 100;
            }
        }
    }

    private void order(int i)
    {
        switch (i)
        {
            case 0:
                image.sprite= comic0;
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
            case 8:
                image.sprite = comic8;
                break;
            case 9:
                image.sprite = comic9;
                break;
            case 10:
                image.sprite = comic10;
                break;
            case 11:
                image.sprite = comic11;
                break;
        }
    }
}
