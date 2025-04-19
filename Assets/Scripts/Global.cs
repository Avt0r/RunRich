using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Global: MonoBehaviour
{
    private static Global _instance;

    public static Global Instance {  get => _instance; }

    public Global() => _instance = this;

    public Camera Camera;
    public PlayerController Player;
    public AnchorMover AnchorMover;

    public UnityEvent UpdateScore;
    public UnityEvent GameOver;
    public UnityEvent GameWin;

    public int Score = 20;
    public int ScoreMax = 100;
    public int Cash = 0;

    private void Start()
    {
        StartTime();
    }

    public void Play()
    {
        Player.Move();
        AnchorMover.Move();
    }

    public void ChangeScore(int val)
    {
        if (Score == 0 && val < 0)
        {
            GameOver.Invoke();
            return;
        }

        Score += val;

        if (Score < 0) Score = 0;
        if (Score > ScoreMax) Score = ScoreMax;

        UpdateScore?.Invoke();
    }

    public void ReloadScene() => SceneManager.LoadScene(0);

    public void StopTime() => Time.timeScale = 0f;
    public void StartTime() => Time.timeScale = 1f;
}
