using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardComparator : MonoBehaviour
{
    private List<Card> _coupleCards;
    private CardList _cardList;

    private GameState gameState;

    public bool IsCoupleCard => _coupleCards.Count >= 2;
    public int QuantityGuessedCouples { get; set; }

    public event UnityAction СardsMatched;
    public event UnityAction СardsNotMatched;

    private void Awake()
    {
        _coupleCards = new List<Card>();
        _cardList = GetComponent<CardList>();

        gameState = FindObjectOfType<GameState>();
    }

    public void AddCardToCompare(Card card)
    {
        if (IsCoupleCard)
            _coupleCards.Clear();

        _coupleCards.Add(card);
    }

    public void ToCompare()
    {
        if (_coupleCards[0].NumberCard == _coupleCards[1].NumberCard)
        {
            _coupleCards[0].IsGuessed = true;
            _coupleCards[1].IsGuessed = true;
            QuantityGuessedCouples++;
            СardsMatched?.Invoke();
        }
        else
        {
            СardsNotMatched?.Invoke();
        }
    }
}
