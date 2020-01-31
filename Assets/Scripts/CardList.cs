using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField] Card _card;
    [SerializeField] int _startingCountCards;

    private List<Card> _cards;

    private void Awake()
    {
        if (EvenCheckNumvers(_startingCountCards) == false)
            _startingCountCards++;

        _cards = new List<Card>();

        СardInitialization();
        AddCouple();
        _cards = Shuffle(_cards);

        foreach (var item in _cards)
        {
            AddCardTheTable(item);
        }
    }

    private void СardInitialization()
    {
        for (int i = 0; i < _startingCountCards; i++)
        {
            Card newCard = AddCardTheTable(_card);
            _cards.Add(newCard);
            newCard.RemoveCard();
            newCard.OnEnableComponets();
        }
    }

    private void AddCouple()
    {
        for (int i = 0; i < _cards.Count / 2; i++)
        {
            _cards[i].SetNumberCard(i + 1);
            _cards[_cards.Count / 2 + i].SetNumberCard(i + 1);
        }
    }

    private bool EvenCheckNumvers(int numbers)
    {
        return numbers % 2 == 0;
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

    private Card AddCardTheTable(Card card)
    {
        Card newCard = Instantiate(card, transform.position, Quaternion.identity);
        newCard.transform.SetParent(transform, false);

        return newCard;
    }

    private void AddСouple()
    {
    }
}
