using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Button fillButton;
    public float maximum;
    public float current;
    public Image mask;
    public float fillSpeed = 20f; // Adjust the fill speed as needed
    public UpgradeSystem upgradeSystem;

    public Inventory inventory;

    private bool isFilling = false;


    // Start is called before the first frame update
    void Start()
    {
        fillButton.onClick.AddListener(FillBar);
        current = 0;
        if(gameObject.tag == "Banana")
        {
            fillSpeed = 25f;
        }
        if(gameObject.tag == "Tree")
        {
            fillSpeed = 15f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        // if theres a monkey auto fill bar
        if(inventory.monkey > 0)
        {
            FillBar();
        }
    }

    void GetCurrentFill()
    {
        float fillAmount = current / maximum;
        mask.fillAmount = fillAmount;
    }

    public void FillBar()
    {
        // Only start filling if the current value is less than the maximum and not already filling
        if (current < maximum && !isFilling)
        {
            isFilling = true;
            StartCoroutine(FillBarCoroutine());
        }
    }

    private System.Collections.IEnumerator FillBarCoroutine()
    {
        while (current < maximum)
        {
            // Increment the current value over time until it reaches the maximum
            current += Time.deltaTime * fillSpeed;
            yield return null;
        }

        // After the loop, set the current value to the maximum to ensure it's not above 100%
        current = maximum;

        // Reset the isFilling flag to allow filling again in the future
        isFilling = false;

        if(gameObject.tag == "Banana")
        {
            inventory.AddBananaB();
        }

        if (gameObject.tag == "Tree")
        {
            inventory.AddTreeB();
        }

        // Reset the progress bar to 0%
        ResetBar();
    }

    public void ResetBar()
    {
        current = 0;
    }

}

