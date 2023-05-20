using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldItem : MonoBehaviour
{
    public int ShieldID;
    public ShieldData shieldData;
    //public TextMeshProUGUI ShieldPrice;
    //public TextMeshProUGUI BonusAttackRange;
    public Image ShieldSprite;

    public void DisplayShield(int ID)
    {
        Shield shield = (Shield)ID;

        ShieldSprite.sprite = shieldData.GetData(shield).ShieldSprite;
        ShieldID = ID;
    }
}
