using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationR, _rotationL;
    [SerializeField] private Transform _doorR, _doorL;

    [SerializeField] private int _statusToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerController.Status <= _statusToOpen)
            {
                Rotate();
            }
            else
            {
                Global.Instance.GameWin.Invoke();
            }
        }
    }

    private void Rotate()
    {
        _doorR.DORotate(_rotationR, 0.5f).SetEase(Ease.Linear);
        _doorL.DORotate(_rotationL, 0.5f).SetEase(Ease.Linear);
    }
}
