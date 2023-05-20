using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HairDisplay : MonoBehaviour
{
    public Player Player;
    public HairData hairData;
    public TextMeshProUGUI HairPrice;
    public TextMeshProUGUI BonusAttackRange;
    public Image HairSprite;
    public int HairID;

    public GameObject HairButton;
    public GameObject Content;

    private void Start()
    {
        CreateHair();
    }

    public int SavedHairID;
    public void SelectHair()
    {
        Hair hair = (Hair)HairID;
        Player.ChangeHair(hair);

        HairID = SavedHairID;
        PlayerPrefs.GetInt("SavedHairID", SavedHairID);
        PlayerPrefs.Save();

        //CloseWeaponShop();
    }

    public void GetHairID()
    {
        HairID = EventSystem.current.currentSelectedGameObject.GetComponent<HairItem>().HairID;
    }

    public void CreateHair()
    {
        for (int i = 1; i < hairData.hairs.Count; i++)
        {
            GameObject NewHairButton = Instantiate(HairButton, Content.transform);
            NewHairButton.GetComponent<HairItem>().DisplayHair(i);
        }
    }

    public TextMeshProUGUI CurrentCoinText;
    public int Price;
    public void Purchased()
    {
        int CurrentCoin = PlayerPrefs.GetInt("PlayerCoin");
        Hair hair = (Hair)HairID;
        Price = hairData.GetData(hair).Price;

        if (CurrentCoin < Price) return;

        CurrentCoin -= Price;
        CurrentCoinText.text = Convert.ToString(CurrentCoin);
        PlayerPrefs.SetInt("PlayerCoin", CurrentCoin);
    }



}
