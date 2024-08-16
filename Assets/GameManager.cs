using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public float currentMoney;
    public int tapAmount;
    public float cps;
    public int potholeLvl;
    public int potholeCost;
    public int tollLvl;
    public int tollCost;
    public int propertyLvl;
    public int propertyCost;
    public int grogLvl;
    public int grogCost;
    public int corpLvl;
    public int corpCost;
    public int warLvl;
    public int warCost;
    public bool canProperty;
    public bool canGrog;
    public bool canCorp;
    public bool canWar;
}


public class GameManager : MonoBehaviour
{
    private string saveFilePath;
    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        FindObjectOfType<UIManager>().UpgradeMenu.SetActive(true);
        FindObjectOfType<GameManager>().LoadGame();
        FindObjectOfType<UIManager>().UpgradeMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ClearSaveData();
        }
    }
    public void SaveGame()
    {
        GameData data = new GameData
        {
            currentMoney = FindObjectOfType<Inv>().currentMoney,
            tapAmount = FindObjectOfType<Inv>().tapAmount,
            cps = FindObjectOfType<Inv>().cps,
            potholeLvl = FindObjectOfType<UpgradeManager>().potholeLvl,
            potholeCost = FindObjectOfType<UpgradeManager>().potholeCost,
            tollLvl = FindObjectOfType<UpgradeManager>().tollLvl,
            tollCost = FindObjectOfType<UpgradeManager>().tollCost,
            propertyLvl = FindObjectOfType<UpgradeManager>().propertyLvl,
            propertyCost = FindObjectOfType<UpgradeManager>().propertyCost,
            grogLvl = FindObjectOfType<UpgradeManager>().grogLvl,
            grogCost = FindObjectOfType<UpgradeManager>().grogCost,
            corpLvl = FindObjectOfType<UpgradeManager>().corpLvl,
            corpCost = FindObjectOfType<UpgradeManager>().corpCost,
            warLvl = FindObjectOfType<UpgradeManager>().warLvl,
            warCost = FindObjectOfType<UpgradeManager>().warCost,
            canProperty = FindObjectOfType<UpgradeManager>().canProperty,
            canGrog = FindObjectOfType<UpgradeManager>().canGrog,
            canCorp = FindObjectOfType<UpgradeManager>().canCorp,
            canWar = FindObjectOfType<UpgradeManager>().canWar
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            FindObjectOfType<Inv>().currentMoney = data.currentMoney;
            FindObjectOfType<Inv>().tapAmount = data.tapAmount;
            FindObjectOfType<Inv>().cps = data.cps;

            FindObjectOfType<UpgradeManager>().potholeLvl = data.potholeLvl;
            FindObjectOfType<UpgradeManager>().potholeCost = data.potholeCost;
            FindObjectOfType<UpgradeManager>().tollLvl = data.tollLvl;
            FindObjectOfType<UpgradeManager>().tollCost = data.tollCost;
            FindObjectOfType<UpgradeManager>().propertyLvl = data.propertyLvl;
            FindObjectOfType<UpgradeManager>().propertyCost = data.propertyCost;
            FindObjectOfType<UpgradeManager>().grogLvl = data.grogLvl;
            FindObjectOfType<UpgradeManager>().grogCost = data.grogCost;
            FindObjectOfType<UpgradeManager>().corpLvl = data.corpLvl;
            FindObjectOfType<UpgradeManager>().corpCost = data.corpCost;
            FindObjectOfType<UpgradeManager>().warLvl = data.warLvl;
            FindObjectOfType<UpgradeManager>().warCost = data.warCost;
            FindObjectOfType<UpgradeManager>().canProperty = data.canProperty;
            FindObjectOfType<UpgradeManager>().canGrog = data.canGrog;
            FindObjectOfType<UpgradeManager>().canCorp = data.canCorp;
            FindObjectOfType<UpgradeManager>().canWar = data.canWar;

            FindObjectOfType<UIManager>().UpdateText();
            FindObjectOfType<UIManager>().UpdateUpgrades(FindObjectOfType<UIManager>().potholeCost,
            FindObjectOfType<UpgradeManager>().potholeCost, FindObjectOfType<UIManager>().potholeLvl,
            FindObjectOfType<UpgradeManager>().potholeLvl);

            FindObjectOfType<UIManager>().UpdateText();
            FindObjectOfType<UIManager>().UpdateUpgrades(FindObjectOfType<UIManager>().tollCost,
            FindObjectOfType<UpgradeManager>().tollCost, FindObjectOfType<UIManager>().tollLvl,
            FindObjectOfType<UpgradeManager>().tollLvl);

            FindObjectOfType<UIManager>().UpdateText();
            FindObjectOfType<UIManager>().UpdateUpgrades(FindObjectOfType<UIManager>().propertyCost,
            FindObjectOfType<UpgradeManager>().propertyCost, FindObjectOfType<UIManager>().propertyLvl,
            FindObjectOfType<UpgradeManager>().propertyLvl);

            FindObjectOfType<UIManager>().UpdateText();
            FindObjectOfType<UIManager>().UpdateUpgrades(FindObjectOfType<UIManager>().grogCost,
            FindObjectOfType<UpgradeManager>().grogCost, FindObjectOfType<UIManager>().grogLvl,
            FindObjectOfType<UpgradeManager>().grogLvl);

            FindObjectOfType<UIManager>().UpdateText();
            FindObjectOfType<UIManager>().UpdateUpgrades(FindObjectOfType<UIManager>().corpCost,
            FindObjectOfType<UpgradeManager>().corpCost, FindObjectOfType<UIManager>().corpLvl,
            FindObjectOfType<UpgradeManager>().corpLvl);

            FindObjectOfType<UIManager>().UpdateText();
            FindObjectOfType<UIManager>().UpdateUpgrades(FindObjectOfType<UIManager>().warCost,
            FindObjectOfType<UpgradeManager>().warCost, FindObjectOfType<UIManager>().warLvl,
            FindObjectOfType<UpgradeManager>().warLvl);
        }
    }

    public static void ClearSaveData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data cleared.");
        }
        else
        {
            Debug.Log("No save data found to clear.");
        }
    }
}
