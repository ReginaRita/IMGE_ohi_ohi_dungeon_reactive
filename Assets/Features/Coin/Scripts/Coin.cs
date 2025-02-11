using System;
using R3;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinAnimationController animationController;
    public int value = 1;

    // Reference to Sensor
    [SerializeField] private Sensor _sensor;
    
    private void Awake()
    {
        animationController.PlaySpawnAnimation();
    }
    
    private void OnEnable()
    {
        if (_sensor != null)
        {
            //Debug.Log("PlayerTap: Subscribing to SensorTriggered.");
            // Referenziere Methode CollectSignalDetected -> muss nicht Parameter einfügen
            _sensor.SensorTriggered += CollectSignalDetected;  // fügt die Methode CollectSignalDetected zur Liste der Methoden hinzu, die bei diesem Event ausgeführt werden
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
            // Dereferenziere Methode CollectSignalDetected
            _sensor.SensorTriggered -= CollectSignalDetected;   // entfehrnt die Methode CollectSignalDetected aus Liste der Methoden hinzu, die bei diesem Event ausgeführt werden
        }
    }

    public void CollectSignalDetected(object sender, EventArgs args)
    {
        // Call Collect
        Collect();
        
        gameObject.SetActive(false); // deactivates the GameObject of the referenced Sensor componen

        if (_sensor != null)
        {   
            // Unsubscribe from the event after collecting the coin -> coin is already collected/can't be collected twice
            _sensor.SensorTriggered -= CollectSignalDetected;
        }
    }
    
    public void Collect()
    {
        GameData.Instance.IncreaseScore(value);
        animationController.PlayCollectedAnimation();
        Destroy(gameObject, 3.0f);
    }
}