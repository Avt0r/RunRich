using DG.Tweening.Core.Easing;
using UnityEngine;

public class MoveArea : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _sensitivity,_maxDistance;

    private bool isDraging;
    private Vector2 startTouch, delta;


    private void Update()
    {
        if (_player == null)
        {
            _player = Global.Instance.Player.transform;
        }

        if (Input.GetMouseButtonDown(0) && !isDraging)
        {
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
        }


        if (Input.touches.Length > 0 && !isDraging)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
            }
        }

        if (isDraging)
        {
            if (Input.touches.Length < 0)
                delta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                delta = (Vector2)Input.mousePosition - startTouch;
        }
        else
        {
            delta = Vector2.zero;
        }

        if (delta.magnitude > 0)
        {
            delta *= _sensitivity;
            if (delta.x < -_maxDistance)
            {
                delta.x = -_maxDistance;
            }
            else if (delta.x > _maxDistance)
            {
                delta.x = _maxDistance;
            }

            _player.localPosition = new Vector3(delta.x, 0, 0);
        }

    }
}
