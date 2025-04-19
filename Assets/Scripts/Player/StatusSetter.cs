using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusSetter : MonoBehaviour
{
    [SerializeField] private List<GameObject> _statuses;

    private void Start()
    {
        Global.Instance.UpdateScore.AddListener(UpdateStatus);

        _statuses.ForEach(s => s.SetActive(false));
        _statuses[PlayerController.Status].SetActive(true);
    }

    public void UpdateStatus()
    {
        _statuses.ForEach(s => s.SetActive(false));
        _statuses[PlayerController.Status].SetActive(true);
    }

    private void OnDisable()
    {
        Global.Instance.UpdateScore.RemoveListener(UpdateStatus);
    }
}
