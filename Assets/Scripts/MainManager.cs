using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    //
    public Color TeamColor;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
