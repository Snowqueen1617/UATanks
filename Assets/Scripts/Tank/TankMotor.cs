using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach a tank motor component to a game object, check to see if it has a tank data and character controller
//If missing, will put the ones missing on that game object
[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(CharacterController))]

public class TankMotor : MonoBehaviour
{
    private TankData data;
    private CharacterController characterController;

    public void Start()
    {
        data = GetComponent<TankData>(); //look at the game object that it is attached to say our data is going to be the tank data component found on it 
        characterController = GetComponent<CharacterController>(); //catching and storing it so we dont have to keep calling get component
    }

    /// <summary>
    /// The Move method moves the tank.
    /// </summary>
    /// <param name="moveSpeed">Movement speed in meters per second</param>

    public void Move(float moveSpeed)
    {
        //Create a vector to hold our moveSpeed data
        //Start with the vector pointing the same direction as the GameObject this script is on
        //Now, instead of our vector being 1 units in length, apply our speed value
        Vector3 speedVector = transform.forward * moveSpeed;

        //Calll SimpleMove() and send it our vector
        //Note that SimpleMove() will apply Time.deltaTime and convert to meters per second for us!
        characterController.SimpleMove(speedVector);

    }

    public void Rotate(float rotateSpeed)
    {
        //Create a vector to hold our rotation data
        //Start by rotating right by one degree per frame draw. Left is just "negative right".
        //Adjust our rotation to be based on our speed
        //Transform.Rotate() doesnt account for speed, so we need to change our rotation to "per second" 
        //See the lecture on Timers for details on ho this works.
        Vector3 rotateVector = Vector3.up * rotateSpeed * Time.deltaTime;

        //Now, rotate our tank by this value - we want to rotate in our local space (not in world space)
        transform.Rotate(rotateVector, Space.Self);
    }
}
