using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public class DialoguePattern
    {
        public string[] _dialogues = new string[3];
    }

    public DialoguePattern[] _patterns;
}
