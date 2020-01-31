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
    }

    private void СardInitialization()
    {
        for (int i = 0; i < _startingCountCards; i++)
        {
            Card newCard = Instantiate(_card, transform.position, Quaternion.identity);
            newCard.transform.SetParent(transform, false);
            _cards.Add(newCard);
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
}
