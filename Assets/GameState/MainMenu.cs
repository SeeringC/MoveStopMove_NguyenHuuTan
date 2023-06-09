using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : UICanvas
{
    public Player Player;
    public void PlayButton()
    {
        Time.timeScale = 1f;
        Player = GameObject.FindGameObjectWithTag(ConstantClass.TAG_PLAYER).GetComponent<Player>();
        Player.OnInit();
        //Player.missionWaypoint.CharNameText.text = PlayerPrefs.GetString("PlayerPref");
        UIManager.Ins.OpenUI<GamePlay>(UIManager.UIID.GamePlay).SetupOnOpen(GameManager.Ins.Player);
        Close(0);
    }
    public override void OnInit()
    {
        base.OnInit();
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);

    }
    public void OpenWeaponShopButton()
    {
        UIManager.Ins.OpenUI<WeaponShop>(UIManager.UIID.WeaponShop).OnInit();
        Close(0);
    }
    public void OpenSkinShopButton()
    {
        UIManager.Ins.OpenUI<SkinShop>(UIManager.UIID.SkinShop).OnInit();
        Close(0);
    }

    public TextMeshProUGUI CurrentCoinText;
    public int CurrentCoin;
    public TMP_InputField PlayerName;
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

    public void SaveName()
    {
        PlayerPrefs.SetString(ConstantClass.PLAYER_NAME, PlayerName.text);
        PlayerPrefs.Save();
    }


}
