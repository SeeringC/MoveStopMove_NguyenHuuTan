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

    public void SelectHair()
    {
        Hair hair = (Hair)HairID;
        Player.ChangeHair(hair);

        PlayerPrefs.SetInt(ConstantClass.SAVED_HAIR_ID, HairID);
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

        Hair hair = (Hair)HairID;
        Price = hairData.GetData(hair).Price;

        CoinManager.Ins.SubtractCoin(Price);
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);
    }



}
