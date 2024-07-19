using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField]
    private GameObject dronePrefab;

    [SerializeField]
    private GameObject droneMenu;

    private Animator myAnim;

    private int doubleChance = 1;
    private int lowCashChance = 2;
    private int medCashChance = 3;
    private int highCashChance = 4;
    

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        StartCoroutine(SpawnDrone());
    }

    IEnumerator SpawnDrone()
    {
        float spawnTime = Random.Range(10f, 20f);
        Debug.Log(spawnTime);
        yield return new WaitForSeconds(spawnTime);
        
    }

    public void OpenDrone()
    {
        droneMenu.SetActive(true);
        int prize = Random.Range(1, 5);
        if(prize == 1)  
        {
            Debug.Log("Won double cash");
        }
        if (prize == 2)
        {
            Debug.Log("Won low cash");
        }
        if (prize == 3)
        {
            Debug.Log("Won med cash");
        }
        if (prize == 4)
        {
            Debug.Log("won high cash");
        }
    }
}
