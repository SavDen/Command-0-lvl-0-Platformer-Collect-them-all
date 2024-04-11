using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField] private float _drag;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        
        _rb.drag = 10;   
    }

    private void OnCollisionExit(Collision collision)
    {
        _rb.drag = _drag;
    }
}
