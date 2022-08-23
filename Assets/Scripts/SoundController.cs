using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //Lista de Audio Clips
    static AudioClip jump;
    static AudioClip bounce;
    static AudioClip item;
    static AudioClip landing;
    static AudioClip button;
    static AudioClip start;

    //Cosas para hacerlo funcionar
    static AudioSource audioSrc;
   
    // Start is called before the first frame update
    void Start()
    {

        jump = Resources.Load<AudioClip>("Jump");
        bounce = Resources.Load<AudioClip>("bounce");
        item = Resources.Load<AudioClip>("Item");
        landing = Resources.Load<AudioClip>("Landing");
        button = Resources.Load<AudioClip>("Button");
        start = Resources.Load<AudioClip>("PlayLoad");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "bounce":
                audioSrc.PlayOneShot(bounce);
                break;
            case "item":
                audioSrc.PlayOneShot(item);
                break;
            case "landing":
                audioSrc.PlayOneShot(landing);
                break;
            case "button":
                audioSrc.PlayOneShot(button);
                break;
            case "start":
                audioSrc.PlayOneShot(start);
                break;
        }

    }
}
