using System;
using UnityEngine;

public class PlayerTap : DamageCause
{
    public DamageEffect damageEffect;
    
    [Header("VFX")]
    public GameObject damageVFX;
    private Camera _camera;
    
    // Reference to Sensor Component
    [SerializeField] private Sensor _sensor;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        if (_sensor != null)
        {
            //Debug.Log("PlayerTap: Subscribing to SensorTriggered.");
            // Referenziere Methode DamageCauseSignalDetected -> muss nicht Parameter einfügen
            _sensor.SensorTriggered += DamageCauseSignalDetected;  // fügt die Methode DamageCauseSignalDetected zur Liste der Methoden hinzu, die bei diesem Event ausgeführt werden
        }
        else
        {
            //Debug.LogError("PlayerTap: Sensor is NULL! Make sure the GameObject has a Sensor component.");
        }
    }
    

    private void OnDisable()
    {
        if (_sensor != null)
        {
            //Debug.Log("PlayerTap: Unsubscribing from SensorTriggered.");
            // Dereferenziere Methode DamageCauseSignalDetected
            _sensor.SensorTriggered -= DamageCauseSignalDetected;   // entfehrnt die Methode DamageCauseSignalDetected aus Liste der Methoden hinzu, die bei diesem Event ausgeführt werden
        }
    }

    public void DamageCauseSignalDetected(object sender, EventArgs args)
    {
        damageEffect.Trigger(this);
        
        if (args is SensorEventArgs && ((SensorEventArgs)args).associatedPointerPayload.position != null)
        {
            Vector3 pos = _camera.ScreenToWorldPoint(((SensorEventArgs)args).associatedPointerPayload.position);
            Instantiate(damageVFX, new Vector3(pos.x, pos.y, damageVFX.transform.position.z), Quaternion.identity);
        }
    }
}
