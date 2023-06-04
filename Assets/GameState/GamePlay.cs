using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlay : UICanvas
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    public TextMeshProUGUI ActiveBot;
    public void WinButton()
    {
        UIManager.Ins.OpenUI<Win>(UIManager.UIID.Win).CoinGained.text = Random.Range(100, 200).ToString();
        Close(0);
    }

    public void LoseButton()
    {
        UIManager.Ins.OpenUI<Lose>(UIManager.UIID.Lose).CoinGained.text = Random.Range(0, 100).ToString(); 
        Close(0);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>(UIManager.UIID.MainMenu);
    }

    public void SetupOnOpen(Player player)
    {
        player.Setup(floatingJoystick);
    }

    public void DeactiveJoystick(Player player)
    {
        player.ResetJoyStick();
        floatingJoystick = null;
    }
}
