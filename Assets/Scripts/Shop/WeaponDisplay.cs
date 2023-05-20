using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
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
        OnInit();
    }
    public void OnInit()
    {
        WeaponIDToDisplay = 0;
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

    public int SavedWeaponID;

    public void SelectWeapon()
    {
        Weapon weapon = (Weapon)WeaponIDToDisplay;
        Player.ChangeWeapon(weapon);
        WeaponIDToDisplay = SavedWeaponID;
        PlayerPrefs.GetInt("SavedWeaponID", SavedWeaponID);
        PlayerPrefs.Save();

        CloseWeaponShop();

    }

    public TextMeshProUGUI CurrentCoinText;
    public int Price;
    public void Purchased()
    {
        int CurrentCoin = PlayerPrefs.GetInt("PlayerCoin");
        Weapon weapon = (Weapon)WeaponIDToDisplay;
        Price = weaponData.GetData(weapon).Price;

        if (CurrentCoin < Price) return;

        CurrentCoin -= Price;
        CurrentCoinText.text = Convert.ToString(CurrentCoin);
        PlayerPrefs.SetInt("PlayerCoin", CurrentCoin);
    }

    public GameObject Shop;
    public void OpenWeaponShop()
    {
        Shop.SetActive(true);
    }
    public void CloseWeaponShop()
    {
        Shop.SetActive(false);
    }


}
