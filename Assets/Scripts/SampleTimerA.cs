using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTimerA : MonoBehaviour
{
    public float timeToWait = 1.0f; //in seconds
    private float nextEvent; //When our timer ends, time in the future

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        nextEvent = Time.time + timeToWait; //Number of seconds in the future when we want to do something. 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextEvent)
        {
            Debug.Log("The timer has run out");
            ResetTimer();
        }
    }
}
