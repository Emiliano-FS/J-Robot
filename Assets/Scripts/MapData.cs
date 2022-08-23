using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour{

    public List<string> happyList;
    public List<string> madList;

    public string GetEmotion(string name){
      if(happyList.Contains(name)){
        return "HAPPY";
      }else if(madList.Contains(name)){
        return "MAD";
      }else{
        return "NORMAL";
      }
    }
}
