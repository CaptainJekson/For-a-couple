using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    [SerializeField] private int _startAttempts;
    [SerializeField] private int _levelIncreaseAttempts;
    [SerializeField] private CardComparer _cardComparator;
    [SerializeField] private CardsTable _cardsTable;
    [SerializeField] private Victory _vicloty;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private NubmerBar _pointsBar;
    [SerializeField] private NubmerBar _attemptsBar;
    [SerializeField] private NubmerBar _levelBar;

    public int Level { get; private set; }
    public int Points { get; private set; }
    public int Attempts { get; private set; }

    private void Awake()
    {
        Attempts = _startAttempts;
        Level = 1;
        InitStartGame();
    }

    private void OnEnable()
    {
        _cardComparator.СardsNotMatched += OnAttemptToSpend;
        _cardComparator.СardsMatched += OnAddPoint;
        _vicloty.LevelUp += OnLevelUp;
    }

    private void OnDisable()
    {
        _cardComparator.СardsNotMatched -= OnAttemptToSpend;
        _cardComparator.СardsMatched -= OnAddPoint;
        _vicloty.LevelUp -= OnLevelUp;
    }

    private void Update()
    {
        if (_cardComparator.QuantityGuessedCouples == _cardsTable.QuantityCouples)
        {
            _vicloty.gameObject.SetActive(true);
        }
    }

    private void InitStartGame()
    {
        _levelBar.Number = Level;
        _attemptsBar.Number = Attempts;
        _pointsBar.Number = Points;
    }

    private void OnAttemptToSpend()
    {
        _attemptsBar.Number = --Attempts;
        _attemptsBar.OnShowText();

        if (Attempts <= 0)
            CompleteTheGame();
    }

    private void OnAddPoint()
    {
        _pointsBar.Number = ++Points;
        _pointsBar.OnShowText();
    }

    private void OnLevelUp()
    {
        _cardComparator.QuantityGuessedCouples = 0;
        _cardsTable.AddCoupleCards();
        _levelBar.Number = ++Level;
        _levelBar.OnShowText();

        if (Level >= _levelIncreaseAttempts)
        {
            Attempts = ++_startAttempts;
        }
        else
        {
            Attempts = _startAttempts;
        }
        _attemptsBar.Number = Attempts;
        _attemptsBar.OnShowText();
    }

    private void CompleteTheGame()
    {
        _gameOverPanel.SetActive(true);
    }
}
