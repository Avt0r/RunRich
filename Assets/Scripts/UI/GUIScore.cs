using UnityEngine;
using UnityEngine.UI;

public class GUIScore : MonoBehaviour
{
    [SerializeField] private Text _text;
    private void OnEnable()
    {
        Global.Instance.UpdateScore.AddListener(ScoreUpdate);
    }

    private void OnDisable()
    {
        Global.Instance.UpdateScore.RemoveListener(ScoreUpdate);
    }

    private void ScoreUpdate() => _text.text = Global.Instance.Score.ToString();
}
