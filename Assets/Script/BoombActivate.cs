using UnityEngine;
using System.Collections;

public class BoombActivate : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _bombUI;
    [SerializeField] private float _distance, _distanceDeact;
    [SerializeField] private bool _startDeactivation;
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
                _startDeactivation = true;

            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                StopCoroutine("Deactiv");

                if(_timer < 5)
                {
                    Debug.Log("Dead Up deactiv key");
                }

                _timer = 0;
                _startDeactivation = false;
            }
        }

        else if (posPlayer > _distanceDeact)
        {
            if(_startDeactivation)
            {
                StopCoroutine("Deactiv");
                Debug.Log("Dead move distance");
            }
        }

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
