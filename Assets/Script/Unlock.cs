using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField] private int count;

    void Start()
    {
        SceneSave.Save(count);
    }

}
