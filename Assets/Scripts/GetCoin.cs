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
        PlayerPrefs.SetInt(ConstantClass.PLAYER_COIN, LevelManager.Ins.PlayerCoin);
    }

    public void Get1000Coin()
    {
        CurrentCoin = PlayerPrefs.GetInt(ConstantClass.PLAYER_COIN);
        CurrentCoin += 1000;
        CurrentCoinText.text = Convert.ToString(CurrentCoin);

    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt(ConstantClass.PLAYER_COIN, CurrentCoin);
        PlayerPrefs.Save();
    }

}
