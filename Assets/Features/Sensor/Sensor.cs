using System;
using UnityEngine;
using R3;

public abstract class Sensor : MonoBehaviour
{
    // Subjekt ist Quelle von Events -> wird gesendet, wenn darauf subscribed
    private Subject<EventArgs> _sensorTriggered= new Subject<EventArgs>();

    // Andere können auf Subject subscriben
    public IDisposable Subscribe(R3.Observer<EventArgs> observer)
    {
        return _sensorTriggered.Subscribe(observer);
    }

    // Diese Methode löst das Triggern des Sensors aus
    protected virtual void OnSensorTriggered(EventArgs eventArgs)
    {
        // Verwendet den Subject-Mechanismus, um das Ereignis an alle Abonnenten zu senden
        _sensorTriggered.OnNext(eventArgs);
    }

    // Bereinigt und schließt Stream
    public void Dispose()
    {
        _sensorTriggered.OnCompleted();
        _sensorTriggered.Dispose();
    }
}