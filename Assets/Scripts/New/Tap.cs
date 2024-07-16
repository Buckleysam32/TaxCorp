using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    private Animator myAnim;
    private Inv inv;
    public GameObject money1;
    public GameObject money2;
    public GameObject money3;
    private AudioManager audioManager;
    private ButtonManger buttonManger;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        inv = FindObjectOfType<Inv>();
        audioManager = FindObjectOfType<AudioManager>();
        buttonManger = FindObjectOfType<ButtonManger>();
    }

    private void OnMouseDown()
    {
        if (buttonManger.canTap)
        {
            myAnim.SetTrigger("Tap");
            inv.AddMoney();
            MoneyAnim();
            audioManager.TapAudio();
        }
    }

    private void MoneyAnim()
    {
        int number;
        number = Random.Range(1, 4);
        if(number == 1)
        {
            Debug.Log("1");
            Instantiate(money1);
        }
        if (number == 2)
        {
            Debug.Log("2");
            Instantiate(money2);
        }
        if (number == 3)
        {
            Debug.Log("3");
            Instantiate(money3);
        }
    }
}
