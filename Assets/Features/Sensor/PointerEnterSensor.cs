using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEnterSensor : Sensor, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        SensorEventArgs eventArgs = new SensorEventArgs(eventData);
        
        //  raise the SensorTriggered event whenever a PointerEnter event occurs.
        OnSensorTriggered(eventArgs);
    }
}
