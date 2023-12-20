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
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondsText;
    // Start is called before the first frame update
    void Start()
    {
        diamondsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory player)
    {
        diamondsText.text = player.diamondsCollected.ToString();
    }
}
