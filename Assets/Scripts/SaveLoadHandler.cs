using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadHandler : MonoBehaviour
{

    [SerializeField]private CustomEntityData customEntityData = new CustomEntityData();
    public EntityDatabase database;
    public Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        customEntityData.entityDataList = database.entityDataList;
    }

    public void DefaultDataCheckRestore(){

        string savePath = Application.persistentDataPath + "/Database/EntityData.json";
        if(File.Exists(savePath)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.CreateNew);
            
            formatter.Serialize(stream, customEntityData);
            stream.Close();
            
            
            

        }else{
            
            Debug.Log("File見つかりませんでした！");
            

        }

    }

    public void SaveData(){


        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/Database/CustomEntityData.json";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        formatter.Serialize(stream, customEntityData);
        stream.Close();

        // customEntityData.entityDataList = database.entityDataList;
        // string dataToSave = JsonUtility.ToJson(database.entityDataList);
        // System.IO.File.WriteAllText(Application.persistentDataPath + "/CustomEntityData.json", dataToSave);

    }

    public CustomEntityData LoadData(){

        string loadPath = Application.persistentDataPath + "/Database/CustomEntityData.json";
        if(File.Exists(loadPath)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(loadPath, FileMode.Open);

            customEntityData = formatter.Deserialize(stream) as CustomEntityData;
            
            stream.Close();
            return customEntityData;
            

        }else{
            
            Debug.Log("File見つかりませんでした！");
            return null;

        }



    }



}

[System.Serializable]
public class CustomEntityData{

    public Entity[] entityDataList;

}


