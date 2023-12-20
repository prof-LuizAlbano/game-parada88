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

public class Diamond : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if( playerInventory != null )
        {
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
            Invoke("ShowAgain", 5);
        }
    }

    void ShowAgain()
    {
        gameObject.SetActive(true);
    }
}
