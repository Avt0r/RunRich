using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Types _type;

    public Types WayType { get { return _type; } }

    public enum Types
    {
    Turn,
    Door,
    End
    }

}
