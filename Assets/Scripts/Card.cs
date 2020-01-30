using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite _shirtСard;
    [SerializeField] private Sprite _faceCard;

    private Image _image;
    private TextMeshProUGUI _numberCard;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnCardClick()
    {
        _image.sprite = _faceCard;
    }
}

