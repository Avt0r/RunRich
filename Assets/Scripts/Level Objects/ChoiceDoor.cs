using UnityEngine;

public class ChoiceDoor : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Instance.ChangeScore(_value);
        }
    }
}
