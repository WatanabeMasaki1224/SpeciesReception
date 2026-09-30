using System.Collections;
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

    [SerializeField] private Species _species;
    [SerializeField] private DialogueData _dialogueData;
    private DialogueData.DialoguePattern _currentPattern;
    private int _dialogueIndex;
    [SerializeField] private float _moveTime = 1f;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
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

    public Species GetSpecies()
    {
        return _species;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveCoroutine(targetPosition));
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        _animator.Play("Run");

        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / _moveTime;

            transform.position = Vector3.Lerp(
                startPosition,
                targetPosition,
                t
            );

            yield return null;
        }

        transform.position = targetPosition;
        _animator.Play("Idle");
    }
}
