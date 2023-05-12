using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiator : MonoBehaviour
{
    public Dictionary<string, CardData> cardDictionary = new Dictionary<string, CardData>(); // 모든 카드 정보를 가지고 있음
    public Dictionary<string, CardPack> cardPackDictionary = new Dictionary<string, CardPack>(); // 모든 카드팩 정보를 가지고 있음

    [Tooltip("사전 초기화용. 여기에 들어가있는 카드들만 나올 수 있음")]
    public List<CardData> cardDataList;
    [Tooltip("사전 초기화용. 들어가있는 카드팩들만 나올 수 있음")]
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
        if (spawnableCardList.Contains(cardData))
        {
            Debug.LogWarning($"카드가 중복됩니다. {cardData.cardName}");
        }
        else
        {
            spawnableCardList.Add(cardData);
        }
    }

    public void RemoveCard(CardData cardData)
    {
        if (!spawnableCardList.Remove(cardData))
        {
            Debug.LogWarning($"카드가 없습니다. {cardData.cardName}");
        }
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
    
    public void InstantiateRandomCard()
    {
        InstantiateCard(spawnableCardList[Random.Range(0, spawnableCardList.Count)]);
    }

    public void InstantiateRandomCardInCardPack(CardPack cardPack)
    {
        CardData randomCard = cardPack.cardPack[Random.Range(0, cardPack.cardPack.Count)];
        InstantiateCard(randomCard);
    }

    public void InstantiateCard(CardData cardData)
    {
        Card newCard = Instantiate(cardPrefab, cardSpawnPos);
        CardData initCard = GameManager.instance.IsGameOver() ? cardSpawnPos.GetComponentInChildren<Card>().gameOverCard : cardData;
        newCard.InitCard(initCard);
        newCard.StartCoroutine(newCard.Flip());
    }
}
