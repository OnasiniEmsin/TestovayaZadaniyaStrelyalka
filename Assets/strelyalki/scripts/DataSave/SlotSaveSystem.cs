
using UnityEngine;
using System.IO;

public static class SlotSaveSystem
{
    static string path = Application.persistentDataPath + "/slots.json";

    public static void Save(SlotData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);

        Debug.Log("Data saved to: " + path);
    }

    public static SlotData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SlotData data = JsonUtility.FromJson<SlotData>(json);
            return data;
        }

        Debug.Log("Save file not found, creating new data.");
        return new SlotData();
    }
}
