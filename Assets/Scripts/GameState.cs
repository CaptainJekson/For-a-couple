using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private CardComparator _cardComparator;
    [SerializeField] private CardList _cardList;

    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _attempts;
    [SerializeField] private TextMeshProUGUI _points;

    private void Update()
    {
        if(_cardComparator.QuantityGuessedCouples == _cardList.QuantityCouples)
        {
            _cardComparator.QuantityGuessedCouples = 0;
        }
    }
}
