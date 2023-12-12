using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class BarraO2 : MonoBehaviour
{
    
    [SerializeField] private Slider barraO2;
    [SerializeField] Transform PlayerCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + PlayerCam.forward);
    }

    public void alterarBarraO2(float atualO2,int totalO2)
    {
        barraO2.value = atualO2 / totalO2;
    }

}
