using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private Inv inv;

    public TextMeshProUGUI potholeCost;
    public TextMeshProUGUI tollCost;

    private void Start()
    {
        inv = FindObjectOfType<Inv>();
        UpdateText();
    }

    public void UpdateText()
    {
        moneyText.text = inv.currentMoney.ToString();
    }

    public void UpdateCost(TextMeshProUGUI text, int cost)
    {
        text.text = "$" + cost.ToString();
        UpdateText();
    }

}
