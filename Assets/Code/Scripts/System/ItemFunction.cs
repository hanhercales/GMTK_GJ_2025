using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemFunction : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private InventoryDisplay inventoryDisplay;
    [SerializeField] TextMeshProUGUI notificationText;
    [SerializeField] private bool destroyAfterUse = false;

    private void Awake()
    {
        notificationText.text = "Select the appropriate item.";
        notificationText.enabled = false;
    }

    public void TakeItem(ItemSO item)
    {
        if(inventory.AddItem(item) && destroyAfterUse)
            Destroy(GetComponent<InteractableObject>());
    }

    public void UseItem(ItemSO item)
    {
        if(inventoryDisplay.GetSelectedSlot() == null ||
           inventoryDisplay.GetSelectedSlot().GetCurrentItem().itemID != item.itemID)
        {
            notificationText.enabled = true;
            StartCoroutine(TextDisappear(2f));
            return;
        }
        
        if(inventoryDisplay.GetSelectedSlot().GetCurrentItem().itemID == item.itemID)
        {
            inventory.RemoveItem(inventoryDisplay.GetSelectedSlot().GetCurrentItem());
            inventoryDisplay.SetSelectedSlot(null);
            if(destroyAfterUse)
                Destroy(GetComponent<InteractableObject>());
        }
    }
    
    private IEnumerator TextDisappear(float time)
    {
        yield return new WaitForSeconds(time);
        notificationText.enabled = false;
    }
}
