using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManger : MonoBehaviour
{
    public GameObject sideBar;

    private void Start()
    {
        sideBar.SetActive(false);
    }
    public void OpenMenu()
    {
        Debug.Log("Open Menu");
        sideBar.SetActive(true);
    }

    public void CloseMenu()
    {
        Debug.Log("Close Menu");
        sideBar.SetActive(false);
    }
}
