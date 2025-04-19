using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Way))]
public class AnchorMover : MonoBehaviour
{
    [SerializeField] private Way _way;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Awake()
    {
        Global.Instance.AnchorMover = this;
    }

    private void Start()
    {
        Global.Instance.GameOver.AddListener(Stop);
        Global.Instance.GameWin.AddListener(Stop);
    }

    public void Move()
    {
        _target = _way.GetNext();
        transform.DOMove(_target, (_target - transform.position).magnitude / _speed).SetEase(Ease.Linear);
        if (!_way.LastPoint) transform.DOLookAt(_target, 1f).SetEase(Ease.Linear);

        StartCoroutine(CheckForNextPoint());
    }

    public void Stop()
    {
        StopCoroutine(CheckForNextPoint());
        transform.DOPause();
    }

    private IEnumerator CheckForNextPoint()
    {
        while ((_target - transform.position).magnitude > _minDistance) yield return null;
        Move();
    }

    private void OnDisable()
    {
        Global.Instance.GameOver.RemoveListener(Stop);
        Global.Instance.GameWin.RemoveListener(Stop);
    }
}
