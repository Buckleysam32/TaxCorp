using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManger : MonoBehaviour
{
    [SerializeField]
    private GameObject sideBar;
    public bool canTap;

    private void Start()
    {
        Application.targetFrameRate = 60;
        canTap = true;
    }

    public void CloseMenu(GameObject close)
    {
        close.SetActive(false);
        canTap = true;
    }

    public void OpenMenu(GameObject open)
    {
        open.SetActive(true);
        canTap = false;
    }

    public void CanTap(bool tap)
    {
        canTap = tap;
    }
}
