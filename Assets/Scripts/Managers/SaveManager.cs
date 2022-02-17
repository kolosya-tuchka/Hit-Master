using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    static readonly string FilePath = Application.persistentDataPath;

    public static void SaveRecordTime(float record)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(FilePath + "/record.time", FileMode.Create);
        bf.Serialize(fs, record);
        fs.Close();
    }

    public static float LoadRecordTime()
    {
        if (!File.Exists(FilePath + "/record.time")) return float.MaxValue;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(FilePath + "/record.time", FileMode.Open);
        float record = (float)bf.Deserialize(fs);
        fs.Close();
        return record;
    }
}
