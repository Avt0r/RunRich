using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] private WayPoint[] _points;

    private int _pointIndex = 0;

    private bool _lastPoint = false;

    public Vector3 GetNext()
    {
        if (_pointIndex >= _points.Length)
        {
            _lastPoint = true;
            Global.Instance.GameWin.Invoke();
            return _points[^1].transform.position;
        }
        else
        {
            return _points[_pointIndex++].transform.position;
        }
    }

    public bool LastPoint { get => _lastPoint; }
}