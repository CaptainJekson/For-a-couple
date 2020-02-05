using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardComparer))]
public class CardsTable : MonoBehaviour
{
    [SerializeField] private Card _template;
    [SerializeField] private int _countCards;
    [SerializeField] private CardComparer _cardComparator;

    private List<Card> _cards;

    public int QuantityCouples => _cards.Count / 2;

    private void Awake()
    {
        _cards = new List<Card>();

        AddCardsTheTable();
        _cards = Shuffle(_cards);
    }

    public void AddCoupleCards()
    {
        RemoveCardsTheTable();
        _cards.Clear();
        _countCards += 2;

        AddCardsTheTable();
        _cards = Shuffle(_cards);
    }

    private void AddCardsTheTable()
    {
        for (int i = 0; i < _countCards; i++)
        {
            CreateCards(_template, i);
        }
    }

    private void CreateCards(Card card, int index)
    {
        Card newCard = Instantiate(card, transform.position, Quaternion.identity);
        newCard.transform.SetParent(transform, false);
        _cards.Add(newCard);
        _cards[index].Init(_cardComparator);
    }

    private void RemoveCardsTheTable()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].RemoveCard();
        }
    }

    private void AddCoupleNumbers()
    {
        for (int i = 0; i < QuantityCouples; i++)
        {
            _cards[i].Number = i + 1;
            _cards[QuantityCouples + i].Number = i + 1;
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

        AddCoupleNumbers();
        return cards;
    }
}
