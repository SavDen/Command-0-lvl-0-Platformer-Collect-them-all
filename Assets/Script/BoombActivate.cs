using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;

public class BoombActivate : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _bombUI;
    [SerializeField] private GameObject _slider;
    [SerializeField] private Move _player;
    [SerializeField] private Slider _progres;
    [SerializeField] private AudioSource _actionDeactiv, _deactiv, _soundBomb;

    [SerializeField] private float _timeDeactiv;
    [SerializeField] private float _distance, _distanceDead;
    [SerializeField] private bool _startDeactivation, _isTrigger;

    private float _timer =0;
    
    private void Start()
    {
        _renderer.enabled = false;
        _soundBomb = GetComponent<AudioSource>();
    }

    private void Update()
    {

        float posPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        if (posPlayer > _distance)
        {
            _renderer.enabled = false;
            _soundBomb.volume = 0;
        }
        else
        {
            _renderer.enabled = true;
            _soundBomb.volume = 0.6f;
        }

        if (posPlayer <= _distanceDead && _playerTransform != _player._respown)
        {
            print("Dead");
            _player.Dead();
        }

        if (_startDeactivation)
            Timer();

        if(_isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _startDeactivation = true;
                _actionDeactiv.Play();
                _slider.SetActive(true);

            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                _timer = 0;
                _progres.value = 0;
                _actionDeactiv.Stop();
                _slider.SetActive(false);
                _startDeactivation = false;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Move _playerMoved))
        {
            _bombUI.SetActive(true);
            _isTrigger = true;
            _progres.maxValue = _timeDeactiv;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _timer = 0;
        _isTrigger = false;
        _startDeactivation = false;
        _actionDeactiv.Stop();
        _progres.value = 0;
        _slider.SetActive(false);
        _bombUI.SetActive(false);
    }

    private void Timer()
    {
        
        _timer += Time.deltaTime;
        _progres.value = _timer;
        if(_timer >= _timeDeactiv)
        {
            _slider.SetActive(false);
            _progres.value = 0;
            _bombUI.SetActive(false);
            _actionDeactiv.Stop();
            _deactiv.Play();
            gameObject.SetActive(false);
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.up, _distanceDead);
    }
#endif

}
