// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-12-17
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private float minMoneyColleted = 100f;
    [SerializeField] private float maxMoneyColleted = 350f;

    public float moneyAmount { get; private set; }

    public UnityEvent<PlayerInventory> OnMoneyCollected;

    public void MoneyCollected()
    {
        moneyAmount += Random.Range(minMoneyColleted, maxMoneyColleted);
        OnMoneyCollected.Invoke(this);
    }
}
