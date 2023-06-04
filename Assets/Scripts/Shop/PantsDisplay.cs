using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PantsDisplay : MonoBehaviour
{
    public Player Player;
    public PantsData pantsData;
    public TextMeshProUGUI PantsPrice;
    public TextMeshProUGUI BonusAttackRange;
    public Image PantsSprite;
    public int PantsID;

    public GameObject PantsButton;
    public GameObject Content;
    private void Start()
    {
        CreatePants();
    }
    public void SelectPants()
    {
        Pants pants = (Pants)PantsID;
        Player.ChangePants(pants);

        PlayerPrefs.GetInt(ConstantClass.SAVED_PANTS_ID, PantsID);
        PlayerPrefs.Save();

        //ClosePantsShop();
    }

    public void GetPantsID()
    {
        PantsID = EventSystem.current.currentSelectedGameObject.GetComponent<PantsItem>().PantsID;
    }

    public void CreatePants()
    {
        for (int i = 1; i < pantsData.PantsList.Count; i++)
        {
            GameObject NewPantsButton = Instantiate(PantsButton, Content.transform);
            NewPantsButton.GetComponent<PantsItem>().DisplayPants(i);
        }
    }

    public TextMeshProUGUI CurrentCoinText;
    public int Price;
    public void Purchased()
    {

        Pants pants = (Pants)PantsID;
        Price = pantsData.GetData(pants).Price;

        CoinManager.Ins.SubtractCoin(Price);
        CoinManager.Ins.PrintCurrentCoin(CurrentCoinText);
    }


}
