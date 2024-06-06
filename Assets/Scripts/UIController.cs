using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI bananaCountText;
    public Inventory inventory;
                            

    // Start is called before the first frame update
    void Start()
    {
        UpdateBananaCountText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBananaCountText();
    }

    void UpdateBananaCountText()
    {
        if (bananaCountText != null && inventory != null)
        {
            int bananaCount = inventory.GetBananaCount("banana");
            bananaCountText.text = "Bananas: " + bananaCount;
        }
    }
}
