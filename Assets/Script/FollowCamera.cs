
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private  Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset; // x =9.2; y = 7.3; z = -14;
    private float _posXLeft, _posXRight;
    private bool _forward;

    private void Awake()
    {
        _posXLeft = -_offset.x;
        _posXRight = _offset.x;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
            _forward = true;
        else if (Input.GetKeyDown(KeyCode.A))
            _forward = false;

        if (_forward)
            _offset.x = _posXRight;
        else
            _offset.x = _posXLeft;
        
        transform.position = Vector3.MoveTowards(transform.position, _target.position + _offset, _speed * Time.deltaTime);
    }
}
