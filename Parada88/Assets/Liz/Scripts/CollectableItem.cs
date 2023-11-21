using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectableItem : MonoBehaviour
{
	
	[SerializeField]
	private int value = 0; 
	
	[SerializeField]
	private CollectableType type; 
	
	public ProgressBar oxygenProgressBar;
	public Label moneyText;
	
	  // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
		
		var root = GetComponent<UIDocument>().rootVisualElement;
		
		oxygenProgressBar = root.Q<ProgressBar>("oxigenio");
		moneyText = root.Q<Label>("dinheiro");	

    }
	
	void OnTriggerEnter(Collider collider) {		
		if (collider.tag == "Player"){
			
			Debug.Log("entrei");
			
			var sum = int.Parse(moneyText.text) + value;
			
			switch(type){
				case CollectableType.Oxygen: {
					Debug.Log(Clamp(sum, 0, 100));
					oxygenProgressBar.value = Clamp(sum, 0, 100);
					break;
				}
				case CollectableType.Money:
				default:
				{			
					Debug.Log(sum.ToString());				
					moneyText.text = sum.ToString();
					break;
				}
			}
			
			//Destroy(gameObject);
		}
	}
	
	
  

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public static int Clamp( int value, int min, int max )
	{
		return (value < min) ? min : (value > max) ? max : value;
	}
}


public enum CollectableType {
	Money,
	Oxygen
}