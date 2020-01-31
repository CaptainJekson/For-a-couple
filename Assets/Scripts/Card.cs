﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite _shirtСard;
    [SerializeField] private Sprite _faceCard;
    [SerializeField] private float _timeShowing;

    private Image _image;
    private Button _button;

    private TextMeshProUGUI _numberCard;
    private float _showingCooldown;

    public bool IsGuessed { private get; set; }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _numberCard = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_showingCooldown > 0)
            _showingCooldown -= Time.deltaTime;
        else if(IsGuessed == false)
            HideCard();
    }

    public void OnCardClick()
    {
        ShowCard();
    }

    public void SetNumberCard(int number)
    {
        _numberCard.text = number.ToString();
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }

    public void OnEnableComponets()
    {
        this.enabled = true;
        _image.enabled = true;
        _button.enabled = true;
    }

    private void ShowCard()
    {
        _image.sprite = _faceCard;
        _numberCard.enabled = true;

        _showingCooldown = _timeShowing;
    }

    private void HideCard()
    {
        _image.sprite = _shirtСard;
        _numberCard.enabled = false;
    }
}

