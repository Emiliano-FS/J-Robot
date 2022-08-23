using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData{
  public float[] position;
  public float[] velocity;
  public string[] madArray;
  public string[] happyArray;

  public SaveData (Player player, MapData map){
    velocity = new float[2];
    velocity[0] = player.GetComponent<Rigidbody2D>().velocity.x;
    velocity[1] = player.GetComponent<Rigidbody2D>().velocity.y;
    position = new float[3];
    position[0] = player.transform.position.x;
    position[1] = player.transform.position.y;
    position[2] = player.transform.position.z;
    madArray = map.madList.ToArray();
    happyArray = map.happyList.ToArray();
  }
}
