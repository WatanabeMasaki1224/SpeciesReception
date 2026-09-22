using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button _nextButton;
    [SerializeField] private CustomerManager _customerManager;
    private Customer _customer;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private GameObject _speciesButtons;

    public void Start()
    {
        _customer = _customerManager.GetFrontCustomer();
        StartDialogue(_customer);
    }

    public void StartDialogue(Customer customer)
    {
        _customer = customer;
        _dialogueText.text = _customer.GetCurrentDialogue();
        _nextButton.gameObject.SetActive(true);
        _speciesButtons.SetActive(true);
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

        if (selectedSpecies == _customer.GetSpecies())
        {
            Debug.Log("正解");
            _scoreManager.AddScore();
            
        }
        else
        {
            Debug.Log("不正解");
            _scoreManager.ResetCombo();
        }
        _speciesButtons.SetActive(false);
        NextCustomer();
    }

    private void NextCustomer()
    {
        _customerManager.RemoveCustomer();
        // 新しく先頭になった客を取得
        _customer = _customerManager.GetFrontCustomer();
        // 次の客の会話を開始
        StartDialogue(_customer);
    }
}
