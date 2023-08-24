using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    public static int coinCount;

    public TMP_Text coinText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.CoinPickupEvent += IncreaseCoins;
        coinCount = 0;
        coinText.text = "Coins: " + coinCount.ToString();
    }

    private void IncreaseCoins(int value)
    {
        EventManager.StartSFXEvent("CoinPickUp");
        //SoundController.Instance.PlaySFX("CoinPickUp");
        coinCount += value;
        coinText.text = "Coins: " + coinCount.ToString();
    }
    private void OnDisable()
    {
        EventManager.CoinPickupEvent -= IncreaseCoins;
    }
}
