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
    public int diamondsCollected { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    public void DiamondCollected()
    {
        diamondsCollected++;
        OnDiamondCollected.Invoke(this);
    }
}
