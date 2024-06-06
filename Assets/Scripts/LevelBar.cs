using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelBar : MonoBehaviour
{
    public Button upgradeButton;
    public float maximumLevel = 26;
    public Image mask;

    public ProgressBar mainProgressBar; // Reference to the main progress bar script
    public float mainProgressBarFillSpeedMultiplier = 2f; // Fill speed multiplier when level 25 is reached

    private float currentLevel = 0;
    private float fillAmountPerUpgrade = 0.04f; // Fill 4% on each upgrade
    private bool isFilling = false;

    // Start is called before the first frame update
    void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeLevel);
        currentLevel = 0;
        GetCurrentFill();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFilling)
        {
            FillBar();
        }
    }

    void GetCurrentFill()
    {
        float fillAmount = currentLevel / maximumLevel;
        mask.fillAmount = fillAmount;
    }

    public void UpgradeLevel()
    {
        if (!isFilling && currentLevel < maximumLevel)
        {
            // Increment the current level by 4% of the maximum level
            currentLevel += maximumLevel * fillAmountPerUpgrade;

            // Ensure the current level does not exceed the maximum level
            currentLevel = Mathf.Min(currentLevel, maximumLevel);

            // Update the progress bar
            GetCurrentFill();
        }

        // Check if level 25 is reached, then empty the bar and multiply main progress bar fill speed
        if (currentLevel >= maximumLevel)
        {
            currentLevel = 0;
            GetCurrentFill();

            // Multiply the main progress bar fill speed by the multiplier
            mainProgressBar.fillSpeed *= mainProgressBarFillSpeedMultiplier;
        }
    }

    private void FillBar()
    {
        // Reset the filling flag to stop filling
        isFilling = false;
    }
}
