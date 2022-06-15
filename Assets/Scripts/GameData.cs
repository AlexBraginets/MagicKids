using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Data
{
    public StoredValue<PagesData> pagesData;
    public StoredValue<ScoreData> scoreData;

    public GameData(PagesData pagesData, ScoreData scoreData)
    {
        this.pagesData = new StoredValue<PagesData>(pagesData);
        this.scoreData = new StoredValue<ScoreData>(scoreData);
    }

    public GameData()
    {
    }

    public override void InitOnChangedCallbackChain()
    {
        pagesData.Value.InitOnChangedCallbackChain();
        scoreData.Value.InitOnChangedCallbackChain();
        this.pagesData.Value.OnChanged += Changed;
        this.scoreData.Value.OnChanged += Changed;
    }
}
