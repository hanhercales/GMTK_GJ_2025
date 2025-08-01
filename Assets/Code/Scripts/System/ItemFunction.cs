using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunction : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private InventoryDisplay inventoryDisplay;
    [SerializeField] private ItemSO item;
    
    public void TakeItem()
    {
        if(inventory.AddItem(item))
            Destroy(GetComponent<InteractableObject>());
    }

    public void UseItem()
    {
        if(inventoryDisplay.GetSelectedSlot() == null)
            return;
        
        if(inventoryDisplay.GetSelectedSlot().GetCurrentItem().itemID == item.itemID)
        {
            inventory.RemoveItem(inventoryDisplay.GetSelectedSlot().GetCurrentItem());
            inventoryDisplay.SetSelectedSlot(null);
            Destroy(GetComponent<InteractableObject>());
        }
    }
}
