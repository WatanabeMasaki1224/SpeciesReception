using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameClearManager _gameClearManager;
    [SerializeField] private float _timeLimit = 360f;
    private float _time;

    private void Start()
    {
        _time = _timeLimit;

    }

    private void Update()
    {
        if(_time <= 0)
        {
            return;
        }

        _time -= Time.deltaTime;

        //•ÛŒ¯
        if(_time <= 0)
        {
            _time = 0;
            _gameClearManager.GameClear();
        }

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_time / 60);
        int seconds = Mathf.FloorToInt(_time % 60);

        _timerText.text = $"Time : {minutes:00}:{seconds:00}";
    }
}
