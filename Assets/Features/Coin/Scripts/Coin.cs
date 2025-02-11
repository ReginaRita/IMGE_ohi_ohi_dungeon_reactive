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

    private void Start()
    {
        if (_sensor != null)
        {
            _sensor.SensorTriggered
                .Subscribe(CollectSignalDetected)
                .AddTo(this);
        }
        else
        {
            Debug.LogError("PlayerTap: Sensor is NULL! Make sure the GameObject has a Sensor component.");
        }
    }

    public void CollectSignalDetected(EventArgs args)
    {
        // Call Collect
        Collect();
        
        gameObject.SetActive(false); // deactivates the GameObject of the referenced Sensor componen
    }
    
    public void Collect()
    {
        GameData.Instance.IncreaseScore(value);
        animationController.PlayCollectedAnimation();
        Destroy(gameObject, 3.0f);
    }
}