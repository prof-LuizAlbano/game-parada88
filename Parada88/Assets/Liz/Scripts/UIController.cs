using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
	public ProgressBar oxygenProgressBar;
	public Label moneyText;
    // Start is called before the first frame update
    void Start()
    {
		var root = GetComponent<UIDocument>().rootVisualElement;
		
		oxygenProgressBar = root.Q<ProgressBar>("Oxigenio");
		moneyText = root.Q<Label>("Dinheiro");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
