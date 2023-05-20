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

    public int SavedShieldID;
    public void SelectShield()
    {
        Shield shield = (Shield)ShieldID;
        Player.ChangeShield(shield);

        ShieldID = SavedShieldID;
        PlayerPrefs.GetInt("SavedShieldID", SavedShieldID);
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
        int CurrentCoin = PlayerPrefs.GetInt("PlayerCoin");
        Shield shield = (Shield)ShieldID;
        Price = shieldData.GetData(shield).Price;

        if (CurrentCoin < Price) return;

        CurrentCoin -= Price;
        CurrentCoinText.text = Convert.ToString(CurrentCoin);
        PlayerPrefs.SetInt("PlayerCoin", CurrentCoin);
    }

}
