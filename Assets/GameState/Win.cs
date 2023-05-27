using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public TextMeshProUGUI CoinGained;

    public void TouchToContinueButton()
    {
        UIManager.Ins.OpenUI<MainMenu>(UIManager.UIID.MainMenu);
        Close(0);
    }

    public void DisplayCoin()
    {
        CoinManager.Ins.PrintCoin(CoinManager.Ins.TotalKillCoin, CoinGained);
        CoinManager.Ins.AddCoin(CoinManager.Ins.TotalKillCoin);
    }
}
