using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public TextMeshProUGUI CurrentCoinText;

    public void SetCoin1000()
    {
        PlayerPrefs.SetInt("PlayerCoin", LevelManager.Ins.PlayerCoin);
    }

    public void PrintCoin()
    {
        int CurrentCoin = PlayerPrefs.GetInt("PlayerCoin");
        CurrentCoin += 1000;
        CurrentCoinText.text = Convert.ToString(CurrentCoin);
        PlayerPrefs.SetInt("PlayerCoin", CurrentCoin);

        Debug.Log(CurrentCoin);
    }
}
