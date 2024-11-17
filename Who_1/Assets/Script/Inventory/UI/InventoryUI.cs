using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]private Button leftButton, rightButton;
    
    [SerializeField]private SlotUI slotUI;
    
    [SerializeField]private int currentIndex;

    [SerializeField] private int maxIndex;

    private void Start()
    {
        SwitchItem(0);
    }

    public void SSwitchItem(int amout) => SwitchItem(amout);

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening<ItemDetails, int>("物品事件", ItemEvent);
        GameEventManager.MainInstance.AddEventListening<ItemName>("物品使用", OnItemUsedEvent);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent<ItemDetails, int>("物品事件", ItemEvent);
        GameEventManager.MainInstance.RemoveEvent<ItemName>("物品使用", OnItemUsedEvent);
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
            maxIndex=index;
            currentIndex =index;
            slotUI.SetItem(itemDetails);
            SwitchItem(0);
        }
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        maxIndex-=1;
        currentIndex = 0;
        SwitchItem(0);
    }

    private void SwitchItem(int amout)
    {
        currentIndex = currentIndex + amout;
        slotUI.ChangeItem(currentIndex);

        if (currentIndex==0 && currentIndex<maxIndex)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if (currentIndex == maxIndex && currentIndex > 0)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }

        else if(currentIndex > 0 && currentIndex < maxIndex)
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }
        
        else
        {
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
    }

}
