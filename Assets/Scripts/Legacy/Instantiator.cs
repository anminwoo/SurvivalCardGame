using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiator : MonoBehaviour
{
    public Dictionary<string, CardData> cardDictionary = new Dictionary<string, CardData>();
    [Tooltip("Spawnable cards in this game")]
    public List<CardData> cardList;

    public Transform cardSpawnPos;
    public Card cardPrefab;

    private void Awake()
    {
        
    }

    public void AddCard(CardData cardData)
    {
        if (cardDictionary.TryAdd(cardData.cardName, cardData))
        {
            cardList.Add(cardData);
        }
    }

    public void RemoveCard(CardData cardData)
    {
        cardDictionary.Remove(cardData.cardName);
        cardList?.Remove(cardData);
    }

    public void InitCardList()
    {
        cardDictionary.Clear();
        cardList = null;
    }

    public void InstantiateCard()
    {
        Card newCard = Instantiate(cardPrefab, cardSpawnPos);
        newCard.InitCard(cardList[Random.Range(0, cardList.Count)]);
    }

    public void InstantiateCard(CardData cardData)
    {
        Card newCard = Instantiate(cardPrefab, cardSpawnPos);
        newCard.InitCard(cardData);
    }
}
