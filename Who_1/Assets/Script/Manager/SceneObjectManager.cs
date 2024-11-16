using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneObjectManager : MonoBehaviour
{
    private Dictionary<ItemName,bool> itemAvailableDict = new Dictionary<ItemName,bool>();

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening("场景物品数据存储", BeforeSceneUnLoadEvent);
        GameEventManager.MainInstance.AddEventListening("添加场景物品数据", AfterSceneLoadedEvent);
        GameEventManager.MainInstance.AddEventListening<ItemDetails, int>("物品事件", ItemEvent);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent("场景物品数据存储", BeforeSceneUnLoadEvent);
        GameEventManager.MainInstance.RemoveEvent("添加场景物品数据", AfterSceneLoadedEvent);
        GameEventManager.MainInstance.RemoveEvent<ItemDetails, int>("物品事件", ItemEvent);
    }


    private void BeforeSceneUnLoadEvent()
    {
        
        foreach (var item in FindObjectsOfType<ItemBase>())
        {
            if (!itemAvailableDict.ContainsKey(item._itemName))
            {
                itemAvailableDict.Add(item._itemName, true);
            }
        }
    }

    private void AfterSceneLoadedEvent()
    {
        foreach (var item in FindObjectsOfType<ItemBase>())
        {
            if(!itemAvailableDict.ContainsKey(item._itemName))
            {
                itemAvailableDict.Add(item._itemName, true);
            }
            else
            {
                item.gameObject.SetActive(itemAvailableDict[item._itemName]);
            }
        }
    }

    private void ItemEvent(ItemDetails itemDetails, int index)
    {
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.itemName] = false;
        }
    }


}
