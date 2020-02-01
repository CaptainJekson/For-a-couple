using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AttemptsBar : MonoBehaviour
{
    [SerializeField] GameState _gameState;

    private TextMeshProUGUI _levelText;

    private void Awake()
    {
        _levelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _levelText.text = "Попытки: " + _gameState.Attempts.ToString();
    }
}
