using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper dk;
    public string playerName = "Name Empty";
    private string topPlayerName = "Name Empty";
    private int highScore = -1;
    private void Awake()
    {
        if (dk != null)
        {
            Destroy(gameObject);
            return;
        }
        dk = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string topName;
        public int topScore;
    }

    public string LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayerName = data.topName;
            highScore = data.topScore;
        }
        return topPlayerName + " " + highScore.ToString();
    }

    public void SaveHighScore(int score)
    {
        LoadHighScore();
        if (highScore < score)
        {
            SaveData data = new SaveData();
            data.topScore = score;
            data.topName = playerName;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    }
}
