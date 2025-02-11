using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDownSensor : Sensor, IPointerDownHandler
{
    // Interface IPointerDownHandler requires OnPointerDown(PointerEventData) function
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        // SensorEventArgs object with the PointerEventData as parameter. (This is used for the explosions.)
        SensorEventArgs eventArgs = new SensorEventArgs(pointerEventData);
        
        // Raises Sensor Triggered event with pointerEventData -> special information
        OnSensorTriggered(eventArgs);
    }
}
