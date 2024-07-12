using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioPause : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Color32[] _color; //0 green, 1 red

    static private bool _musOn;

    


    void Start()
    {
        //_image.sprite = _sprite[0];
        //_image.color = _color[0];
        //_musOn = true;

    }

    public void MusButton ()
    {
        if(_musOn)
        {
            _image.sprite = _sprite[1];
            _image.color = _color[1];
            _mixer.audioMixer.SetFloat("volume", -80);
            _musOn = false;
        }
        else
        {
            _image.sprite = _sprite[0];
            _image.color = _color[0];
            _mixer.audioMixer.SetFloat("volume", 0);
            _musOn = true;
        }
    }
}
