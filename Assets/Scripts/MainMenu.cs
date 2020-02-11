using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;

    private void Start()
    {
        _recordText.text = "Ваш рекорд: " + PlayerPrefs.GetInt("Record").ToString() + " $";
    }

    public void OnStartGameButtonClick()
    {
        gameObject.SetActive(false);
    }

    public void OnSettingsButtonClick()
    {

    }

    public void OnExitGameButtonClick()
    {

    }
}
