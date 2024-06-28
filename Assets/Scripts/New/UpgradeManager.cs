using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private Inv invScript;
    private int potholeCost;
    private int tollCost;
    private int propertyCost;
    private UIManager uiScript;

    private void Start()
    {
        invScript = FindObjectOfType<Inv>();
        uiScript = FindObjectOfType<UIManager>();
        potholeCost = 50;
        tollCost = 150;
        propertyCost = 1000;
    }

    public void BuyUpgrade(string upgrade)
    {
        if(upgrade == "pothole" && invScript.currentMoney >= potholeCost)
        {
            invScript.tapAmount += 1;
            invScript.currentMoney -= potholeCost;
            potholeCost = Mathf.RoundToInt(potholeCost * 1.5f);
            uiScript.UpdateCost(uiScript.potholeCost, potholeCost);
        }

        if(upgrade == "toll" && invScript.currentMoney >= tollCost)
        {
            invScript.cps += 1;
            invScript.currentMoney -= tollCost;
            tollCost = Mathf.RoundToInt(tollCost * 1.5f);
            uiScript.UpdateCost(uiScript.tollCost, tollCost);
        }

        if(upgrade == "property" && invScript.currentMoney >= propertyCost)
        {
            invScript.cps += 10;
            invScript.currentMoney -= propertyCost;
            propertyCost = Mathf.RoundToInt(propertyCost * 1.5f);
            uiScript.UpdateCost(uiScript.propertyCost, propertyCost);
        }
    }
}
