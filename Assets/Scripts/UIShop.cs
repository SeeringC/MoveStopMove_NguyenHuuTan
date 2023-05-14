using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
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
