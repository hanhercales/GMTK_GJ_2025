using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemID;
    public string itemName;
    public Sprite itemSprite;
}
