using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prize : MonoBehaviour
{
    [SerializeField] GameState _gameState;

    private TextMeshProUGUI _prizeText;

    private void Awake()
    {
        _prizeText = GetComponent<TextMeshProUGUI>();
        _prizeText.text = (_gameState.Level * _gameState.Points * 15).ToString();
    }
}
