using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2 : MonoBehaviour
{
    private float atualO2;
    private int totalO2 = 1000;

    [SerializeField] private BarraO2 barraO2;
    // Start is called before the first frame update
    void Start()
    {
        atualO2 = totalO2;
        barraO2.alterarBarraO2(atualO2, totalO2);
    }

    // Update is called once per frame
    void Update()
    {
        atualO2 = atualO2 - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            atualO2 = atualO2 - 100;
            print(atualO2);
        }
        barraO2.alterarBarraO2(atualO2, totalO2);
    }
}
