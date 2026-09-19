using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button _nextButton;
    [SerializeField]private Customer _customer;

    public void Start()
    {
        StartDialogue(_customer);
    }

    public void StartDialogue(Customer customer)
    {
        _customer = customer;
        _dialogueText.text = _customer.GetCurrentDialogue();
        _nextButton.gameObject.SetActive(true);
    }

    public void OnNextButton()
    {
        bool hasNext = _customer.NextDialogue();

        if (hasNext)
        {
            _dialogueText.text = _customer.GetCurrentDialogue();
        }
        else
        {
            _nextButton.gameObject.SetActive(false);

            // ここで会話終了
            // 後で種族選択を表示する
        }
    }

    public void OnSpeciesButton(int species)
    {
        Customer.Species selectedSpecies = (Customer.Species)species;

        Debug.Log("選択した種族：" + selectedSpecies);
    }
}
