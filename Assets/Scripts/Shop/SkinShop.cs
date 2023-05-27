using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinShop : UICanvas
{
    public GameObject skinShop;
    public GameObject HairShop;
    public GameObject PantsShop;
    public GameObject ShieldShop;
    public TextMeshProUGUI CurrentCoinText;
    //public GameObject WeaponShopButton;
    public override void OnInit()
    {
        base.OnInit();
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);
    }
    public void OpenSkinShop()
    {
        skinShop.SetActive(true);
        HairShop.SetActive(true);
        ShieldShop.SetActive(false);
        PantsShop.SetActive(false);
        //WeaponShopButton.SetActive(false);
    }
    public void CloseSkinShop()
    {
        UIManager.Ins.OpenUI<MainMenu>(UIManager.UIID.MainMenu);
        Close(0);
        //skinShop.SetActive(false);
        //WeaponShopButton.SetActive(true);
    }

    public void OpenHairShop()
    {
        HairShop.SetActive(true);
        ShieldShop.SetActive(false);
        PantsShop.SetActive(false);
    }

    public void OpenPantsShop()
    {
        HairShop.SetActive(false);
        ShieldShop.SetActive(false);
        PantsShop.SetActive(true);
    }

    public void OpenShieldShop()
    {
        HairShop.SetActive(false);
        ShieldShop.SetActive(true);
        PantsShop.SetActive(false);
    }

}
