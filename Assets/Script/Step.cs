using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField] private float _speed, _speedFollowPlatform;
    [SerializeField] private GameObject _platform;
    [SerializeField] private Rigidbody _rb, _rbPlayer;
    [SerializeField] private bool down, left, vertical, horizontal, isPlatform;


    public float posMax, posMin;


   
    private void FixedUpdate()
    {
        if (vertical) //Проверка режима работы
        {
            //Проверка границ платформы
            if (_platform.transform.localPosition.y <= posMin)
            {
                down = false;

            }

            if (_platform.transform.localPosition.y >= posMax)
            {
                down = true;
            }

            //Движение платформы
            if (down)
                _rb.AddForce(0, -_speed, 0, ForceMode.VelocityChange);
            else
                _rb.AddForce(0, _speed, 0, ForceMode.VelocityChange);
        }

        if (horizontal) //Проверка режима работы
        {
            //Проверка границ платформы
            if (_platform.transform.localPosition.x <= posMin)
            {
                left = false;

            }

            if (_platform.transform.localPosition.x >= posMax)
            {
                left = true;
            }

            //Движение платформы
            if (left)
                _rb.AddForce(-_speed,0, 0, ForceMode.VelocityChange);
            else
                _rb.AddForce(_speed, 0, 0, ForceMode.VelocityChange);

            //Движение игрока пока тот находится на платформе
            if (isPlatform)
            {
                if (left)
                    _rbPlayer.AddForce(-_speedFollowPlatform, 0, 0, ForceMode.VelocityChange);
                else
                    _rbPlayer.AddForce(_speedFollowPlatform, 0, 0, ForceMode.VelocityChange);

            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Move player))
        {
            _platform.GetComponent<BoxCollider>().isTrigger = false;
            isPlatform = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Move player))
        {
            _platform.GetComponent<BoxCollider>().isTrigger = true;
            isPlatform = false;
        }

    }


}
