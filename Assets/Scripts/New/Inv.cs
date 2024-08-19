using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    public float currentMoney;
    public int tapAmount; // Amount earned each tap
    public float cps; // Amount earned each second 
    private float duration = 1.0f; // Time it takes for money to get added
    private UIManager UIScript;

    private void Start()
    {
        tapAmount = 1;
        UIScript = FindObjectOfType<UIManager>();
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
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float deltaTime = Time.deltaTime;
                float increment = (cps / duration) * deltaTime;
                currentMoney += increment;
                elapsedTime += deltaTime;

                yield return null; // Wait until the next frame
            }
        }
    }
}
