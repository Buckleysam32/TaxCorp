using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    public int currentMoney;
    public int tapAmount; //Amount earned each tap
    public float cps; //Amount earned each second 
    private float duration = 1.0f; //Time it takes for money to get added
    private UIManager UIScript;

    private void Start()
    {
        UIScript = FindObjectOfType<UIManager>();
        tapAmount = 1;
        StartCoroutine(AddCpsOverTime());
    }

    private void Update()
    {
        UIScript.UpdateText();
    }

    public void AddMoney()
    {
        currentMoney += tapAmount;
    }
    private IEnumerator AddCpsOverTime()
    {
        while (true)
        {
            float amountToAdd = (float)cps;
            float amountAdded = 0f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float deltaTime = Time.deltaTime;
                float increment = (amountToAdd / duration) * deltaTime;
                amountAdded += increment;
                currentMoney += Mathf.FloorToInt(amountAdded);
                amountAdded -= Mathf.FloorToInt(amountAdded);
                elapsedTime += deltaTime;

                yield return null; // Wait until the next frame
            }

            // Correct any rounding issues by adding any remaining amount
            currentMoney += Mathf.FloorToInt(amountAdded);
        }
    }
}
