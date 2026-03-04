using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventHub
{
    public static event Action GameStartEvent;
    public static event Action GameEndEvent;
    public static event Action GamePauseEvent;
    public static event Action GameResumedEvent;
    public static event Action BadKidHitEvent;
    public static event Action GoodKidHitEvent;
    public static event Action OnAllKidGoodEvent;
    public static event Action<int> ScoreChangedEvent;

    #region Invoke
    public static void GameStartAct()
    {
        GameStartEvent?.Invoke();
    }

    public static void GameEndEventAct()
    {
        GameEndEvent?.Invoke();
    }

    public static void GamePauseAct()
    {
        GamePauseEvent?.Invoke();
    }

    public static void GameResumeAct()
    {
        GameResumedEvent?.Invoke();
    }

    public static void BadKidHitAct()
    {
        BadKidHitEvent?.Invoke();
    }

    public static void GoodKidHitAct()
    {
        GoodKidHitEvent?.Invoke();
    }

    public static void OnAllKidGoodAct()
    {
        OnAllKidGoodEvent?.Invoke();
    }

    public static void ScoreChangedAct(int score)
    {
        ScoreChangedEvent?.Invoke(score);
    }
    #endregion
}
