using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> CoinPickupEvent;
    public static event Action DeathEvent;
    public static void StartCoinPickupEvent(int value)
    {
        CoinPickupEvent?.Invoke(value);
    }
    public static void StartDeathEvent()
    {
        DeathEvent?.Invoke();
    }
}
