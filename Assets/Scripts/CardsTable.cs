using System.Collections.Generic;
using UnityEngine;

public class CardsTable : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private int _startingCountCards;

    private List<Card> _cards;

    public int QuantityCouples => _cards.Count / 2;
    private int PenultimateCard => _cards.Count - 2;
    private int LastCard => _cards.Count - 1;

    private void Awake()
    {
        _cards = new List<Card>();

        AddCardList();
        AddCardTheTable();
        AddCoupleNumbers();
        ClearTheTable();
        _cards = Shuffle(_cards);
        AddCardTheTable();
    }

    public void AddCoupleCards()
    {
        ClearTheTable();

        _cards.Add(_card);
        _cards.Add(_card);

        AddCardTheTable();

        _cards[PenultimateCard].NumberCard = QuantityCouples;
        _cards[LastCard].NumberCard = QuantityCouples;

        ClearTheTable();
        _cards = Shuffle(_cards);
        AddCardTheTable();
    }

    private void AddCardList()
    {
        for (int i = 0; i < _startingCountCards; i++)
        {
            _cards.Add(_card);
        }
    }

    private void AddCardTheTable()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            Card newCard = Instantiate(_cards[i], transform.position, Quaternion.identity);
            newCard.transform.SetParent(transform, false);
            _cards[i] = newCard;
            _cards[i].Init();
        }
    }

    private void ClearTheTable()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].RemoveCard();
        }
    }

    private void AddCoupleNumbers()
    {
        for (int i = 0; i < _cards.Count / 2; i++)
        {
            _cards[i].NumberCard = i + 1;
            _cards[_cards.Count / 2 + i].NumberCard = i + 1;
        }
    }

    private List<Card> Shuffle(List<Card> cards)
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }

        return cards;
    }
}
