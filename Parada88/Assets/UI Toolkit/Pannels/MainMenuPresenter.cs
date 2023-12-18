using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuPresenter : MonoBehaviour
{
	
	private VisualElement root;
	private VisualElement mainMenuScreen;
	private VisualElement creditsScreen;
	
    void Start()
    {
		root = GetComponent<UIDocument>().rootVisualElement;
		
		mainMenuScreen = root.Q<VisualElement>("MainMenuScreen");
		creditsScreen = root.Q<VisualElement>("CreditsScreen");
	
		
		root.Q<Button>("Start").clicked += () => SceneManager.LoadScene("CutScene1");
		root.Q<Button>("Exit").clicked += () => Application.Quit();		
				
			
		setupLogoMove();		
		setupCreditsScreen();		
        
    }
	
	void setupLogoMove(){
		var logo = root.Q<VisualElement>("LogoMove");
        logo.RegisterCallback<TransitionEndEvent>(evt => logo.ToggleInClassList("rotate"));
        root.schedule.Execute(() => logo.ToggleInClassList("rotate")).StartingIn(200);
	}
	
	void setupCreditsScreen(){
		
		var creditsText = root.Q<VisualElement>("CreditsText");
        creditsText.RegisterCallback<TransitionEndEvent>(evt => {
			creditsText.RemoveFromClassList("scroll");
			creditsScreen.style.display = DisplayStyle.None;
			mainMenuScreen.style.display = DisplayStyle.Flex;
		});
		
		root.Q<Button>("Credits").clicked += () => {
			mainMenuScreen.style.display = DisplayStyle.None;
			creditsScreen.style.display = DisplayStyle.Flex;
			
			root.schedule.Execute(() => { creditsText.AddToClassList("scroll");}).StartingIn(200);
		};			
		
		
		
		
		
	}
}
