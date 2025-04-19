using DG.Tweening;
using UnityEngine;

public class Flags : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationR, _rotationL;
    [SerializeField] private Transform _flagR,_flagL;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        _flagR.DORotate(_rotationR, 0.5f).SetEase(Ease.Linear);
        _flagL.DORotate(_rotationL, 0.5f).SetEase(Ease.Linear);
    }
}
