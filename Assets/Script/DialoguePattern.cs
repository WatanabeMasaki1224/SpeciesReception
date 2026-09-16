using UnityEngine;

[CreateAssetMenu(fileName = "DialoguePattern", menuName = "Scriptable Objects/DialoguePattern")]
public class DialoguePattern : ScriptableObject
{
    [System.Serializable]
    public class DialoguePattern
    {
        public string[] _dialogues = new string[3];
    }

    public DialoguePattern[] _patterns;
}
