using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private int _needScore;
    [SerializeField] private GameObject _gameOver, _needLoot;
    private int actualScore;

    private void OnEnable() => EventGame.EnterLoot += OnScore;

    private void OnDisable() => EventGame.EnterLoot -= OnScore;

    private void OnScore()
    {
        actualScore++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Move player))
        {
            if(actualScore == _needScore)
            {
                _gameOver.SetActive(true);
                player.gameObject.SetActive(false);
            }

            else
            {
                _needLoot.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _needLoot.SetActive(false);
    }


}
