using System;
using UnityEngine;

public class TriggerRespown : MonoBehaviour
{
    [SerializeField] private Animator _saveUI;
    [SerializeField] private AudioSource _audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move playerRespown))
        {
            playerRespown._respown = transform;
            _audio.Play();
            _saveUI.SetTrigger("start");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
