using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberCard;
    [SerializeField] private ParticleSystem _cardEffect;
    [SerializeField] private float _timeShow;
    [SerializeField] private AudioClip _soundShowCard;
    [SerializeField] private AudioClip _soundGuessingCards;

    private Button _button;
    private Animator _animator;
    private CardComparer _cardComparer;
    private AudioSource _audio;

    public bool IsGuessed { get; private set; }
    public int Number
    {
        get => Convert.ToInt32(_numberCard.text);
        set => _numberCard.text = value.ToString();
    }

    private CardState State 
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
        _audio = GetComponent<AudioSource>();
    }

    public void OnCardClick()
    {
        ShowCard();

        _cardComparer.AddCardToCompare(this);

        if (_cardComparer.IsCoupleCard)
            _cardComparer.ToCompare();
    }

    public void Init(CardComparer cardComparer)
    {
        _cardComparer = cardComparer;
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }

    public void HideCard()
    {
        _button.enabled = true;
        State = CardState.ShowCard;
        _audio.Play();
        StartCoroutine(DelayIdleAnimation());
    }

    public void ActivateGuessing()
    {
        _cardEffect.Play();
        _audio.clip = _soundGuessingCards;
        _audio.Play();
        IsGuessed = true;
    }

    private void ShowCard()
    {
        _button.enabled = false;
        _audio.clip = _soundShowCard;
        _audio.Play();
        State = CardState.ShowCard;
    }

    private IEnumerator DelayIdleAnimation()
    {
        yield return new WaitForSeconds(_timeShow);
        State = CardState.HideCard;
    }
}

