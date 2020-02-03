using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardComparator : MonoBehaviour
{
    public const int _first = 0;
    public const int _second = 1;

    private List<Card> _coupleCards;

    public bool IsCoupleCard => _coupleCards.Count >= 2;
    public int QuantityGuessedCouples { get; set; }

    private UnityAction _cardsMatched;
    public event UnityAction СardsMatched
    {
        add => _cardsMatched += value;
        remove => _cardsMatched -= value;
    }

    private UnityAction _cardsNotMatched;
    public event UnityAction СardsNotMatched
    {
        add => _cardsNotMatched += value;
        remove => _cardsNotMatched -= value;
    }

    private void Awake()
    {
        _coupleCards = new List<Card>();
    }

    public void AddCardToCompare(Card card)
    {
        if (IsCoupleCard)
            _coupleCards.Clear();

        _coupleCards.Add(card);
    }

    public void ToCompare()
    {
        if (_coupleCards[_first].NumberCard == _coupleCards[_second].NumberCard)
        {
            _coupleCards[_first].IsGuessed = true;
            _coupleCards[_second].IsGuessed = true;
            QuantityGuessedCouples++;
            _cardsMatched?.Invoke();
        }
        else
        {
            _cardsNotMatched?.Invoke();
        }
    }
}
