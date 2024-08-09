using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Drone : MonoBehaviour
{
    [SerializeField]
    private GameObject dronePrefab;

    [SerializeField]
    private GameObject droneMenu;

    public Animator myAnim;

    private ButtonManger myButtonManger;
    private Inv inv;
    private float winAmount;
    public TextMeshProUGUI amountText;
    public GameObject upgradeButton;
    public bool debugMode = false;
    private float ogCPS;
    private int ogTap;

    private bool isBoost;

    public GameObject boostIcon;

    private void Start()
    {
        StartCoroutine(SpawnDrone());
        myButtonManger = FindObjectOfType<ButtonManger>();
        inv = FindObjectOfType<Inv>();
    }

    IEnumerator SpawnDrone()
    {
        myAnim.SetTrigger("Idle");
        float spawnTime;
        if (debugMode)
        {
            spawnTime = 5f;
        }
        else
        {
            spawnTime = Random.Range(30f, 120f);
        }
        Debug.Log(spawnTime);
        yield return new WaitForSeconds(spawnTime);
        myAnim.SetTrigger("Fly");
    }

    public void OpenDrone()
    {
        dronePrefab.SetActive(false);
        myAnim.SetTrigger("Idle");
        droneMenu.SetActive(true);
        upgradeButton.SetActive(false);
        myButtonManger.canTap = false;
        dronePrefab.SetActive(true);
        StartCoroutine(SpawnDrone());
        int prize = Random.Range(1, 5);
        if (debugMode)
        {
            prize = 4;
        }
        if (prize == 1)  
        {
            if(inv.currentMoney <= 10)
            {
                winAmount = 10f;
            }
            else
            {
                winAmount = inv.currentMoney * 0.10f;
            }
            amountText.text = "$" + Mathf.FloorToInt(winAmount).ToString();
            inv.currentMoney += winAmount;
        }
        if (prize == 2)
        {
            if (inv.currentMoney <= 10)
            {
                winAmount = 10f;
            }
            else
            {
                winAmount = inv.currentMoney * 0.20f;
            }
            amountText.text = "$" + Mathf.FloorToInt(winAmount).ToString(); inv.currentMoney += winAmount;
            inv.currentMoney += winAmount;
        }
        if (prize == 3)
        {
            if (inv.currentMoney <= 10)
            {
                winAmount = 10f;
            }
            else
            {
                winAmount = inv.currentMoney * 0.40f;
            }
            amountText.text = "$" + Mathf.FloorToInt(winAmount).ToString(); inv.currentMoney += winAmount;
            inv.currentMoney += winAmount;
        }
        if (prize == 4)
        {
            StartCoroutine(MoneyBoost());
            amountText.text = "2x Boost!";
        }

        myAnim.SetTrigger("Idle");

    }
    
    IEnumerator MoneyBoost()
    {
        ogCPS = inv.cps; // Store cps
        ogTap = inv.tapAmount;
        inv.tapAmount *= 2;
        inv.cps *= 2;
        boostIcon.SetActive(true);
        yield return new WaitForSeconds(30f);
        inv.tapAmount = ogTap;
        boostIcon.SetActive(false);
        inv.cps = ogCPS;
    }

}
