using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _platform;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bool down, left, vertical, horizontal;

    public float posMax, posMin;


   
    private void FixedUpdate()
    {
        if (vertical)
        {
            if (_platform.transform.localPosition.y <= posMin)
            {
                down = false;

            }

            if (_platform.transform.localPosition.y >= posMax)
            {
                down = true;
            }


            if (down)
                _rb.MovePosition(_rb.position + new Vector3(0, -1 * _speed, 0));
            else
                _rb.MovePosition(_rb.position + new Vector3(0, 1 * _speed, 0));
        }

        if(horizontal)
        {
            if (_platform.transform.localPosition.x <= posMin)
            {
                left = false;

            }

            if (_platform.transform.localPosition.x >= posMax)
            {
                left = true;
            }


            if (left)
                _rb.MovePosition(_rb.position + new Vector3(-1 * _speed, 0, 0));
            else
                _rb.MovePosition(_rb.position + new Vector3(1 * _speed, 0, 0));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Move player))
        _platform.GetComponent<BoxCollider>().isTrigger = false;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Move player))
        _platform.GetComponent<BoxCollider>().isTrigger = true;


    }


}
