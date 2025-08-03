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
    [SerializeField] private ItemSO itemToTake;
    [SerializeField] private ItemSO itemToUse;

    private void Awake()
    {
        notificationText.enabled = false;
    }

    public void TakeItem()
    {
        if(inventory.AddItem(itemToTake) && destroyAfterUse)
            Destroy(GetComponent<InteractableObject>());
    }
    
    private bool UseItem()
    {
        if(inventoryDisplay.GetSelectedSlot() == null ||
           inventoryDisplay.GetSelectedSlot().GetCurrentItem().itemID != itemToUse.itemID)
        {
            SetNoti("Need " + itemToUse.itemName + "! Please select it from your inventory.");
            return false;
        }
        
        if(inventoryDisplay.GetSelectedSlot().GetCurrentItem().itemID == itemToUse.itemID)
        {
            if(destroyAfterUse)
            {
                inventory.RemoveItem(inventoryDisplay.GetSelectedSlot().GetCurrentItem());
                inventoryDisplay.SetSelectedSlot(null);
                if(GetComponent<InteractableObject>() != null)
                    Destroy(GetComponent<InteractableObject>());
            }
            
            return true;
        }
        
        return false;
    }

    public void SubmitToTake()
    {
        if(UseItem())
            TakeItem();
    }

    public void SubmitToShow(GameObject picturePanel)
    {
        if(UseItem())
            picturePanel.SetActive(true);
    }
    
    private IEnumerator TextDisappear(float time)
    {
        yield return new WaitForSeconds(time);
        notificationText.enabled = false;
    }

    public void SetNoti(string noti)
    {
        notificationText.text = noti;
        notificationText.enabled = true;
        StartCoroutine(TextDisappear(2f));
    }
}
