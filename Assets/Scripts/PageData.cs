using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PageData : Data
{
    public StoredValue<string> Name = new StoredValue<string>("");
    public StoredValue<int> CurrentLevel = new StoredValue<int>(0);
    public StoredValue<int> MaxLevel = new StoredValue<int>(0);

    public PageData()
    {
        
    }

    public PageData(string name, int currentLevel, int maxLevel)
    {
        Name = new StoredValue<string>(name);
        CurrentLevel = new StoredValue<int>(currentLevel);
        MaxLevel = new StoredValue<int>(maxLevel);
    }

    public override void InitOnChangedCallbackChain()
    {
        Name.callback += _ => Changed();
        CurrentLevel.callback += _ => Changed();
        MaxLevel.callback += _ => Changed();
    }
}
