using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : Singleton<CoinManager> 
{
    public int TotalKillCoin;
    public int CoinPerKill = 10;
    public void PrintCurrentCoin(TextMeshProUGUI Text)
    {
        int CurrentCoin = PlayerPrefs.GetInt(ConstantClass.PLAYER_COIN);
        Text.text = CurrentCoin.ToString();
    }
    public void PrintCoin(int CoinNumber, TextMeshProUGUI Text)
    {
        Text.text = CoinNumber.ToString();
    }

    public void AddCoin(int CoinNumber)
    {
        int CurrentCoin = PlayerPrefs.GetInt(ConstantClass.PLAYER_COIN);
        CurrentCoin += CoinNumber;
        PlayerPrefs.SetInt(ConstantClass.PLAYER_COIN, CurrentCoin);
        PlayerPrefs.Save();
    }

    public void SubtractCoin(int CoinNumber)
    {
        int CurrentCoin = PlayerPrefs.GetInt(ConstantClass.PLAYER_COIN);
        if (CurrentCoin < CoinNumber) return;

        CurrentCoin -= CoinNumber;
        PlayerPrefs.SetInt(ConstantClass.PLAYER_COIN, CurrentCoin);
        PlayerPrefs.Save();
    }

    public void ResetTotalKillCoin()
    {  
        TotalKillCoin = 0;
    }

    public void IncreaseTotalKillCoin()
    {
        TotalKillCoin += CoinPerKill;
    }
    
}
