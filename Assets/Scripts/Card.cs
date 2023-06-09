using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject cardBack;
    [SerializeField] private Image image;
    
    
    public Sprite cardCharacterImage;
    public TextMeshProUGUI dialogue;
    public string leftDialogue;
    public string rightDialogue;

    public CardData gameOverCard;

    public UnityEvent leftSwipeEvent;
    public UnityEvent rightSwipeEvent;

    private void Start()
    {

    }

    public IEnumerator Flip()
    {
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(Vector3.up);

            if (i == 90)
            {
                cardBack.SetActive(false);
            }
            
            yield return null;
        }
    }

    public void InitCard(CardData cardData)
    {
        cardCharacterImage = cardData.characterImage;
        image.sprite = cardCharacterImage;
        
        GameManager.instance.uiManager.cardNameText.text = cardData.characterName;
        leftDialogue = cardData.leftDialogue;
        rightDialogue = cardData.rightDialogue;
        GameManager.instance.uiManager.explanationText.text = cardData.explanation;
        gameOverCard = cardData.gameOverCard;
        leftSwipeEvent = cardData.leftSwipeEvent;
        leftSwipeEvent.AddListener(DeleteCard);
        rightSwipeEvent = cardData.rightSwipeEvent;
        rightSwipeEvent.AddListener(DeleteCard);
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
        GameManager.instance.instantiator.InstantiateRandomCard();
    }

    public void InstantiateRandomCardInCardPack(CardPack cardPack)
    {
        GameManager.instance.instantiator.InstantiateRandomCardInCardPack(cardPack);
    }

    public void InstantiateCard(CardData cardData)
    {
        GameManager.instance.instantiator.InstantiateCard(cardData);
    }

    public void AddCard(CardData cardData)
    {
        GameManager.instance.instantiator.AddCard(cardData);
    }

    public void RemoveCard(CardData cardData)
    {
        GameManager.instance.instantiator.RemoveCard(cardData);
    }

    public void AddCardPack(CardPack cardPack)
    {
        GameManager.instance.instantiator.AddCardPack(cardPack);
    }

    public void RemoveCardPack(CardPack cardPack)
    {
        GameManager.instance.instantiator.RemoveCardPack(cardPack);
    }

    private void DeleteCard()
    {
        Destroy(gameObject);
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
