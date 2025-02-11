using UnityEngine;
using System;
using R3;
using R3.Triggers;

public class TriggerEnter2DSensor : Sensor // inherits from abstract class Sensor
{
    private void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservableTrigger2DTrigger>()
            .OnTriggerEnter2DAsObservable()
            .Select(e => EventArgs.Empty);
    }
}