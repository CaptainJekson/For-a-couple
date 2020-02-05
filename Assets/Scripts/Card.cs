using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite _shirtСard;
    [SerializeField] private Sprite _faceCard;
    [SerializeField] private TextMeshProUGUI _numberCard;
    [SerializeField] private float _timeShowing;
    [SerializeField] private ParticleSystem _cardEffect;

    private Image _image;
    private Button _button;
    private float _showingCooldown;
    private CardComparer _cardComparator;

    public bool IsGuessed { get; set; }
    public int Number
    {
        get => Convert.ToInt32(_numberCard.text);
        set => _numberCard.text = value.ToString();
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _cardComparator = FindObjectOfType<CardComparer>();
        _numberCard.enabled = false;
    }

    private void Update()
    {
        if (_showingCooldown > 0)
        {
            _showingCooldown -= Time.deltaTime;
        }
        else if (IsGuessed == false && _cardComparator.IsCoupleCard == true)
        {
            HideCard();
        }
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

    public void Init(CardComparer сardComparer)
    {
        сardComparer = FindObjectOfType<CardComparer>();
    }

    private void ShowCard()
    {
        _image.sprite = _faceCard;
        _numberCard.enabled = true;
        _button.enabled = false;
        _showingCooldown = _timeShowing;

        _cardEffect.Play();
    }

    private void HideCard()
    {
        _image.sprite = _shirtСard;
        _numberCard.enabled = false;
        _button.enabled = true;
    }
}

