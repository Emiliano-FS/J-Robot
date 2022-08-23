using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool inRange; //Checa si el jugador esta en rango

    [Header("JsonFile")]
    [SerializeField] private TextAsset jsonInk;// Referencia al JSON // Guion
    [SerializeField] private TextAsset jsonInkMad;// Referencia al JSON // Guion
    [SerializeField] private TextAsset jsonInkHappy;// Referencia al JSON // Guion

    //public bool mad = false;
    //public bool happy = false;
    public MapData map;
    public string emotion = "";
    public string name = "";

    private void Awake()
    {
        inRange = false;
        visualCue.SetActive(false);
    }

    void Update()
    {
        emotion = map.GetEmotion(name);
        if (Input.GetButton("Submit") && inRange && !DialogueManager.GetInstance().isPlaying && emotion == "MAD" && !SystemControls.GameIsPaused)
        {
            DialogueManager.GetInstance().EnterDialogue(jsonInkMad, this);
        }

        if (Input.GetButton("Submit") && inRange && !DialogueManager.GetInstance().isPlaying && emotion == "HAPPY" && !SystemControls.GameIsPaused)
        {
            DialogueManager.GetInstance().EnterDialogue(jsonInkHappy, this);
        }
        if (Input.GetButton("Submit") && inRange && !DialogueManager.GetInstance().isPlaying && emotion == "NORMAL" && !SystemControls.GameIsPaused)
        {
            DialogueManager.GetInstance().EnterDialogue(jsonInk, this);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inRange = true;
            visualCue.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inRange = false;
            visualCue.SetActive(false);
        }
    }
}
