using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private int _startAttempts;
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
        InitStartGAme();
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

    private void InitStartGAme()
    {
        _levelBar.Number = Level;
        _attemptsBar.Number = Attempts;
        _pointsBar.Number = Points;
    }

    private void OnAttemptToSpend()
    {
        _attemptsBar.Number = --Attempts;

        if (Attempts <= 0)
            CompleteTheGame();
    }

    private void OnAddPoint()
    {
        _pointsBar.Number = ++Points;
    }

    private void OnLevelUp()
    {
        _cardComparator.QuantityGuessedCouples = 0;
        _cardsTable.AddCoupleCards();
        _levelBar.Number = ++Level;

        if (Level >= 10)
        {
            Attempts = _startAttempts++;
        }
        else
        {
            Attempts = _startAttempts;
        }
        _attemptsBar.Number = Attempts;
    }

    private void CompleteTheGame()
    {
        _gameOverPanel.SetActive(true);
    }
}
