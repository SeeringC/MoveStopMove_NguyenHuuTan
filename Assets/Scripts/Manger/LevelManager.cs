using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int PlayerCoin;
    public TextMeshProUGUI PlayerCoinText;
    public TextMeshProUGUI ActiveBot;

    private void Start()
    {
        //PlayerPrefs.SetInt("PlayerCoin", PlayerCoin);
        PlayerCoin = PlayerPrefs.GetInt(ConstantClass.PlayerCoin);
        //PlayerCoinText.text = Convert.ToString(PlayerCoin);
    }

    public void ChangeActiveBot(int RemainingBot)
    {
        if (RemainingBot == 0)
        {
            UIManager.Ins.OpenUI<Win>(UIManager.UIID.Win).DisplayCoin();

            //CLosing Bug Here
            UIManager.Ins.CloseUI<GamePlay>(UIManager.UIID.GamePlay);
        }
        UIManager.Ins.GetUI<GamePlay>(UIManager.UIID.GamePlay).ActiveBot.text = Convert.ToString(RemainingBot);
    }

    public void LoseBy(string BotName)
    {
        UIManager.Ins.OpenUI<Lose>(UIManager.UIID.Lose);
        UIManager.Ins.GetUI<Lose>(UIManager.UIID.Lose).Rank.text = "#" + Convert.ToString(Map.Ins.AliveBotNumber);
        UIManager.Ins.GetUI<Lose>(UIManager.UIID.Lose).DisplayCoin();
        UIManager.Ins.GetUI<Lose>(UIManager.UIID.Lose).DisplayKiller(BotName);
    }

    

}
