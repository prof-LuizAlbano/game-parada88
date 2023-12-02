using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuPresenter : MonoBehaviour
{
    void Awake()
    {
		var root = GetComponent<UIDocument>().rootVisualElement;
		
		root.Q<Button>("Start").clicked += () => SceneManager.LoadScene("House");
		root.Q<Button>("Exit").clicked += () => Application.Quit();
		
        
    }
}
