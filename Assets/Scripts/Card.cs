using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite _shirtСard;
    [SerializeField] private Sprite _faceCard;
    [SerializeField] private float _timeShowing;

    private Image _image;
    private Button _button;
    private TextMeshProUGUI _numberCard;
    private float _showingCooldown;
    private CardComparator _cardComparator;

    public bool IsGuessed { private get; set; }
    public int NumberCard { get => Convert.ToInt32(_numberCard.text); set => _numberCard.text = value.ToString(); }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _numberCard = GetComponentInChildren<TextMeshProUGUI>();
        _cardComparator = FindObjectOfType<CardComparator>();
    }

    private void Update()
    {
        if (_showingCooldown > 0)
            _showingCooldown -= Time.deltaTime;
        else if (IsGuessed == false && _cardComparator.IsCoupleCard == true)
            HideCard();
    }

    public void OnCardClick()
    {
        ShowCard();

        _cardComparator.AddCardToCompare(this);

        if (_cardComparator.IsCoupleCard)
            _cardComparator.ToCompare();
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }

    public void Init()
    {
        this.enabled = true;
        _image.enabled = true;
        _button.enabled = true;
    }

    private void ShowCard()
    {
        _image.sprite = _faceCard;
        _numberCard.enabled = true;
        _button.enabled = false;

        _showingCooldown = _timeShowing;
    }

    private void HideCard()
    {
        _image.sprite = _shirtСard;
        _numberCard.enabled = false;
        _button.enabled = true;
    }
}

