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

    public Animator myAnim;

    private ButtonManger myButtonManger;
    private Inv inv; 

    private void Start()
    {
        StartCoroutine(SpawnDrone());
        myButtonManger = FindObjectOfType<ButtonManger>();
        inv = FindObjectOfType<Inv>();
    }

    IEnumerator SpawnDrone()
    {
        float spawnTime = Random.Range(60f, 300f);
        Debug.Log(spawnTime);
        yield return new WaitForSeconds(spawnTime);
        myAnim.SetTrigger("Fly");
        StartCoroutine(SpawnDrone());
    }

    public void OpenDrone()
    {
        droneMenu.SetActive(true);
        myButtonManger.canTap = false;
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
        myAnim.SetTrigger("Idle");
    }
}
