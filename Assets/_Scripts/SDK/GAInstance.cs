using BayatGames.SaveGameFree;
using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAInstance : MonoBehaviour
{
    public static GAInstance Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            GameAnalytics.Initialize();
        }

        DontDestroyOnLoad(this);
    }

    public void LevelStartedEvent(int currentLevel, int totalLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, $"CurrentLevel {currentLevel.ToString("D3")}", $"TotalLevel {totalLevel}");
        GameAnalytics.NewDesignEvent($"LevelStart{currentLevel.ToString("D3")}");
    }

    public void LevelCompleteEvent(int currentLevel, float sessionCountSec)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"CurrentLevel {currentLevel.ToString("D3")}", $"{sessionCountSec} sec");
        GameAnalytics.NewDesignEvent($"LevelComplete{currentLevel.ToString("D3")}");

        ScoresCountEvent();
    }

    public void LevelFailEvent(int currentLevel, float sessionCountSec, string reason = "")
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"CurrentLevel {currentLevel.ToString("D3")}", reason, $"{sessionCountSec} sec");
        GameAnalytics.NewDesignEvent($"LevelFail{currentLevel.ToString("D3")}");
    }

    public void ScoresCountEvent()
    {
        int currentScores = SaveGame.Load(Keys.CurrentScores, 0);
        int totalScores = SaveGame.Load(Keys.TotalScores, 0);

        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Scores", currentScores, "Count", "CurrentScores");
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Scores", totalScores, "Count", "TotalScores");
    }
}
