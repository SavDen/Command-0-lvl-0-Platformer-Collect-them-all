using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
