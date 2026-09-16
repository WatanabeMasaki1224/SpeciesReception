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
    private string[] _dialogues;

    public void Initialize(Species species, string[] dialogues)
    {
        _species = species;
        _dialogues = dialogues;
    }

    public Species GetSpecies()
    {
        return _species;
    }

    public string GetDialogue(int index)
    {
        return _dialogues[index];
    }
}
