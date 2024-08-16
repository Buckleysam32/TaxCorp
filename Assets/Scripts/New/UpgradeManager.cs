using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private Inv invScript;
    private UIManager uiScript;

    public int potholeCost;
    public int potholeLvl;

    public int tollCost;
    public int tollLvl;
    private int[] tollCosts = { 3, 39, 50, 65, 85, 111, 144, 188, 244, 318 };

    public int propertyCost;
    public int propertyLvl;
    public bool canProperty;
    private int[] propertyCosts = { 100, 130, 169, 219, 285, 371, 482, 627, 815, 1060 };

    public int grogCost;
    public int grogLvl;
    public bool canGrog;
    private int[] grogCosts = { 1000, 1300, 1690, 2856, 3712, 4826, 6274, 8156, 10603, 13784 };

    public int corpCost;
    public int corpLvl;
    public bool canCorp;
    private int[] corpCosts = { 10000, 13000};

    public int warCost;
    public int warLvl;
    public bool canWar;
    private int[] warCosts = { 50000, 65000};

    private void Start()
    {
        invScript = FindObjectOfType<Inv>();
        uiScript = FindObjectOfType<UIManager>();
        potholeLvl = 0;
        potholeCost = 50;
        tollLvl = 0;
        tollCost = 3;
        propertyLvl = 0;
        propertyCost = 100;
        grogLvl = 0;
        grogCost = 1000;
        corpLvl = 0;
        corpCost = 10000;
        warLvl = 0;
        warCost = 50000;
        canProperty = false;
        canGrog = false;
        canCorp = false;
        canWar = false;
    }

    public void BuyUpgrade(string upgrade)
    {
        if(upgrade == "pothole" && invScript.currentMoney >= potholeCost)
        {
            invScript.tapAmount += 1;
            invScript.currentMoney -= potholeCost;
            potholeCost = Mathf.RoundToInt(potholeCost * 1.5f);
            potholeLvl += 1;
            uiScript.UpdateUpgrades(uiScript.potholeCost, potholeCost, uiScript.potholeLvl, potholeLvl);
            FindObjectOfType<GameManager>().SaveGame();
        }

        if (upgrade == "toll" && invScript.currentMoney >= tollCost)
        {
            invScript.cps += 0.1f;
            invScript.currentMoney -= tollCost;
            tollLvl += 1;

            if (tollLvl < tollCosts.Length)
            {
                tollCost = tollCosts[tollLvl];
            }
            else
            {
                tollCost = Mathf.RoundToInt(tollCosts[tollCosts.Length - 1] * 1.3f);
            }

            uiScript.UpdateUpgrades(uiScript.tollCost, tollCost, uiScript.tollLvl, tollLvl);
            FindObjectOfType<GameManager>().SaveGame();
        }

        if (upgrade == "property" && invScript.currentMoney >= propertyCost && canProperty)
        {
            invScript.cps += 0.3f;
            invScript.currentMoney -= propertyCost;
            propertyLvl += 1;

            if (propertyLvl < propertyCosts.Length)
            {
                propertyCost = propertyCosts[propertyLvl];
            }
            else
            {
                tollCost = Mathf.RoundToInt(propertyCosts[propertyCosts.Length - 1] * 1.3f);
            }

            uiScript.UpdateUpgrades(uiScript.propertyCost, propertyCost, uiScript.propertyLvl, propertyLvl);
            FindObjectOfType<GameManager>().SaveGame();
        }

        if (upgrade == "grog" && invScript.currentMoney >= grogCost && canGrog)
        {
            invScript.cps += 1f;
            invScript.currentMoney -= grogCost;
            grogLvl += 1;

            if (grogLvl < grogCosts.Length)
            {
                grogCost = grogCosts[grogLvl];
            }
            else
            {
                tollCost = Mathf.RoundToInt(grogCosts[grogCosts.Length - 1] * 1.3f);
            }

            uiScript.UpdateUpgrades(uiScript.grogCost, grogCost, uiScript.grogLvl, grogLvl);
            FindObjectOfType<GameManager>().SaveGame();
        }

        if (upgrade == "corp" && invScript.currentMoney >= corpCost && canCorp)
        {
            invScript.cps += 3.1f;
            invScript.currentMoney -= corpCost;
            corpLvl += 1;

            if (corpLvl < corpCosts.Length)
            {
                corpCost = corpCosts[corpLvl];
            }
            else
            {
                corpCost = Mathf.RoundToInt(corpCosts[corpCosts.Length - 1] * 1.3f);
            }

            uiScript.UpdateUpgrades(uiScript.corpCost, corpCost, uiScript.corpLvl, corpLvl);
            FindObjectOfType<GameManager>().SaveGame();
        }

        if (upgrade == "war" && invScript.currentMoney >= warCost && canWar)
        {
            invScript.cps += 6f;
            invScript.currentMoney -= warCost;
            warLvl += 1;

            if (warLvl < warCosts.Length)
            {
                warCost = warCosts[warLvl];
            }
            else
            {
                warCost = Mathf.RoundToInt(warCosts[warCosts.Length - 1] * 1.3f);
            }

            uiScript.UpdateUpgrades(uiScript.warCost, warCost, uiScript.warLvl, warLvl);
            FindObjectOfType<GameManager>().SaveGame();
        }
    }
}
