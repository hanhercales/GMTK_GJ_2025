using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    
    private List<InventorySlotUI> inventorySlots = new List<InventorySlotUI>();
    private InventorySlotUI selectedSlot;
    
    private void Awake()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }

        if (inventory == null) return;
        
        inventory.OnInventoryChanged += UpdateInventoryUI;

        SetupUI();
    }

    private void OnDestroy()
    {
        if (inventory != null)
        {
            inventory.OnInventoryChanged -= UpdateInventoryUI;
        }
    }

    public void SetupUI()
    {
        foreach (Transform slot in slotParent)
        {
            Destroy(slot.gameObject);
        }
        inventorySlots.Clear();

        for (int i = 0; i < inventory.GetSize(); i++)
        {
            GameObject slotGO = Instantiate(slotPrefab, slotParent);
            InventorySlotUI slotUI = slotGO.GetComponent<InventorySlotUI>();
            if (slotUI != null)
            {
                inventorySlots.Add(slotUI);
                Button slotButton = slotGO.GetComponent<Button>();
                if(slotButton == null) slotButton = slotGO.AddComponent<Button>();
                slotButton.onClick.AddListener(() => OnSlotUI_Clicked(slotUI));
            }
        }
        
        UpdateInventoryUI();
    }

    private void OnSlotUI_Clicked(InventorySlotUI clickedSlot)
    {
        if (selectedSlot == clickedSlot)
        {
            selectedSlot.SetSelected(false);
            selectedSlot = null;
        }
        else
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetSelected(false);
            }
            
            selectedSlot = clickedSlot;
            selectedSlot.SetSelected(true);
        }
    }
    
    public void UpdateInventoryUI()
    {
        List<ItemSO> content = inventory.GetContent();

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (i < content.Count)
            {
                inventorySlots[i].UpdateSlot(content[i]);
            }
            else
            {
                inventorySlots[i].UpdateSlot(null);
            }
        }
    }
}
