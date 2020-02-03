using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private int _startAttempts;
    [SerializeField] private CardComparator _cardComparator;
    [SerializeField] private CardsTable _cardList;
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
        InitTextBar();
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
    }

    private void InitTextBar()
    {
        _levelBar.Number = Level;
        _attemptsBar.Number = Attempts;
        _pointsBar.Number = Points;
    }

    private void AttemptToSpend()
    {
        _attemptsBar.Number = --Attempts;

        if (Attempts <= 0)
            GameOver();
    }

    private void AddPoint()
    {
        _pointsBar.Number = ++Points;
    }

    private void LevelUp()
    {
        _cardComparator.QuantityGuessedCouples = 0;
        _cardList.AddCoupleCards();
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

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }
}
