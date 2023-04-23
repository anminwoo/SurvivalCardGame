using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiator : MonoBehaviour
{
    public Dictionary<string, CardData> cardDictionary = new Dictionary<string, CardData>();
    public Dictionary<string, CardPack> cardPackDictionary = new Dictionary<string, CardPack>();

    public List<CardData> cardDataList;
    public List<CardPack> cardPacks;


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
        spawnableCardList?.Remove(cardData);
    }

    public void AddCardPack(CardPack cardPack)
    {
        foreach (var card in cardPack.cardPack)
        {
            AddCard(card);
        }
    }

    public void RemoveCardPack(CardPack cardPack)
    {
        foreach (var card in cardPack.cardPack)
        {
            RemoveCard(card);
        }
    }

    public void InitCardDictionary()
    {
        foreach (var cardData in cardDataList)
        {
            cardDictionary.TryAdd(cardData.cardName, cardData);
        }
    }

    public void InitCardPackDictionary()
    {
        foreach (var cardPack in cardPacks)
        {
            cardPackDictionary.TryAdd(cardPack.cardPackName, cardPack);
        }
    }

    public void InitSpawnableCardList()
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
