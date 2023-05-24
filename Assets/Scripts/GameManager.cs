using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager gm_instance;
    [SerializeField]
    private Data dt_gameData;
    public string str_plName;

    public Data SaveData
    {
        get { return dt_gameData; }
    }

    [RuntimeInitializeOnLoadMethod]
    public static void InitSesion()
    {
        GameObject go = new GameObject("GameManager");
        gm_instance = go.AddComponent<GameManager>();
        gm_instance.LoadSesionInfo();

        DontDestroyOnLoad(go);
    }

    private string GenerateFilePath()
    {
        return $"{Application.persistentDataPath}/saveData.gm";
    }

    private void LoadSesionInfo()
    {
        if (File.Exists(GenerateFilePath()))
        {
            string json = File.ReadAllText(GenerateFilePath());
            if (!string.IsNullOrEmpty(json))
                dt_gameData = JsonUtility.FromJson<Data>(json);
            else
                dt_gameData = new Data();
        }
        else
            dt_gameData = new Data();
    }
    private void SaveSesionInfo()
    {
        string data=JsonUtility.ToJson(dt_gameData);
        File.WriteAllText(GenerateFilePath(),data);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver(float currentScore)
    {
        if (dt_gameData.SetNewScore(currentScore))
        {
            dt_gameData.str_name = str_plName;
            SaveSesionInfo();
        }
            
    }
}
[System.Serializable]
public class Data
{
    public float f_highScore;
    public string str_name;
    public bool SetNewScore(float value)
    {
        bool isNewHigh = value > f_highScore;
        f_highScore = isNewHigh ? value : f_highScore;
        return isNewHigh;
    }
}
