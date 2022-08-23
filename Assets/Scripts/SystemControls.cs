using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SystemControls : MonoBehaviour
{
    public Player player;
    public MapData mapdata;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject succ;

    public static bool GameIsPaused = false;

    void Start()
    {
        UnlockButton();
        succ.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

      if(Input.GetButtonDown("Cancel") && !DialogueManager.btnLock){
        if(GameIsPaused){
          Resume();
        }else{
          Pause();
        }
      }
    }

    public void Resume(){
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }

    void Pause(){
        SoundController.PlaySound("Item");
        succ.SetActive(false);
        pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void SaveButton(){
      SaveSystem.Save(player,mapdata);
        succ.SetActive(true);
        UnlockButton();
      Debug.Log("Se Guardo");
    }

    public void LoadButton(){
      Debug.Log("Se Cargo");
      SaveData data = SaveSystem.Load();

      Vector3 vel = new Vector3();
      vel.x = data.velocity[0];
      vel.y = data.velocity[1];
      player.GetComponent<Rigidbody2D>().velocity = vel;

      Vector3 position = new Vector3();
      position.x = data.position[0];
      position.y = data.position[1];
      position.z = data.position[2];

      player.transform.position = position;


      mapdata.happyList = new List<string>(data.happyArray);
      mapdata.madList = new List<string>(data.madArray);

      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }

    public void Menu(){
      Debug.Log("Me ire al menu");
      Time.timeScale = 1f;
      SceneManager.LoadScene(0);
    }

    private void UnlockButton()
    {
        string path = Application.persistentDataPath + "/Save.fun";
        if (!File.Exists(path))
        {
            pauseButton.SetActive(false);
        }
        else
        {
            pauseButton.SetActive(true);
        }
    }

}
