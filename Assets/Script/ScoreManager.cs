using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float _defaultScore;
    private int _score;
    private int _correctCount;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        _correctCount++;
        float multiplier = 1f;

        if (_correctCount >= 5)
        {
            multiplier = 2f;
        }
        else if (_correctCount >= 3)
        {
            multiplier = 1.5f;
        }

        int addScore = Mathf.RoundToInt(_defaultScore * multiplier);
        _score += addScore;
        UpdateScoreText();
    }

    public void ResetCombo()
    {
        _correctCount = 0;
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
