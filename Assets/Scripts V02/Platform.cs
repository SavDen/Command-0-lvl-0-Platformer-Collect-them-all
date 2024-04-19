using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private bool _vertical, _horizontal;
    [SerializeField] private float _speed;
    [SerializeField] private float _min, _max;

    private bool _isDown, _isLeft;
    private Vector3 _position, _firstPosition;

    private void Start()
    {
        _firstPosition = transform.position;
    }
    private void FixedUpdate()
    {
        _position = transform.position;

        if (_horizontal)
        {

            if (_position.x <= _firstPosition.x + _min)
            {
                _isLeft = false;
            }

            if (_position.x >= _firstPosition.x + _max)
            {
                _isLeft = true;
            }

            if(_isLeft)
                Move(new Vector3(-1, 0, 0));
            else
                Move(new Vector3(1, 0, 0));
            
        }

        if (_vertical)
        {
            if (_position.y <= _firstPosition.y + _min)
            {
                _isDown = false;
            }

            if (_position.y >= _firstPosition.y + _max)
            {
                _isDown = true;
            }

            if (_isDown)
                Move(new Vector3(0, -1, 0));
            else
                Move(new Vector3(0, 1, 0));
        }
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.transform.parent = transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
