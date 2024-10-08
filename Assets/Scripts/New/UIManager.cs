using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI cpsText;
    private Inv inv;
    public UpgradeManager upgradeManager;

    public GameObject UpgradeMenu;

    public TextMeshProUGUI potholeCost;
    public TextMeshProUGUI potholeLvl;

    public TextMeshProUGUI tollCost;
    public TextMeshProUGUI tollLvl;

    public TextMeshProUGUI propertyCost;
    public TextMeshProUGUI propertyLvl;
    public GameObject propertyCover;

    public TextMeshProUGUI grogCost;
    public TextMeshProUGUI grogLvl;
    public GameObject grogCover;

    public TextMeshProUGUI corpCost;
    public TextMeshProUGUI corpLvl;
    public GameObject corpCover;

    public TextMeshProUGUI warCost;
    public TextMeshProUGUI warLvl;
    public GameObject warCover;

    private void Start()
    {
        inv = FindObjectOfType<Inv>();
        UpdateText();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        float cpsRound = Mathf.Round(inv.cps * 10f) * 0.1f;
        cpsText.text = "+" + NumberFormatter.FormatNumber(cpsRound) + "cps";
    }

    public void UpdateText()
    {
        int flooredMoney = Mathf.FloorToInt(inv.currentMoney);
        moneyText.text = "$" + NumberFormatter.FormatNumber(flooredMoney);
    }

    public void UpdateUpgrades(TextMeshProUGUI costText, int cost, TextMeshProUGUI levelText, int level)
    {
        costText.text = "$" + cost.ToString();
        levelText.text = "Level  " + level;
        UpdateText();
        if(upgradeManager.tollLvl > 1)
        {
            propertyCover.SetActive(false);
            upgradeManager.canProperty = true;
        }
        if (upgradeManager.propertyLvl > 1)
        {
            grogCover.SetActive(false);
            upgradeManager.canGrog = true;
        }
        if (upgradeManager.grogLvl > 1)
        {
            corpCover.SetActive(false);
            upgradeManager.canCorp = true;
        }
        if (upgradeManager.corpLvl > 1)
        {
            warCover.SetActive(false);
            upgradeManager.canWar = true;
        }
    }

}

public class NumberFormatter : MonoBehaviour
{
    public static string FormatNumber(float number)
    {
        if (number >= 1000000)
        {
            return (number / 1000000f).ToString("0.#") + "M"; 
        }
        else if (number >= 100000)
        {
            return (number / 1000f).ToString("0") + "K"; 
        }
        else if (number >= 10000)
        {
            return (number / 1000f).ToString("0.#") + "K"; 
        }
        else
        {
            return number.ToString(); 
        }
    }
}
