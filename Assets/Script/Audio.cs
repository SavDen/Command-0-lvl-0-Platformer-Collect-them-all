using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void Play()
    {
        _audio.Play();
    }
}
