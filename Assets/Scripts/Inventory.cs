using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int bananaAddAmount = 1;
    public int treeAddAmount = 60;
    public int banana = 0;
    public int monkey = 0;


    // Method to add an item to the inventory
    public void AddBananaB()
    {
        banana += bananaAddAmount;
    }

    public void AddTreeB()
    {
        banana += treeAddAmount;
    }

    public void AddMonkey()
    {
        monkey += 1;
    }

    // Method to check if the inventory contains a specific item
    public bool ContainsItem(string item)
    {
        return banana > 0;
    }

    // Method to remove an item from the inventory
    public bool RemoveItem(string item, int quantity)
    {
        if (banana >= quantity)
        {
            banana -= quantity;
            return true;
        }
        return false;
    }

    // Method to get the count of a specific item in the inventory
    public int GetBananaCount(string item)
    {
        return banana;
    }

}
