using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public TextMeshProUGUI CurrentCoinText;
    public int CurrentCoin;
    public void SetCoin1000()
    {
        PlayerPrefs.SetInt(ConstantClass.PlayerCoin, LevelManager.Ins.PlayerCoin);
    }

    public void Get1000Coin()
    {
        CurrentCoin = PlayerPrefs.GetInt(ConstantClass.PlayerCoin);
        CurrentCoin += 1000;
        CurrentCoinText.text = Convert.ToString(CurrentCoin);

    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt(ConstantClass.PlayerCoin, CurrentCoin);
        PlayerPrefs.Save();
    }

}
