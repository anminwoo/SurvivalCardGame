using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Card card;
    [SerializeField] private Image cardImage;

    private Vector3 initialPosition;
    private Color initialColor;

    private float distanceMoved;

    private bool swipeLeft;

    private void Start()
    {
       // cardImage = card.cardCharacterImage;
        card = GetComponent<Card>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        if (transform.localPosition.x - initialPosition.x > 0) // right
        {
            transform.localEulerAngles = new Vector3(0, 0,
                Mathf.LerpAngle(0, -30f, (initialPosition.x + transform.localPosition.x) / (Screen.width / 2)));

            card.dialogue.alignment = TextAlignmentOptions.Right;
            card.dialogue.text = card.rightDialogue;
        }
        else // left
        {
            transform.localEulerAngles = new Vector3(0, 0,
                Mathf.LerpAngle(0, 30f, (initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));

            card.dialogue.alignment = TextAlignmentOptions.Left;
            card.dialogue.text = card.leftDialogue;
        }

        // Debug.Log($"{initialPosition.x}, {transform.localPosition.x}, {Screen.width / 2}");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.localPosition;
        initialColor = cardImage.color;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        distanceMoved = Mathf.Abs(transform.localPosition.x - initialPosition.x);
        if (distanceMoved < 0.2f * Screen.width)
        {
            transform.localPosition = initialPosition;
            cardImage.color = initialColor;
            transform.localEulerAngles = Vector3.zero;
            card.dialogue.text = "";
        }
        else
        {
            if (transform.localPosition.x > initialPosition.x)
            {
                swipeLeft = false;
                 card.rightSwipeEvent?.Invoke();
            }
            else
            {
                swipeLeft = true;
                card.leftSwipeEvent?.Invoke();
            }
            
            StartCoroutine(MovedCard());
        }
    }

    IEnumerator MovedCard()
    {
        float time = 0f;
        
        while (cardImage.color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
            if (swipeLeft)
            {
                transform.localPosition =
                    new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x - Screen.width, 4 * time), 
                        transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition =
                    new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x + Screen.width, 4 * time), 
                        transform.localPosition.y, 0);
            }

            cardImage.color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4 * time));
            
            yield return null;
        }
        Destroy(gameObject);
    }
}
