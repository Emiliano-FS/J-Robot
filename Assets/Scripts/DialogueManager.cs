using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    public static bool btnLock = false;
    public GameObject panel;
    public Image portrait;
    public TextMeshProUGUI dialogo;
    public TextMeshProUGUI speaker_name;

    [SerializeField] public GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private float timer;//Timer para que no se mashee en el dialogo.
    public bool isPlaying;//Si se esta reproduciendo un dialogo.
    public bool pickObject;//Para los objetos. Mas info hable con Natu.

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string EMOTION_TAG = "emotion";

    private string final_emotion;

    public GameObject Opcion1;

    public DialogueTrigger currentNPC;
    public MapData map;


    void Awake()
    {
        if(!instance==null)
        {
            Debug.LogWarning("WTF no debe haber mas de 1");
        }
        instance = this;
    }

    void Start()
    {
        timer = 0f;
        isPlaying = false;
        pickObject = false;
        panel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
        //Estamos poniendo cual es la primera opcion para el menu
        EventSystem.current.SetSelectedGameObject(null);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (!isPlaying)
        {
            return;//Tronamos si no hay dialago.
        }
        if (Input.GetButtonDown("Submit") && currentStory.currentChoices.Count == 0 && timer > 1f)//Si paso un segundo
        {
	    timer = 0f;
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset inkJson, DialogueTrigger NPC)
    {
        btnLock = true;
        currentNPC = NPC;
        isPlaying = true;
        currentStory = new Story(inkJson.text);
        panel.SetActive(true);
        speaker_name.text = "???";
        portrait.sprite = Resources.Load<Sprite>("Portraits/default");
        //ContinueStory();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Opcion1);

    }

    private IEnumerator ExitDialogue()
    {
        Debug.Log("Se a alcanzado el final del Script");
        yield return new WaitForSeconds(0.2f);
        btnLock = false;
        isPlaying = false;
        panel.SetActive(false);
        dialogo.text = "";

    }

    private void ContinueStory()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Opcion1);
        if (currentStory.canContinue)
        {
            dialogo.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine( ExitDialogue());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length > 2)
            {
                Debug.LogError("Tama�o del Tag es mayor que 2, revisa el tag: "+ tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    speaker_name.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portrait.sprite = Resources.Load<Sprite>("Portraits/" + tagValue);
                    break;
                case EMOTION_TAG:
                    final_emotion=tagValue;
                    FinalChoice(final_emotion);
                    break;

            }
        }
    }

    private void DisplayChoices()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Opcion1);
        List<Choice> currentChoices = currentStory.currentChoices;
        Debug.Log("Hay " + currentChoices.Count + " decisiones posibles");
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Error, esto no deberia pasar. Mas Choices de las que la UI soporta: "+ currentChoices.Count);
        }
        int i = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[i].gameObject.SetActive(true);
            choicesText[i].text = choice.text;
            i++;
        }
        for(int j=i; j < choices.Length; j++)
        {
            Debug.Log("Done");
            choices[j].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    public void FinalChoice(string final){
      switch(final){
        case "mad":
          map.madList.Add(currentNPC.name);
          break;
        case "happy":
          map.happyList.Add(currentNPC.name);
          break;
      }
    }

}
