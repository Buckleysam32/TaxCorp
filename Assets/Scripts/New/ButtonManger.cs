using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManger : MonoBehaviour
{
    [SerializeField]
    private GameObject sideBar;

    private void Start()
    {
        sideBar.SetActive(false);
    }

    public void CloseMenu(GameObject close)
    {
        close.SetActive(false);
    }

    public void OpenMenu(GameObject open)
    {
        open.SetActive(true);
    }
}
