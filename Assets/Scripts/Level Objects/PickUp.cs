using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Instance.ChangeScore(_value);
            gameObject.SetActive(false);
        }
    }
}
