using UnityEngine;
using UnityEngine.UI;
public class Boomb : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _actUI;
    [SerializeField] private GameObject _numpad;

    [SerializeField] private Text _scoreText;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Move _playerMove;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private MeshRenderer meshRenderer;
    
    [SerializeField] private int _bonus;
    [SerializeField] private float _distance;
    [SerializeField] private float _distanceShow;
    [SerializeField] private bool _dead;
    // Start is called before the first frame update
    private void Awake()
    {
        _gameOverPanel.SetActive(false);
        
    }

    private void Update()
    {

        _distance = Vector3.Distance(transform.position, _playerTransform.position);


        if (_distance < _distanceShow && !_dead)
        {
            _actUI.SetActive(true);

            

            _meshRenderer.enabled = true;
        }
        else
        {
            _meshRenderer.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move _playerMoved))
        {
            Debug.Log("Dead");  
        }
        
    }
   
}
         

