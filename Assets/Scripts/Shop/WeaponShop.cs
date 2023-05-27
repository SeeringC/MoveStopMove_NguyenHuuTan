using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : UICanvas
{
    public Player Player;
    public WeaponData weaponData;
    public TextMeshProUGUI WeaponName;
    public TextMeshProUGUI WeaponPrice;
    public TextMeshProUGUI BonusAttackRange;
    public Image WeaponSprite;
    public int WeaponIDToDisplay;

    private void Start()
    {
        WeaponIDToDisplay = 0;
    }
    public override void OnInit()
    {
        base.OnInit();
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);
    }
    public void DisplayWeapon(int WeaponID)
    {
        Weapon weapon = (Weapon)WeaponIDToDisplay;

        //weapon = weaponData.GetDataByIndex(WeaponID);
        WeaponName.text = weaponData.GetData(weapon).WeaponName;
        BonusAttackRange.text = weaponData.GetData(weapon).BonusAttribute;
        WeaponPrice.text = Convert.ToString(weaponData.GetData(weapon).Price);
        WeaponSprite.sprite = weaponData.GetData(weapon).WeaponSprite;
    }
    
    public void ToLeft()
    {
        if (WeaponIDToDisplay > 0)
        {
            WeaponIDToDisplay--;
            DisplayWeapon(WeaponIDToDisplay);
        }
    }
        
    public void ToRight()
    {
        if (WeaponIDToDisplay < weaponData.weapons.Count - 1)
        {
            
            WeaponIDToDisplay++;
            DisplayWeapon(WeaponIDToDisplay);
        }

    }


    public void SelectWeapon()
    {
        Weapon weapon = (Weapon)WeaponIDToDisplay;
        Player.ChangeWeapon(weapon);
        PlayerPrefs.SetInt(ConstantClass.SavedWeaponId, WeaponIDToDisplay);
        PlayerPrefs.Save();

        CloseWeaponShop();

    }

    public TextMeshProUGUI CurrentCoinText;
    public int Price;
    public void Purchased()
    {
        Weapon weapon = (Weapon)WeaponIDToDisplay;
        Price = weaponData.GetData(weapon).Price;

        CoinManager.Ins.SubtractCoin(Price);
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);
    }

    public GameObject weaponShop;
    //public GameObject SkinShopButton;
    public void OpenWeaponShop()
    {
        weaponShop.SetActive(true);
        //SkinShopButton.SetActive(false);
    }
    public void CloseWeaponShop()
    {
        UIManager.Ins.OpenUI<MainMenu>(UIManager.UIID.MainMenu);
        Close(0);
        //weaponShop.SetActive(false);
        //SkinShopButton.SetActive(true);

    }


}
