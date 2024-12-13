using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public static event Action<float> OnSpeedCollected;

    public float speedMultiplier = 2f;

    public void Collect()
    {
        OnSpeedCollected.Invoke(speedMultiplier);
        Destroy(gameObject);
    }
}
