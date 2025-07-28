using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Singleton instance
    // ENCAPSULATION
    public static DataManager Instance { get; private set; }
    public UserData userData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // Init data
        userData = new UserData("", 0);
    }
}

[System.Serializable]
public class UserData
{
    public string Name;
    public int Score;

    public UserData()
    {
        Name = "";
        Score = 0;
    }

    public UserData(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
