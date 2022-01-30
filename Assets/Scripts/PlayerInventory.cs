using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
//using UnityEditor;

public class PlayerInventory : MonoBehaviour
{
    [Range(0, 20)]
    public int InventorySize;
    private List<InventoryItem> Data;

    // Start is called before the first frame update
    void Start()
    {
        Data = new List<InventoryItem>();
    }

    public bool AddToInventory(InventoryItem item)
    {
        if(item != null)
        {
            if(Data.Count + 1 <= InventorySize)
            {
                Data.Add(item);
                return true;
            }
        }

        return false;
    }

    public bool RemoveFromInventory(InventoryItem item)
    {
        if(item != null && Data.Count > 0)
        {
            int location = -1;
            for(int i = 0; i < Data.Count; i++)
            {
                if (Data[i] == item)
                {
                    location = i;
                    i = Data.Count;
                }
            }

            if(location != -1)
            {
                Data.RemoveAt(location);
                return true;
            }
        }

        return false;
    }

    public bool IsInInventory(InventoryItem item)
    {
        if (item != null)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i] == item)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
