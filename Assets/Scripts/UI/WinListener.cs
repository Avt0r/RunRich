using UnityEngine;

public class WinListener : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;

    private void OnEnable()
    {
        Global.Instance.GameWin.AddListener(ShowWin);
    }

    private void OnDisable()
    {
        Global.Instance.GameWin.RemoveListener(ShowWin);
    }

    private void ShowWin() => _winWindow.SetActive(true);
}
