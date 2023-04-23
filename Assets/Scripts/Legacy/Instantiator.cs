using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiator : MonoBehaviour
{
    public Dictionary<string, CardData> cardDictionary = new Dictionary<string, CardData>();
    public Dictionary<string, CardPack> cardPackDictionary = new Dictionary<string, CardPack>();
    [Tooltip("Spawnable cards in this game")]
    public List<CardData> spawnableCardList;

    public Transform cardSpawnPos;
    public Card cardPrefab;

    private void Awake()
    {
        
    }

    public void AddCard(CardData cardData)
    {
        if (cardDictionary.TryAdd(cardData.cardName, cardData))
        {
            spawnableCardList.Add(cardData);
        }
    }

    public void RemoveCard(CardData cardData)
    {
        cardDictionary.Remove(cardData.cardName);
        spawnableCardList?.Remove(cardData);
    }

    public void InitCardList()
    {
        spawnableCardList.Clear();
    }

    public void InstantiateCard()
    {
        Card newCard = Instantiate(cardPrefab, cardSpawnPos);
        newCard.InitCard(spawnableCardList[Random.Range(0, spawnableCardList.Count)]);
    }

    public void InstantiateCard(CardData cardData)
    {
        Card newCard = Instantiate(cardPrefab, cardSpawnPos);
        newCard.InitCard(cardData);
    }
}
