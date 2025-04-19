using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _statusBar;
    [SerializeField] private TMP_Text _statusText;

    private string[] statuses =
    {
        "Ã»ÀÀ»ŒÕ≈–",
        "¡Œ√¿“€…",
        "—Œ—“Œﬂ“≈À‹Õ€…",
        "¡≈ƒÕ€…",
        "¡ŒÃ∆"
    };

    private void Start()
    {
        UpdateUI();

        _canvas.gameObject.SetActive(false);

        _canvas.worldCamera = Global.Instance.Camera;
        Global.Instance.UpdateScore.AddListener(UpdateUI);
    }

    private void LateUpdate()
    {
        _canvas.transform.LookAt(Global.Instance.Camera.transform.position);
    }

    public void Show()
    {
        _canvas.gameObject.SetActive(true);
    }

    private void UpdateUI()
    {
        _statusText.text = statuses[PlayerController.Status];

        switch (PlayerController.Status)
        {
            case 0:
                _statusText.color = new Color(0f, 1f, 1f, 1f);
                _statusBar.color = new Color(0f, 1f, 1f, 1f);
                break;
            case 1:
                _statusText.color = Color.green;
                _statusBar.color = Color.green;
                break;
            case 2: 
                _statusText.color = Color.yellow;
                _statusBar.color = Color.yellow;
                break;
            case 3:
                _statusText.color = new Color(1f, 0.5f, 0, 1f);
                _statusBar.color = new Color(1f, 0.5f, 0, 1f);
                break;
            case 4: 
                _statusText.color = Color.red;
                _statusBar.color = Color.red;
                break;
        }

        _statusBar.fillAmount = (float) Global.Instance.Score / Global.Instance.ScoreMax;

    }

    private void OnDisable()
    {
        Global.Instance.UpdateScore.RemoveListener(UpdateUI);
    }
}
