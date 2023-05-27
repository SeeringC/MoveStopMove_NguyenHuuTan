using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public TextMeshProUGUI Rank;
    public TextMeshProUGUI CoinGained;
    public TextMeshProUGUI BotName;

    public void TouchToContinue()
    {
        Close(0);
        UIManager.Ins.OpenUI<MainMenu>(UIManager.UIID.MainMenu);
    }

    public void DisplayCoin()
    {
        CoinManager.Ins.PrintCoin(CoinManager.Ins.TotalKillCoin, CoinGained);
        CoinManager.Ins.AddCoin(CoinManager.Ins.TotalKillCoin);
    }

    public void DisplayKiller(string KillerName)
    {
        BotName.text = KillerName;
    }

}
