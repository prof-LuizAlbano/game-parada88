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

public class MoneyCollectable : MonoBehaviour
{
    [SerializeField] private int minInterval = 5;
    [SerializeField] private int maxInterval = 5;
    
    void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if( playerInventory != null )
        {
            playerInventory.MoneyCollected();
            gameObject.SetActive(false);
            Invoke("ShowAgain", Random.Range(minInterval, maxInterval));
        }
    }

    void ShowAgain()
    {
        gameObject.SetActive(true);
    }
}
