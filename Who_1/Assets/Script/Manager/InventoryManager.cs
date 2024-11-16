using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGG.Tool.Singleton;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]private ItemDataList_SO itemData;

    [SerializeField]private List<ItemName>itemList =new List<ItemName>();

    public void AddItem(ItemName itemName)
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
}
