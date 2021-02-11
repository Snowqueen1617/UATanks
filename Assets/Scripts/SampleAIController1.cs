using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankShooter))]
[RequireComponent(typeof(TankMotor))]



public class SampleAIController1 : MonoBehaviour
{
    //TODO: We need a way to keep track of all the waypoints
    public GameObject[] waypoints;
    //We need a way to keep track of the current waypoint 
    private int currentWaypoint = 1;
    
    private TankData data;
    private TankMotor motor;
    private TankShooter shooter;

    public float closeEnough = 1f;



    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        //If we're not at the waypoint, turn to face it
        if (motor.RotateTowards(waypoints[currentWaypoint].transform.position, data.turnSpeed))
        {
            //Do nothing
        }
        //If we're facing  the waypoint, move towards it
        else
        {
            motor.Move(data.moveSpeed);
        }
        //If we've arrived at our waypoint, then go to the next one
        if(Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
        {
            currentWaypoint++;
        }
    }
}
