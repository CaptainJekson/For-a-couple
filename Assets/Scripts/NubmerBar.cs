using UnityEngine;
using TMPro;

public class NubmerBar : MonoBehaviour
{
    [SerializeField] private string _text; 
    private TextMeshProUGUI _levelText;

    public int Number { private get; set; }

    private void Awake()
    {
        _levelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        OnShowText();       
    }

    private void OnShowText()
    {
        _levelText.text = $"{_text} : {Number.ToString()}";
    }
}
