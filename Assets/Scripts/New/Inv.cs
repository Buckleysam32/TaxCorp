using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    public int currentMoney;
    [SerializeField]
    private int tapAmount;
    private UIManager UIScript;

    private void Start()
    {
        UIScript = FindObjectOfType<UIManager>();
        tapAmount = 1;
    }

    public void AddMoney()
    {
        currentMoney += tapAmount;
        UIScript.UpdateText();
    }
}
