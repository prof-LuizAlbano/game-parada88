using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	 public string scenename;
	 
    void Awake()
    {
        SceneManager.LoadScene(scenename);
    }
}