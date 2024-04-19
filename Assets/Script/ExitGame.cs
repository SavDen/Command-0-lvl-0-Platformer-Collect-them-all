using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private int _levelScore;
    [SerializeField] private GameObject _gameOver, _needScore;
    [SerializeField] private Text _needScoreText;
    [SerializeField] private Text _actualScoreText;
    private int actualScore;
    
    
    

    private void OnEnable() => EventGame.EnterLoot += OnScore;

    private void OnDisable() => EventGame.EnterLoot -= OnScore;

    private void Awake()
    {
        _needScoreText.text =  _levelScore.ToString();
    }
    private void OnScore()
    {
        actualScore++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move player))
        {
            if(actualScore >= _levelScore)
            {
                _gameOver.SetActive(true);
                player.gameObject.SetActive(false);
            }

            else
            {
                _needScore.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _needScore.SetActive(false);
    }


}
