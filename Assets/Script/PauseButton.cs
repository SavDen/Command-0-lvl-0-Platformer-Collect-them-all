using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void ChangeTimeScale(float x)
    {
        Time.timeScale = x;
    }
    
}
