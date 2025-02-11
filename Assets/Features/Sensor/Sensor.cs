using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public abstract class Sensor : MonoBehaviour
{
    public R3.Observable<EventArgs> SensorTriggered;
}