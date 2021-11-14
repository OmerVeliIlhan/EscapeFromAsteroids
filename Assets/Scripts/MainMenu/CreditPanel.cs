using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel : MonoBehaviour
{ 
    public GameObject creditScreen;
    public void openPanel()
    {
        if(creditScreen != null)
        {
            creditScreen.SetActive(true);
        }
    }
    public void closePanel()
    {
        if(creditScreen != null)
        {
            creditScreen.SetActive(false);
        }
    }
}
