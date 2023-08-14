using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    public int coinCount;

    public TMP_Text coinText;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }

    public void IncreaseCoins(int amount)
    {
        coinCount += amount;
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
