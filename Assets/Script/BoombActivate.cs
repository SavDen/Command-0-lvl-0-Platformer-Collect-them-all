using UnityEngine;
using System.Collections;

public class BoombActivate : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _bombUI;
    [SerializeField] private float _distance;
    [SerializeField] private float _distanceDeact;
    private int _timer;
    private void Start()
    {
        _renderer.enabled = false;
    }

    private void Update()
    {
        float posPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        if (posPlayer > _distance)
        {
            _renderer.enabled = false;
        }
        else
        {
            _renderer.enabled = true;
        }

        if (posPlayer < _distanceDeact)
        {
            //_bombUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("Deactiv");
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                StopCoroutine("Deactiv");

                if(_timer < 3)
                {
                    Debug.Log("dead");
                }

                _timer = 0;
            }
        }

        //else if(posPlayer > _distanceDeact)
        //{
        //    if(_timer < 3)
        //    {
        //        Debug.Log("dead");
        //    }
        //}

    }

    IEnumerator Deactiv()
    {
        while (true)
        {
            _timer++;
            Debug.Log(_timer);
            if(_timer == 5)
            {
                gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(1);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Move _playerMoved))
        {
            Debug.Log("Dead");
            //gameObject.SetActive(false);
        }

    }
}
