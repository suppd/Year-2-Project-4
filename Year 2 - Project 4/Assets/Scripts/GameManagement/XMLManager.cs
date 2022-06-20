using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
public class XMLManager : MonoBehaviour
{
    public static XMLManager instance { get; private set; }
    private Leaderboard leaderboard;
    void Awake()
    {
        if (!Directory.Exists(Application.dataPath + "/HighScores/"))
        {
            Debug.Log("created new directory");
            Directory.CreateDirectory(Application.dataPath + "/HighScores/");
        }
        if (instance != null)
        {
            Debug.Log("[Singleton] Trying to create another instance of singleton");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

    }
    public void SaveScores(List<HighScoreEntry> scoresToSave)
    {
        if (File.Exists(Application.dataPath + "/HighScores/highscores.xml"))
        {
            leaderboard.list = LoadScores();
            foreach (HighScoreEntry entry in scoresToSave)
            {
                if (leaderboard.list.Contains(entry))
                {
                    Debug.Log(entry.playerName + entry.score);
                }
                leaderboard.list.Add(entry);
            }
            UpdateList();
            Debug.Log("Updated List");
        }
        else
        { 
            leaderboard.list = scoresToSave;
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.dataPath + "/HighScores/highscores.xml", FileMode.Create);
            serializer.Serialize(stream, leaderboard);
            stream.Close();
            Debug.Log("Created List");
        }
    }

    public void UpdateList()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
        FileStream stream = new FileStream(Application.dataPath + "/HighScores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }

    public List<HighScoreEntry> LoadScores()
    {
        if (File.Exists(Application.dataPath + "/HighScores/highscores.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.dataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            stream.Close();
        }
        return leaderboard.list;
    }
}
[System.Serializable]
public class Leaderboard
{
    public List<HighScoreEntry> list = new List<HighScoreEntry>();
}