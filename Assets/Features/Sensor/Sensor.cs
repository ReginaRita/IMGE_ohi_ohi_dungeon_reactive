using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    //  Define the event using EventHandler<TEventArgs>; event -> it is an event; EventHandler<EventArgs> -> delegate: contains source of Event and further event information (args)
    public event EventHandler<EventArgs> SensorTriggered; // public so everyone can subscribe for SensorTriggered

    protected virtual void OnSensorTriggered(EventArgs eventArgs) // virtual: other classes can override, but don't have to implement (Sensor implements default functionality)
    {
        // Invokes event if triggered with specific arguments
        SensorTriggered?.Invoke(this, eventArgs);
    }
}
