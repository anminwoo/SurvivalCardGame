using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;

    public Instantiator instantiator;

    public int day;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("GameManger is not null");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        instantiator.InstantiateCard();
    }

    public void StartGame()
    {
        day = 0;
        instantiator.InitCardList();
    }

    public void ChangeStatValue(PlayerStat stat, int value)
    {
        uiManager.ChangeStat(stat, value);
    }

    public void MoveOnNextDay()
    {
        day++;
        uiManager.ChangeDayText(day);
    }
}

public enum PlayerStat
{
    Hp,
    Hunger,
    Mental,
    Heat,
}