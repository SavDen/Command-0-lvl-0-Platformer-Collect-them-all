using UnityEngine;
using UnityEngine.UI;
public class UILoot : MonoBehaviour
{
    private Text _scoreText;
    private int _score;

    private void OnEnable() => EventGame.EnterLoot += OnSelectLoot;

    private void OnDisable() => EventGame.EnterLoot -= OnSelectLoot;


    private void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    private void OnSelectLoot()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
