using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image selectedBorder;
    [SerializeField] private TextMeshProUGUI nameText;
    
    private ItemSO currentItem;
    private bool isSelected = false;
    
    public void UpdateSlot(ItemSO item)
    {
        if(item != null)
        {
            nameText.text = item.itemName;
            currentItem = item;
            icon.sprite = item.itemSprite;
            icon.enabled = true;
        }
        else
        {
            nameText.text = "";
            icon.sprite = null;
            icon.enabled = false;
        }
        
        selectedBorder.enabled = false;
        nameText.enabled = false;
    }
    
    public void SetSelected(bool isSelected)
    {
        this.isSelected = isSelected;
        UpdateSelectionUI();
    }

    private void UpdateSelectionUI()
    {
        selectedBorder.enabled = isSelected;
        nameText.enabled = isSelected;
    }
    
    public ItemSO GetCurrentItem()
    {
        return currentItem;
    }
}
