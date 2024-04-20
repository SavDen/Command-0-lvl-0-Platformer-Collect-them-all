using UnityEngine;

public class TriggerRespown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move playerRespown))
        {
            playerRespown._respown = transform;
        }
    }
}
