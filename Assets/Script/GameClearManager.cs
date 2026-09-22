using TMPro;
using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameClearPamel;
    [SerializeField] private TextMeshProUGUI _resultScoreText;
    [SerializeField] private ScoreManager _scoreManager;

    private void Start()
    {
        _gameClearPamel.SetActive(false);
    }

    public void GameClear()
    {
        _gameClearPamel.SetActive(true);
        int score = _scoreManager.GetScore();
        _resultScoreText.text = $"Score : {score}";
    }
}
