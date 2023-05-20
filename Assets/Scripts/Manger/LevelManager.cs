using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int PlayerCoin;

    private void Start()
    {
        PlayerCoin = 1000;
        PlayerPrefs.SetInt("PlayerCoin", PlayerCoin);
    }
}
