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
 
	 
    void Awake()
    {
        TimelinesManager.currentTimeline = timeline;
        SceneManager.LoadScene(scenename);
    }
}