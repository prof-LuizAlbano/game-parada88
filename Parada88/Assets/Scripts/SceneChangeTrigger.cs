using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
	[SerializeField]
	 public string scenename;
	
    void OnTriggerEnter(Collider collider){
		
		if (collider.tag == "Player"){
			SceneManager.LoadScene(scenename);
		}
	}
}