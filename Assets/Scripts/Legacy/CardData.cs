using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardName", menuName = "CardData")]
public class CardData : ScriptableObject
{
    public string cardName;
    
    
    public string explanation;
    public Image characterImage;
    public string characterName;
    public string leftDialogue;
    public string rightDialogue;

    public UnityEvent leftSwipeEvent;
    public UnityEvent rightSwipeEvent;
}
