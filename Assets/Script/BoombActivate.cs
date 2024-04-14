using UnityEngine;
using System.Collections;

public class BoombActivate : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _bombUI;
    [SerializeField] private Move _player;

    [SerializeField] private float _distance, _distanceDead;
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

        if (posPlayer < _distanceDead)
        {
            _player.Dead();
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
                _bombUI.SetActive(false);
                gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(1);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Move _playerMoved))
        {
            _bombUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("Deactiv");

            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                StopCoroutine("Deactiv");

                _timer = 0;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _timer = 0;
        _bombUI.SetActive(false);
    }
}
