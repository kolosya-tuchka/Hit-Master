using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    [HideInInspector] public static SaveManager Instance;
    private string filePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        filePath = Application.persistentDataPath;
    }

    public void SaveRecord(float record)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath + "/record.time", FileMode.Create);
        bf.Serialize(fs, record);
        fs.Close();
    }

    public float LoadRecord()
    {
        if (!File.Exists(filePath + "/record.time")) return float.MaxValue;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath + "/record.time", FileMode.Open);
        float record = (float)bf.Deserialize(fs);
        fs.Close();
        return record;
    }
}
