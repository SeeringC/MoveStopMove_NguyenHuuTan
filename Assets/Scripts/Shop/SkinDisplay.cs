using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDisplay : MonoBehaviour
{
    public GameObject SkinShop;
    public GameObject HairShop;
    public GameObject PantsShop;
    public GameObject ShieldShop;
    public void OpenSkinShop()
    {
        SkinShop.SetActive(true);
        HairShop.SetActive(true);
        ShieldShop.SetActive(false);
        PantsShop.SetActive(false);
    }
    public void CloseSkinShop()
    {
        SkinShop.SetActive(false);
    }

    public void OpenHairShop()
    {
        HairShop.SetActive(true);
        ShieldShop.SetActive(false);
        PantsShop.SetActive(false);
    }

    public void OpenPantsShop()
    {
        HairShop.SetActive(false);
        ShieldShop.SetActive(false);
        PantsShop.SetActive(true);
    }

    public void OpenShieldShop()
    {
        HairShop.SetActive(false);
        ShieldShop.SetActive(true);
        PantsShop.SetActive(false);
    }

}
