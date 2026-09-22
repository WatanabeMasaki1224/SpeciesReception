using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        _score += score;
        UpdateScoreText ();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score;
    }

    public int GetScore()
    {
        return _score;
    }
}
