using UnityEngine;

public class WaterBar : MonoBehaviour
{
    [SerializeField] private Transform _waterBar;
    [SerializeField] float _speed, _controlPos;
    [SerializeField] private bool _left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_waterBar.localRotation.x >= _controlPos)
        {
            _left = true;
        }

        else if (_waterBar.localRotation.x <= -_controlPos)
        {
            _left = false;
        }


        if(_left)
            _waterBar.Rotate(-_speed * Time.deltaTime, 0, 0);

        else
            _waterBar.Rotate(_speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move player))
        {
            player.Dead();
        }

    }
}
