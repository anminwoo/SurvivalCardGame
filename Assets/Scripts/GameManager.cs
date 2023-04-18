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

    private float[] status;

    public float maxHealth;
    public float health;

    public float maxHunger;
    public float hunger;

    public float maxHeat;
    public float heat;

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

    public void ChangeStateValue(State type, int value)
    {
        status[(int)type] += value;

        if (status[(int)type] == 0)
        {
            Debug.Log($"{type} is 0. you die.");
        }
    }

    public void MoveOnNextDay()
    {
        day++;
        Debug.Log(day);
        uiManager.ChangeDayText(day);
    }
}

public enum State
{
    Hp,
    Hunger,
    Heat,
}