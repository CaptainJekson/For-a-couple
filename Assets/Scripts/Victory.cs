using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    public event UnityAction LevelUp;

    public void OnNextLevelButtonClick()
    {
        LevelUp?.Invoke();
        gameObject.SetActive(false);
    }
}
