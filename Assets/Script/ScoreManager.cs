using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;

    public void AddScore(int score)
    {
        _score += score;
        Debug.Log("sucore:" + _score);
    }
}
