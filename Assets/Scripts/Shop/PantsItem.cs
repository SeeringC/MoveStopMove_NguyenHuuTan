using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PantsItem : MonoBehaviour
{
    PantsDisplay pantsDisplay;

    public int PantsID;
    public PantsData pantsData;
    //public TextMeshProUGUI PantsPrice;
    //public TextMeshProUGUI BonusAttackRange;
    public Image PantsSprite;

    public void SetParent(PantsDisplay pantsDisplay)
    {
        this.pantsDisplay = pantsDisplay;
    }

    public void DisplayPants(int ID)
    {
        Pants pants = (Pants)ID;

        PantsSprite.sprite = pantsData.GetData(pants).PantSprite;
        PantsID = ID;
    }
}
