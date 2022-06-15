using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : Data
{
    public StoredValue<int> score;

    public ScoreData()
    {
        
    }

    public ScoreData(int score)
    {
        this.score = new StoredValue<int>(score);
    }
    public override void InitOnChangedCallbackChain()
    {
        score.callback += _ => Changed();
    }
}
