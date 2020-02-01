using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private int _startAttempts;
    [SerializeField] private CardComparator _cardComparator;
    [SerializeField] private CardList _cardList;
    [SerializeField] private GameObject _gameOverPanel;

    public int Level { get; private set; }
    public int Points { get; private set; }
    public int Attempts { get; private set; }

    private void Awake()
    {
        Attempts = _startAttempts;
        Level = 1;
    }

    private void OnEnable()
    {
        _cardComparator.СardsNotMatched += AttemptToSpend;
        _cardComparator.СardsMatched += AddPoint;
    }

    private void OnDisable()
    {
        _cardComparator.СardsNotMatched -= AttemptToSpend;
        _cardComparator.СardsMatched -= AddPoint;
    }

    private void Update()
    {
        if (_cardComparator.QuantityGuessedCouples == _cardList.QuantityCouples)
        {
            LevelUp();
        }
        ////////////////////////////////////////////////////////////////////////
        Debug.Log($"Level: {Level} Attempt: {Attempts} Points: {Points}");
    }

    private void AttemptToSpend()
    {
        Attempts--;

        if (Attempts <= 0)
            GameOver();
    }

    private void AddPoint()
    {
        Points++;
    }

    private void LevelUp()
    {
        _cardComparator.QuantityGuessedCouples = 0;
        _cardList.AddCoupleCards();
        Level++;

        if (Level >= 10)
            Attempts = ++_startAttempts;
        else
            Attempts = _startAttempts;
    }

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }
}
