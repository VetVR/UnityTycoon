using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    float BaseStoreCost;
    private float CurrentBalance;
    int StoreCount;
    public Text StoreCountText;
    public Text CurrentBalanceText;
    private float StoreTimer = 4f;
    private float CurrentTimer = 0;
    private bool StartTimer;
    private float BaseStoreProfit;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StoreCount = 1;
        CurrentBalance = 6.00f;
        BaseStoreCost = 1.50f;
        BaseStoreProfit = .50f;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
        StartTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
        }

        if (CurrentTimer > StoreTimer)
        {
            Debug.Log("Timer has ended.  Reset.");
            StartTimer = false;
            CurrentTimer = 0f;
            CurrentBalance += BaseStoreProfit * StoreCount;
            CurrentBalanceText.text = CurrentBalance.ToString("C2");
        }
    }

    public void BuyStoreOnClick()
    {
        if (BaseStoreCost > CurrentBalance) { return; }
        
        StoreCount++;
        Debug.Log(StoreCount);
        StoreCountText.text = StoreCount.ToString();
        CurrentBalance = CurrentBalance - BaseStoreCost;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
        Debug.Log(CurrentBalance);
    }

    public void StoreOnClick()
    {
        if (!StartTimer)
        {
            StartTimer = true;
            Debug.Log("Store button clicked.");
        } 
    }
}
