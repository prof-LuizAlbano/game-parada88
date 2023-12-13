using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuPresenter : MonoBehaviour
{
	
    void Start()
    {
		var root = GetComponent<UIDocument>().rootVisualElement;
	
		
		root.Q<Button>("Start").clicked += () => SceneManager.LoadScene("CutScene1");
		root.Q<Button>("Exit").clicked += () => Application.Quit();
		
		 var logo = root.Q<VisualElement>("LogoMove");
        logo.RegisterCallback<TransitionEndEvent>(evt => logo.ToggleInClassList("rotate"));
        root.schedule.Execute(() => logo.ToggleInClassList("rotate")).StartingIn(200);
		
		
		
        
    }
}
