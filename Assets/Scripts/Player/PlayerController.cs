using NUnit.Framework;
using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(StatusSetter))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private StatusSetter _statusSetter;
    
    public UnityEvent<int> StatusChanged;

    private void OnValidate()
    {
        if (_statusSetter == null) _statusSetter = GetComponent<StatusSetter>();
    }

    private void Awake()
    {
        Global.Instance.Player = this;

        PlayAnim("Idle");
    }

    private void Start()
    {
        Global.Instance.UpdateScore.AddListener(CheckScore);
        Global.Instance.GameWin.AddListener(EndWin);
        Global.Instance.GameOver.AddListener(EndLoose);
    }

    public void Move()
    {
        PlayAnim("Walk");

        _playerUI.Show();
    }

    public void EndWin()
    {
        PlayAnim("Dance");
    }

    public void EndLoose()
    {
        PlayAnim("Cry");
    }

    private void CheckScore()
    {
        UpdateStatus();
    }

    private void OnDisable()
    {
        Global.Instance.UpdateScore.RemoveListener(CheckScore);
        Global.Instance.GameWin.RemoveListener(EndWin);
        Global.Instance.GameOver.RemoveListener(EndLoose);
    }

    public void UpdateStatus() => StatusChanged.Invoke(Status);
    public static int Status => (int)(4 - (((float)Global.Instance.Score / Global.Instance.ScoreMax) * 4)); 
    public void PlayAnim(string name) =>_animator.Play(name);
}
