using UnityEngine;
using System.IO;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/Money.json";

    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);

        Debug.Log("Data saved to: " + path);
    }

    public static PlayerData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }

        Debug.Log("Save file not found, creating new data.");
        return new PlayerData();
    }
}