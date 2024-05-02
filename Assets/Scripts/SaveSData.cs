using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveSData : MonoBehaviour
{
    //the place on the user pc
    private static string filePath = Application.persistentDataPath + "/score.json";
    //2 function save and load
    public static void Save(Score scoreData)
    {
        //put the info in a file
        string data = JsonUtility.ToJson(scoreData);
      
        File.WriteAllText(filePath,data);

        Debug.Log(filePath);
    }

    public static Score Load()
    {
        //the file doesnt exsist so we stop here
        if (!File.Exists(filePath))
        {
            return new Score();
        }
        
        //put the information
        string data = File.ReadAllText(filePath);
        Score scoreData = JsonUtility.FromJson<Score>(data);
        return scoreData;
    }
}
