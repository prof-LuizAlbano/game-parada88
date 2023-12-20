using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	 public string scenename;

    [SerializeField]
	 public int timeline = 0;

    [SerializeField]
	 public bool resetCursor = false;
 
	 
    void Awake()
    {
        if (resetCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        TimelinesController.currentTimeline = timeline;
        SceneManager.LoadScene(scenename);
    }
}