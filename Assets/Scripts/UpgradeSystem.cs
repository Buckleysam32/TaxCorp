using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public ProgressBar progressBar;
    public Inventory playerInventory;

    public TextMeshProUGUI upgradeLevelText;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI addAmountText;
    public TextMeshProUGUI monkeyCostText;

    public float upgradeCost = 5;
    public float upgradeCostIncrease = 1.07f;
    public int upgradeIncrement = 1;
    private int currentUpgradeLevel = 1;

    public int monkeyCost = 50;

    public AudioSource upgradeSound;

    public LevelBar levelBar;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUpgradeTexts();
        if(gameObject.tag == "Banana")
        {
            upgradeCost = 5;
            upgradeCostIncrease = 1.07f;
            upgradeIncrement = 1;
        }
        if(gameObject.tag == "Tree")
        {
            upgradeCost = 69;
            upgradeCostIncrease = 1.15f;
            upgradeIncrement = 60;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has enough bananas to afford the next upgrade
        bool canAffordUpgrade = playerInventory.GetBananaCount("banana") >= upgradeCost;

        // Enable/disable the upgrade button based on whether the player can afford it
        GetComponent<Button>().interactable = canAffordUpgrade; 

        // Change the upgrade button text to reflect the upgrade cost
        upgradeCostText.text = "Upgrade: " + upgradeCost + " bananas";

        upgradeCost = Mathf.Round(upgradeCost * 100.0f) * 0.01f;
    }

    public void PurchaseUpgrade()
    {
        if(gameObject.tag == "Banana")
        {
            // Check if the player has enough bananas to afford the upgrade
            if (playerInventory.GetBananaCount("banana") >= upgradeCost)
            {
                // Deduct the upgrade cost from the player's bananas
                playerInventory.RemoveItem("banana", (int)upgradeCost);

                // Increment the banana reward and upgrade level
                currentUpgradeLevel++;

                // Increase the cost of the next upgrade
                upgradeCost *= upgradeCostIncrease;


                playerInventory.bananaAddAmount += 1;



                // Update the upgrade level and cost texts
                UpdateUpgradeTexts();

                upgradeSound.Play();
            }
        }

        if (gameObject.tag == "Tree")
        {
            // Check if the player has enough bananas to afford the upgrade
            if (playerInventory.GetBananaCount("banana") >= upgradeCost)
            {
                // Deduct the upgrade cost from the player's bananas
                playerInventory.RemoveItem("banana", (int)upgradeCost);

                // Increment the banana reward and upgrade level
                currentUpgradeLevel++;

                // Increase the cost of the next upgrade
                upgradeCost *= upgradeCostIncrease;


                playerInventory.treeAddAmount += 60;



                // Update the upgrade level and cost texts
                UpdateUpgradeTexts();

                upgradeSound.Play();
            }
        }

    }

    void UpdateUpgradeTexts()
    {
        if(gameObject.tag == "Banana")
        {
            // Update the upgrade level and cost texts
            upgradeLevelText.text = "Level: " + currentUpgradeLevel;
            upgradeCostText.text = "Cost: " + upgradeCost + " bananas";
            addAmountText.text = playerInventory.bananaAddAmount.ToString();
        }
        if (gameObject.tag == "Tree")
        {
            // Update the upgrade level and cost texts
            upgradeLevelText.text = "Level: " + currentUpgradeLevel;
            upgradeCostText.text = "Cost: " + upgradeCost + " bananas";
            addAmountText.text = playerInventory.treeAddAmount.ToString();
        }


    }
}
