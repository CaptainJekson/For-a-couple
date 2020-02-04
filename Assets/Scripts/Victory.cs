using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    private UnityAction _levelUp;
    public event UnityAction LevelUp
    {
        add => _levelUp += value;
        remove => _levelUp -= value;
    }

    public void OnNextLevelButtonClick()
    {
        _levelUp?.Invoke();
        gameObject.SetActive(false);
    }
}
