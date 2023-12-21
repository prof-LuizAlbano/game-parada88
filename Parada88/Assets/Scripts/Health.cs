// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-12-12
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _minHealth;
    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if( _currentHealth < 1 )
        {
            Destroy(gameObject);
        }
    }
}
