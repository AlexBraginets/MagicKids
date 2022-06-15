using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PagesData : Data
{
    public StoredValue<List<PageData>> pages = new StoredValue<List<PageData>>(null);

    public PagesData(List<PageData> pages):this()
    {
        this.pages = new StoredValue<List<PageData>>(pages);
        
    }

    public PagesData()
    {
    }

    public override void InitOnChangedCallbackChain()
    {
        foreach (var page in pages.Value)
        {
            page.InitOnChangedCallbackChain();
            page.OnChanged += Changed;
        }
    }
}
