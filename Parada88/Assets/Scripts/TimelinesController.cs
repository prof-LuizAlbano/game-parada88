using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinesController : MonoBehaviour
{
    public List<PlayableDirector> timelines;
 
    public static int currentTimeline = 0;
 
    void Start()
    {
        PlayableDirector current = timelines[currentTimeline];
        Debug.Log("Playing timeline " + currentTimeline);
        current.Play();
    }
 
    void Update()
    {
     
    }
}
