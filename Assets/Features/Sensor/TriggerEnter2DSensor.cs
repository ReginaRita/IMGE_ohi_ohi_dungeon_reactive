using UnityEngine;
using System;

public class TriggerEnter2DSensor : Sensor // inherits from abstract class Sensor
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"TriggerEnter2D detected on: {gameObject.name}, collided with: {other.gameObject.name}");
        
        OnSensorTriggered(EventArgs.Empty);
    }
}