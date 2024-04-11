using System;
using UnityEngine;

public class EventGame : MonoBehaviour
{
    public static event Action EnterLoot;

    public static void SelectLoot()
    {
        EnterLoot?.Invoke();
    }

}
