using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private Inv inv;

    private void Start()
    {
        inv = FindObjectOfType<Inv>();
        UpdateText();
    }

    public void UpdateText()
    {
        moneyText.text = inv.currentMoney.ToString();
    }

}
