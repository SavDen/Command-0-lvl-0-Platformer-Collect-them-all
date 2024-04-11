
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private  Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset; // x =0; y = 10; z = -5;
    

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position + _offset, _speed * Time.deltaTime);
    }
}
