using UnityEngine;

public class Customer : MonoBehaviour
{
    public enum Species
    {
        Human,
        Vampire,
        Ghost,
        Kappa
    }

    private Species _species;
    [SerializeField] private DialogueData _dialogueData;
    private DialogueData.DialoguePattern _currentPattern;
    private int _dialogueIndex;

    private void Start()
    {
        // 登録されている会話パターンからランダムで1つ選ぶ
        int randomIndex = Random.Range(0, _dialogueData._patterns.Length);
        _currentPattern = _dialogueData._patterns[randomIndex];
        _dialogueIndex = 0;
    }

    // 現在のセリフを取得
    public string GetCurrentDialogue()
    {
        return _currentPattern._dialogues[_dialogueIndex];
    }

    // 次のセリフへ進む
    public bool NextDialogue()
    {
        _dialogueIndex++;

        // 3つ目まで終わったらfalse
        if (_dialogueIndex >= 3)
        {
            return false;
        }

        return true;
    }
}
