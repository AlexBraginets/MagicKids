using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageView : MonoBehaviour
{
    [SerializeField] private TitleDisplay titleDisplay;
    [SerializeField] private TMP_Text currentLevelLabel;
    [SerializeField] private TMP_Text maxLevelLabel;
    [SerializeField] private Button playButton;

    private PageData _page;
    public void AssignPage(PageData page)
    {
        if (_page != null)
        {
            RemoveCallbacks(_page);
        }
        _page = page;
        ManualUpdate(page);
       AssignCallbacks(page);
       
       playButton.onClick.AddListener(() =>
       {
           if (_page.CurrentLevel.Value < _page.MaxLevel.Value)
           {
               _page.CurrentLevel.Value++;
               DataCenter.data.Value.scoreData.Value.score.Value += 5;
           }
       });
    }

    private void OnDestroy()
    {
        if (_page != null)
        {
            RemoveCallbacks(_page);
        }
    }

    private void ManualUpdate(PageData page)
    {
        currentLevelLabel.text = page.CurrentLevel.Value.ToString();
        maxLevelLabel.text = page.MaxLevel.Value.ToString();
    }
    private void AssignCallbacks(PageData page)
    {
        page.CurrentLevel.callback += UpdateCurrentLevel;
        page.MaxLevel.callback += UpdateMaxLevel;
        titleDisplay.AssignPage(page);
    }

    private void RemoveCallbacks(PageData page)
    {
        page.CurrentLevel.callback -= UpdateCurrentLevel;
        page.MaxLevel.callback -= UpdateMaxLevel;
    }
    private void UpdateCurrentLevel(int currentLevel) => currentLevelLabel.text = currentLevel.ToString();
    private void UpdateMaxLevel(int maxLevel) => maxLevelLabel.text = maxLevel.ToString();
}
