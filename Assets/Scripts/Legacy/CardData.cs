using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardName", menuName = "CardData")]
public class CardData : ScriptableObject
{
    [Tooltip("카드 선택지 이름입니다. 카드를 찾을 때 사용하므로 중복이 불가합니다.")]
    public string cardName;
    
    [TextArea]
    public string explanation;
    public Sprite characterImage;
    [Tooltip("카드 이미지의 이름입니다. 중복이 가능합니다.")]
    public string characterName;
    [TextArea]
    public string leftDialogue;
    [TextArea]
    public string rightDialogue;

    [Space, CanBeNull, Tooltip("게임 오버 시 나오게 될 카드입니다.")]
    public CardData gameOverCard;

    public UnityEvent leftSwipeEvent;
    public UnityEvent rightSwipeEvent;
}
