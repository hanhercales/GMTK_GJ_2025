using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public event System.Action<InventorySlotUI> OnSlotClickedEvent;
    
    [SerializeField] private Image icon;
    [SerializeField] private Image selectedBorder;
    
    private ItemSO currentItem;
    private bool isSelected = false;
    
    public void UpdateSlot(ItemSO item)
    {
        if(item != null)
        {
            currentItem = item;
            icon.sprite = item.itemSprite;
            icon.enabled = true;
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
        }
        
        selectedBorder.enabled = false;
    }

    public void OnSlotClicked()
    {
        OnSlotClickedEvent?.Invoke(this);
    }
    
    public void SetSelected(bool isSelected)
    {
        this.isSelected = isSelected;
        UpdateSelectionUI();
    }

    private void UpdateSelectionUI()
    {
        selectedBorder.enabled = isSelected;
    }
    
    public ItemSO GetCurrentItem()
    {
        return currentItem;
    }
}
