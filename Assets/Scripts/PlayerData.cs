using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public string playerName;
    public string json;

    public static PlayerData instance;
    public TMP_InputField inputField;

    private void Awake()
    {
        //Singleton 
        if(instance !=null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerName = inputField.text;
        json = JsonUtility.ToJson(this);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }    

    public void SaveData()
    {
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", json);
    }
    
    public PlayerData LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
            return loadedData;
        }
        return new PlayerData();
            
    }
}
