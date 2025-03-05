using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using Mono.Cecil.Cil;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    private int coins = 0, oldCoins = 0, originalFontSize = 0;
    private double sizePercentage = 100;
    public double duration = 1;
    [SerializeField] private TextMeshProUGUI CoinText, ShadowText;

    private void Start()
    {
        originalFontSize = (int)CoinText.fontSize;
        StartCoroutine(UpdateCoinUI());
    }
    private void Update()
    {
        sizePercentage += .05 * (100 - sizePercentage);
        UpdateFontSize();
    }
    public void AddCoin(int amount)
    {
        coins += amount;

        StartCoroutine(UpdateCoinUI());
    }
    public IEnumerator UpdateCoinUI()
    {
        int steps = math.abs(coins - oldCoins);
        double lastTick = Time.realtimeSinceStartup, start = Time.realtimeSinceStartup;
        if (steps > 0)
        {
            for (int i = 0; i < steps; i++)
            {
                while ((Time.realtimeSinceStartup - lastTick) < (duration / steps))
                    yield return new WaitForEndOfFrame();

                UpdateText(oldCoins + i);
                lastTick = Time.realtimeSinceStartup;

                if ((Time.realtimeSinceStartup - start) > duration) break;
            }
        }
        UpdateText(coins);
        oldCoins = coins;
    }
    private void UpdateFontSize()
    {
        CoinText.fontSize = (float)(originalFontSize * (sizePercentage / 100));
        ShadowText.fontSize = (float)(originalFontSize * (sizePercentage / 100));
    }
    private void UpdateText(int value)
    {
        sizePercentage = 140;
        string count = string.Format("{0:000}", value);
        CoinText.text = "Coins: " + count;
        ShadowText.text = "Coins: " + count;
    }
}
