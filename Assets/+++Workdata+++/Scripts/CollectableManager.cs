using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private int counterCoins = 0;
    [SerializeField] private UIManager uIManager;

    private void Start()
    {
        counterCoins = 0;
        uIManager.UpdateCoinText(counterCoins);
    }

    public void AddCoin()
    {
        counterCoins++;
        uIManager.UpdateCoinText(counterCoins);
    }
    public void AddDiamond()
    {
        counterCoins += 15;
        uIManager.UpdateCoinText(counterCoins);
    }
    // public int CalculateFinalScore(float remainingTime)
    // {
    //     int timeBonus = Mathf.CeilToInt(remainingTime) * 10; 
    //     return counterCoins + timeBonus;
    // }
}
