using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> content = new List<ItemSO>();

    public event System.Action OnInventoryChanged;

    [SerializeField] private int size = 7;

    public bool AddItem(ItemSO item)
    {
        content.Add(item);
        OnInventoryChanged?.Invoke();
        return true;
    }
    
    public bool RemoveItem(ItemSO item)
    {
        content.Remove(item);
        OnInventoryChanged?.Invoke();
        return true;  
    }
    
    public bool Clear()
    {
        content.Clear();
        OnInventoryChanged?.Invoke();
        return true;
    }

    public int GetSize()
    {
        return size;
    }
    
    public List<ItemSO> GetContent()
    {
        return content;
    }
}
