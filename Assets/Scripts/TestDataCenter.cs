using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestDataCenter : MonoBehaviour
{
    [SerializeField] private PagesContainer pagesContainer;
    [SerializeField] private ScoreDisplay scoreDisplay;

    [ContextMenu("Clear player prefs")]
    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    private void Start()
    {
        LogDataCenterInfo();
        if (PlayerPrefs.HasKey("Data"))
        {
            string data = PlayerPrefs.GetString("Data");
            DataCenter.data = JsonConvert.DeserializeObject<StoredValue<GameData>>(data);
        }
        pagesContainer.Inject(DataCenter.data.Value.pagesData.Value);
        scoreDisplay.AssignScoreData(DataCenter.data.Value.scoreData.Value);

        DataCenter.data.Value.InitOnChangedCallbackChain();
        DataCenter.data.Value.OnChanged += SaveData;


    }

    public void ClearProgressAnimated()
    {
        // restore score
        DataCenter.data.Value.scoreData.Value.score.Value = 0;
        // restore pages progress
        foreach (var page in DataCenter.data.Value.pagesData.Value.pages.Value)
        {
            page.CurrentLevel.Value = 1;
        }
    }

    private void SaveData()
    {
        Debug.Log("SaveData");
        PlayerPrefs.SetString("Data", JsonConvert.SerializeObject(DataCenter.data));
    }

    [ContextMenu("Log DataCenter Info")]
    private void LogDataCenterInfo()
    {
        LogCurrentLevel();
    }

    [ContextMenu("Go to next level")]
    private void GoToNextLevel()
    {
        DataCenter.data.Value.pagesData.Value.pages.Value[0].CurrentLevel.Value++;
        LogCurrentLevel();
    }

    private void LogCurrentLevel()
    {
        var data = DataCenter.data;
        int currentLevel = data.Value.pagesData.Value.pages.Value[0].CurrentLevel.Value;
        Debug.Log("Current level: " + currentLevel);
    }
}