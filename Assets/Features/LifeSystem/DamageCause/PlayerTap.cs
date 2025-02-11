using System;
using R3;
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

    private void Start()
    {
        if (_sensor != null)
        {
            _sensor.SensorTriggered
                .Subscribe(DamageCauseSignalDetected)
                .AddTo(this);
        }
        else
        {
            Debug.LogError("PlayerTap: Sensor is NULL! Make sure the GameObject has a Sensor component.");
        }
    }
    
    public void DamageCauseSignalDetected(EventArgs args)
    {
        damageEffect.Trigger(this);
        
        if (args is SensorEventArgs && ((SensorEventArgs)args).associatedPointerPayload.position != null)
        {
            Vector3 pos = _camera.ScreenToWorldPoint(((SensorEventArgs)args).associatedPointerPayload.position);
            Instantiate(damageVFX, new Vector3(pos.x, pos.y, damageVFX.transform.position.z), Quaternion.identity);
        }
    }
}
