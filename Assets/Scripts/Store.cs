using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    float BaseStoreCost;
    //private float CurrentBalance;
    int StoreCount;
    public Text StoreCountText;
    public Slider ProgressSlider;
    private float StoreTimer = 4f;
    private float CurrentTimer = 0;
    private bool StartTimer;
    private float BaseStoreProfit;
    public gamemanager Gamemanager;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StoreCount = 1;
        BaseStoreCost = 1.50f;
        BaseStoreProfit = .50f;

        StartTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
        
            if (CurrentTimer > StoreTimer)
            {
                Debug.Log("Timer has ended.  Reset.");
                StartTimer = false;
                CurrentTimer = 0f;
                Gamemanager.AddToBalance(BaseStoreProfit * StoreCount);
                
            }
        }
        
        ProgressSlider.value = CurrentTimer / StoreTimer;
    }

    public void BuyStoreOnClick()
    {
        if (!Gamemanager.CanBuy(BaseStoreCost)) { return; }
        
        StoreCount++;
        Debug.Log(StoreCount);
        StoreCountText.text = StoreCount.ToString();
        Gamemanager.AddToBalance(-BaseStoreCost);
        
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
