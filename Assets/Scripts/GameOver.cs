using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        _сontinueGameButton.enabled = false;
    }

    private void Update()
    {
        if (_sessionCooldown > 0)
            _sessionCooldown -= Time.deltaTime;
        else
            _сontinueGameButton.enabled = true;

        ShowСlock();
    }

    public void OnContinueGameButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowСlock()
    {
        int minutes = (int)_sessionCooldown / 60;
        int seconds = (int)_sessionCooldown - minutes * 60;

        if (seconds.ToString().Length > 1)
            _clockText.text = $"{minutes} : {seconds}";
        else
            _clockText.text = $"{minutes} : 0{seconds}";

        if (minutes == 0 && seconds == 0)
            _clockText.text = "Продолжить";
    }

    private void ShowPrize()
    {
        _prizeText.text = (_gameState.Level * _gameState.Points * 15).ToString() + " $";
    }
}
