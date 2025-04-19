using UnityEngine;

public class GameOverListener : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverWindow;

    private void OnEnable()
    {
        Global.Instance.GameOver.AddListener(ShowGameOver);
    }

    private void OnDisable()
    {
        Global.Instance.GameOver.RemoveListener(ShowGameOver);
    }

    private void ShowGameOver() => _gameOverWindow.SetActive(true);
}
