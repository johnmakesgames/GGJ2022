using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Inventory Item", order = 1)]
public class InventoryItem : ScriptableObject
{
    public string ItemDisplayName = "";
    public Sprite ItemSprite = null;
}
