using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberCard;
    [SerializeField] private ParticleSystem _cardEffect;
    [SerializeField] private float _timeShow;

    private Button _button;
    private CardComparer _cardComparer;
    private Animator _animator;              

    public bool IsGuessed { get; set; }
    public int Number
    {
        get => Convert.ToInt32(_numberCard.text);
        set => _numberCard.text = value.ToString();
    }

    private CardState  State
    {
        get => (CardState)_animator.GetInteger("State");
        set => _animator.SetInteger("State", (int)value);
    }

    private enum CardState 
    {
        Idle, ShowCard, HideCard
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
        _cardComparer = FindObjectOfType<CardComparer>();
    }

    public void OnCardClick()
    {
        ShowCard();

        _cardComparer.AddCardToCompare(this);

        if (_cardComparer.IsCoupleCard)
            _cardComparer.ToCompare();
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
        _button.enabled = false;
        _cardEffect.Play();
        State = CardState .ShowCard;
    }

    public void HideCard()
    {
        _button.enabled = true;
        State = CardState .ShowCard;

        StartCoroutine(DelayIdleAnimation());
    }

    private IEnumerator DelayIdleAnimation()
    {
        yield return new WaitForSeconds(_timeShow);
        State = CardState .HideCard;
    }
}

