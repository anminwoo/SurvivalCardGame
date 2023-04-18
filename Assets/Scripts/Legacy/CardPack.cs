using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPackName", menuName = "CardPack")]
public class CardPack : ScriptableObject
{
    public List<CardData> cardPack;
}
