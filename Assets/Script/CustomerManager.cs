using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private Customer[] _customerPrefabs;
    [SerializeField] private Transform[] _customerPositions;
    [SerializeField] private int _maxCustomerCount = 5;

    private List<Customer> _customers = new List<Customer>();

    private void Awake()
    {
        // Å‰‚É—ñ‚ğ–ˆõ‚É‚·‚é
        for (int i = 0; i < _maxCustomerCount; i++)
        {
            CreateCustomer(i);
        }
    }

    // ƒ‰ƒ“ƒ_ƒ€‚È‹q‚ğ1l¶¬
    private void CreateCustomer(int index)
    {
        int randomIndex = Random.Range(0, _customerPrefabs.Length);

        Customer customer = Instantiate(
            _customerPrefabs[randomIndex],
            _customerPositions[index].position,
            _customerPositions[index].rotation
        );

        _customers.Add(customer);
    }

    // æ“ª‚Ì‹q‚ğ‘Î‰‚µ‚ÄAŸ‚Ì‹q‚ğ‹l‚ß‚é
    public void RemoveCustomer()
    {
        if (_customers.Count == 0)
        {
            return;
        }

        // æ“ª‚Ì‹q‚ğæ“¾
        Customer firstCustomer = _customers[0];

        // ƒŠƒXƒg‚©‚çíœ
        _customers.RemoveAt(0);

        // ‹q‚ğíœ
        Destroy(firstCustomer.gameObject);

        // c‚Á‚½‹q‚ğ1‚Â‘O‚É‹l‚ß‚é
        for (int i = 0; i < _customers.Count; i++)
        {
            _customers[i].transform.position = _customerPositions[i].position;
        }

        // ˆê”ÔŒã‚ë‚ÉV‚µ‚¢‹q‚ğ’Ç‰Á
        if (_customers.Count < _maxCustomerCount)
        {
            CreateCustomer(_customers.Count);
        }
    }

    // Œ»İæ“ª‚É‚¢‚é‹q‚ğæ“¾
    public Customer GetFrontCustomer()
    {
        if (_customers.Count == 0)
        {
            return null;
        }

        return _customers[0];
    }
}
