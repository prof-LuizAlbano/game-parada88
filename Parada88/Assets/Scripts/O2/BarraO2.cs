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
        if (barraO2.value > 0.99)
        {
            barraO2.fillRect.GetComponent<Image>().color = Color.blue;
        }
        else if (barraO2.value > 0.6)
        {
            barraO2.fillRect.GetComponent<Image>().color = Color.green;
        }
        else if (barraO2.value > 0.3)
        {
            barraO2.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            barraO2.fillRect.GetComponent<Image>().color = Color.red;
        }
    }

}
