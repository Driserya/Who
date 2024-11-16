using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]private Button leftButton, rightButton;
    
    [SerializeField]private SlotUI slotUI;
    
    [SerializeField]private int currentIndex;

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening<ItemDetails, int>("物品事件", ItemEvent);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent<ItemDetails, int>("物品事件", ItemEvent);
    }

    private void ItemEvent(ItemDetails itemDetails,int index)//物品和UI管理
    {
        if(itemDetails == null)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentIndex =index;
            slotUI.SetItem(itemDetails);
        }
    }

}
