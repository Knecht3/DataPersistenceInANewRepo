using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StartMenuManager : MonoBehaviour
{
    public static StartMenuManager instance;
    public string userName;
    public string bestScoreUserName;
    public int bestScore;

    // Data persistence between scenes
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // String for UI text display
    public string DisplayBestScore()
    {
        return "Best Score : " + bestScoreUserName + " : " + bestScore;
    }

    // Data persistence between sessions
    [System.Serializable]
    class SaveData
    {
        public string bestScoreUserName;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScoreUserName = bestScoreUserName;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScoreUserName = data.bestScoreUserName;
            bestScore = data.bestScore;
        }
    }
}
