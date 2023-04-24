using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image cardCharacterImage;
    public TextMeshProUGUI dialogue;
    public string leftDialogue;
    public string rightDialogue;
    
    public UnityEvent leftSwipeEvent;
    public UnityEvent rightSwipeEvent;

    private void Start()
    {
        
    }

    public void InitCard(CardData cardData)
    {
        cardCharacterImage = cardData.characterImage;
        GameManager.instance.uiManager.cardNameText.text = cardData.characterName;
        leftDialogue = cardData.leftDialogue;
        rightDialogue = cardData.rightDialogue;
        GameManager.instance.uiManager.explanationText.text = cardData.explanation;
        leftSwipeEvent = cardData.leftSwipeEvent;
        rightSwipeEvent = cardData.rightSwipeEvent;
    }

    public void MoveNextDay()
    {
        GameManager.instance.MoveNextDay();
    }
    
    public void ChangeHpValue(int value)
    {
        GameManager.instance.ChangeStatValue(PlayerStat.Hp, value);
    }
    
    public void ChangeHungerValue(int value)
    {
        GameManager.instance.ChangeStatValue(PlayerStat.Hunger, value);
    }

    public void ChangeThirstValue(int value)
    {
        GameManager.instance.ChangeStatValue(PlayerStat.Thirst, value);
    }
    
    public void ChangeMentalValue(int value)
    {
        GameManager.instance.ChangeStatValue(PlayerStat.Mental, value);
    }

    public void InstantiateCard()
    {
        GameManager.instance.instantiator.InstantiateCard();
    }

    public void InstantiateCard(CardData cardData)
    {
        GameManager.instance.instantiator.InstantiateCard(cardData);
    }

    public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
