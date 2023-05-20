using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairItem : MonoBehaviour
{
    public int HairID;
    public HairData hairData;
    //public TextMeshProUGUI HairPrice;
    //public TextMeshProUGUI BonusAttackRange;
    public Image HairSprite;

    public void DisplayHair(int ID)
    {
        Hair hair = (Hair)ID;

        HairSprite.sprite = hairData.GetData(hair).HairSprite;
        HairID = ID;
    }
}
