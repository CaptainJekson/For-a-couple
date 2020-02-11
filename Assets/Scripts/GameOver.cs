using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private TextMeshProUGUI _prizeText;

    private void Awake()
    {
        ShowPrize();
    }

    private void ShowPrize()
    {
        _prizeText.text = (_gameState.Level * _gameState.Points * 15).ToString() + " $";
    }
}
