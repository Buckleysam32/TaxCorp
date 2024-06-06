using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public ProgressBar progressBar;
    public Inventory playerInventory;

    public GameObject monkeyButton;

    public TextMeshProUGUI monkeyCostText;

    public int monkeyCost = 50;

    private void Start()
    {
        if(gameObject.tag == "Banana")
        {
            monkeyCost = 1000;
        }

        if (gameObject.tag == "Tree")
        {
            monkeyCost = 15000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool canAffordMonkey = playerInventory.GetBananaCount("banana") >= monkeyCost;

        monkeyCostText.text = "Buy Monkey: " + monkeyCost;

        GetComponent<Button>().interactable = canAffordMonkey;
    }

    public void PurchaseMonkey()
    {
        if (playerInventory.GetBananaCount("banana") >= monkeyCost)
        {
            playerInventory.RemoveItem("banana", (int)monkeyCost);
            playerInventory.AddMonkey();
            monkeyButton.SetActive(false);
        }
    }
}
