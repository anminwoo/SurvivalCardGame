using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;

    public Instantiator instantiator;

    public CardData startCard;
    
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
        instantiator.InstantiateCard(startCard);
    }

    public void StartGame()
    {
        day = 0;
        ChangeDay(day);

        foreach (PlayerStat stat in Enum.GetValues(typeof(PlayerStat)))
        {
            ChangeStatValue(stat, 100);
        }
        
        instantiator.InitSpawnableCardList();
        instantiator.InitCardDictionary();
        instantiator.InitCardPackDictionary();
        
        instantiator.AddCardPack(instantiator.cardPackDictionary["TestCardPack"]);
        
        instantiator.InstantiateRandomCard();
    }

    public void ChangeStatValue(PlayerStat stat, int value)
    {
        uiManager.ChangeStat(stat, value);
    }

    public void ChangeDay(int date)
    {
        uiManager.ChangeDayText(date);
    }

    public void MoveNextDay()
    {
        uiManager.ChangeDayText(++day);
    }

    public bool IsGameOver()
    {
        foreach (PlayerStat stat in Enum.GetValues(typeof(PlayerStat)))
        {
            if (uiManager.stateBars[(int)stat].Value == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

public enum PlayerStat
{
    Hp,
    Hunger,
    Thirst,
    Mental,
    
}