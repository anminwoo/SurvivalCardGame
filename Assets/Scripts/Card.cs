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

    public void MoveOnNextDay()
    {
        GameManager.instance.MoveOnNextDay();
    }

    public void ChangeStateValue(State type, int value)
    {
        GameManager.instance.ChangeStateValue(type, value);
    }
}
