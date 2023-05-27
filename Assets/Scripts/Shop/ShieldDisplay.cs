using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public Player Player;
    public ShieldData shieldData;
    public TextMeshProUGUI ShieldPrice;
    public TextMeshProUGUI BonusAttackRange;
    public Image ShieldSprite;
    public int ShieldID;

    public GameObject ShieldButton;
    public GameObject Content;

    private void Start()
    {
        CreateShield();
    }
    public void SelectShield()
    {
        Shield shield = (Shield)ShieldID;
        Player.ChangeShield(shield);
        PlayerPrefs.SetInt(ConstantClass.SavedShieldId, ShieldID);
        PlayerPrefs.Save();
        //CloseWeaponShop();
    }

    public void GetShieldID()
    {
        ShieldID = EventSystem.current.currentSelectedGameObject.GetComponent<ShieldItem>().ShieldID;
    }

    public void CreateShield()
    {
        for (int i = 1; i < shieldData.shields.Count; i++)
        {
            GameObject NewShieldButton = Instantiate(ShieldButton, Content.transform);
            NewShieldButton.GetComponent<ShieldItem>().DisplayShield(i);
        }
    }

    public TextMeshProUGUI CurrentCoinText;
    public int Price;
    public void Purchased()
    {
        
        Shield shield = (Shield)ShieldID;
        Price = shieldData.GetData(shield).Price;

        CoinManager.Ins.SubtractCoin(Price);
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);
    }

}
