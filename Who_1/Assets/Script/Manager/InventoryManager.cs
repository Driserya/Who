using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGG.Tool.Singleton;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]private ItemDataList_SO itemData;

    [SerializeField]private List<ItemName>itemList =new List<ItemName>();

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening<ItemName>("物品使用", OnItemUsedEvent);
        GameEventManager.MainInstance.AddEventListening<int>("获取", GetItem);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent<ItemName>("物品使用", OnItemUsedEvent);
        GameEventManager.MainInstance.RemoveEvent<int>("获取", GetItem);
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        var index = itemList.IndexOf(itemName);
        itemList.RemoveAt(index);

        if(itemList.Count==0)
        {
            ItemDetails test = null;
            GameEventManager.MainInstance.CallEvent("物品事件", test, -1);
        }
    }

    public void AddItem(ItemName itemName)//UI物品添加
    {
        if(!itemList.Contains(itemName))
        {
            //如果查找到场景中不含有目标物品，那么就添加物品
            itemList.Add(itemName);
            //ui显示
            //Debug.Log(itemData.GetItemDetails(itemName));
            GameEventManager.MainInstance.CallEvent("物品事件", itemData.GetItemDetails(itemName), itemList.Count - 1);//InventoryUI事件地址
        }

    }

    public void GetItem(int currentIndex)
    {
        if (itemList.Count != 0)
        {
            GameEventManager.MainInstance.CallEvent("获取当前物品", itemData.GetItemDetails(itemList[currentIndex]));
        }
        if (itemList.Count == 0)
        {
            ItemDetails test = null;
            GameEventManager.MainInstance.CallEvent("物品事件", test, -1);
        }
    }
}
