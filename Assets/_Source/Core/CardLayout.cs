using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using _Source.Game;
using UnityEngine;

public class CardLayout : MonoBehaviour
{
    public int _layoutId;

    public Vector3 _offset;

    public int cardPosition = 0;

    public void Update()
    {
        List<CardInstance> cards = CardGame.GetInstance().GetComponent<CardGame>().GetCardsInLayout(_layoutId);

        foreach (var card in cards)
        {
            var cardView = CardGame.GetInstance()._cardDictionary[card];
            cardView.transform.SetParent(transform);
            cardView.transform.SetSiblingIndex(cardPosition);
            card.CardPosition = cardPosition++;
            cardView.transform.position = transform.position + card.CardPosition * _offset;
        }
        cardPosition = 0;
    }
}
