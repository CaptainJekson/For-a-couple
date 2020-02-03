﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private TextMeshProUGUI _prizeText;
    [SerializeField] private TextMeshProUGUI _clockText;
    [SerializeField] private Button _сontinueGameButton;
    [SerializeField] private float _timeBetweenSessions;

    private float _sessionCooldown;

    private void Awake()
    {
        ShowPrize();

        _sessionCooldown = _timeBetweenSessions;
    }

    private void Update()
    {
        if (_sessionCooldown > 0)
            _sessionCooldown -= Time.deltaTime;
        else
            _сontinueGameButton.enabled = true;

        ShowСlock();
    }

    private void OnDisable()
    {
        _сontinueGameButton.enabled = false;
    }

    public void OnContinueGameButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void ShowСlock()
    {
        _clockText.text = _sessionCooldown.ToString();
    }

    private void ShowPrize()
    {
        _prizeText.text = (_gameState.Level * _gameState.Points * 15).ToString();
    }
}
