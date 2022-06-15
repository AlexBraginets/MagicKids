using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataCenter
{
    public static StoredValue<GameData> data;
    static DataCenter()
    {
        var pagesData = GetPagesData();
        ScoreData scoreData = new ScoreData(0);
        GameData gameData = new GameData(pagesData, scoreData);
        data = new StoredValue<GameData>(gameData);
    }

    private static PagesData GetPagesData()
    {
        PagesData pagesData = new PagesData(new List<PageData>(new []
        {
            new PageData("Dinos", 1, 25),
            new PageData("Numbers", 1, 16),
            new PageData("Solar System", 1, 5),
            new PageData("Alphabet", 1, 25),
            new PageData("Alice", 1, 19)

        }));
        return pagesData;
    }
}
