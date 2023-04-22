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
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI explanation;
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
        characterName.text = cardData.characterName;
        explanation.text = cardData.explanation;
        leftDialogue = cardData.leftDialogue;
        rightDialogue = cardData.rightDialogue;

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
}
