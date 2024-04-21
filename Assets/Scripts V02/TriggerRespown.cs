using System;
using UnityEngine;

public class TriggerRespown : MonoBehaviour
{
    [SerializeField] private GameObject _saveUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move playerRespown))
        {
            playerRespown._respown = transform;
            _saveUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _saveUI.SetActive(false);
    }
}
