using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LocatorBlink : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _pauseTime;
    
    public void Start()
    {
        StartCoroutine(BlinkCoroutine());
    }

    public IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            _collider.enabled = true;
            _renderer.enabled = true;
            for (float t = 1.0f; t > 0.0f; t-= Time.deltaTime)
            {
                Color color = _renderer.material.color;
                color.a = t;
                _renderer.material.color = color;
                yield return null;
            }
            _renderer.enabled = false;
            _collider.enabled = false;
            yield return new WaitForSeconds(_pauseTime);
        }
    }
}
