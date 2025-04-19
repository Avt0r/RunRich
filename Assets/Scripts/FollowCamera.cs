using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float distanceFromPlayer = 10f;

    [SerializeField] private float heightAboveGround = 5f;

    [SerializeField] private float rotationXOffset = 0f;  
    [SerializeField] private float rotationYOffset = 0f;

    private void Start()
    {
        player = Global.Instance.Player.transform;
    }

    void LateUpdate()
    {
        // ������� ������ + �������� �� ������
        Vector3 desiredPosition = player.position + new Vector3(0, heightAboveGround, 0);

        // ��������� ����� ������� ������
        Quaternion lookRotation = Quaternion.Euler(rotationXOffset, player.eulerAngles.y + rotationYOffset, 0);
        Vector3 offset = lookRotation * new Vector3(0, 0, -distanceFromPlayer);
        transform.position = desiredPosition + offset;

        // ����������� ������ �� ������
        transform.LookAt(player);
    }
}