using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move player))
        {
            EventGame.SelectLoot();
            gameObject.SetActive(false);
        }
    }
}
