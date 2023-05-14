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
        Debug.Log("displayed");
        Weapon weapon = (Weapon)WeaponIDToDisplay;

        //weapon = weaponData.GetDataByIndex(WeaponID);
        WeaponName.text = weaponData.GetData(weapon).WeaponName;
        BonusAttackRange.text = "% Range" + Convert.ToString(weaponData.GetData(weapon).AttackRangeBonus);
        WeaponPrice.text = Convert.ToString(weaponData.GetData(weapon).Price);
        WeaponSprite.sprite = weaponData.GetData(weapon).WeaponSprite;
    }
    
    public void ToLeft()
    {
        Debug.Log("clicked");
        WeaponIDToDisplay--;
        if (WeaponIDToDisplay < 0) return;
        Debug.Log("passed");

        DisplayWeapon(WeaponIDToDisplay);
        
    }
        
    public void ToRight()
    {
        Debug.Log("clicked");
        Debug.Log("current id is: " + WeaponIDToDisplay);
        Debug.Log("size is: " + weaponData.weapons.Count);
        WeaponIDToDisplay++;
        if (WeaponIDToDisplay > weaponData.weapons.Count) return;
        Debug.Log("passed");
        
        DisplayWeapon(WeaponIDToDisplay);
    }

    public void SelectWeapon()
    {
        Weapon weapon = (Weapon)WeaponIDToDisplay;
        Player.ChangeWeapon(weapon);
        CloseShop();
    }
    public GameObject Shop;
    public void OpenShop()
    {
        Shop.SetActive(true);
    }
    public void CloseShop()
    {
        Shop.SetActive(false);
    }


}
