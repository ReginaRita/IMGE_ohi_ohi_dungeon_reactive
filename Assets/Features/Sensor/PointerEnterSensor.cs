using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEnterSensor : Sensor
{
    private void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservablePointerEnterTrigger>()
            .OnPointerEnterAsObservable()
            .Select(e => new SensorEventArgs(e) as EventArgs);
    }
}
