using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{

  public static void Save (Player player, MapData map){

    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/Save.fun";
    FileStream stream = new FileStream(path, FileMode.Create);

    SaveData data = new SaveData(player,map);

    formatter.Serialize(stream, data);

    stream.Close();
  }

  public static SaveData Load (){
    string path = Application.persistentDataPath + "/Save.fun";
    if(File.Exists(path)){
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      SaveData data = formatter.Deserialize(stream) as SaveData;
      stream.Close();

      return data;

    }else{
      Debug.LogError("No se encontro el Path "+ path);
      return null;
    }
  }

}
