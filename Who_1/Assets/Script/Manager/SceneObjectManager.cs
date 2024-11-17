using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SceneObjectManager : MonoBehaviour
{
    private Dictionary<ItemName,bool> itemAvailableDict = new Dictionary<ItemName,bool>();
    private Dictionary<string,bool> itemAvailableDict2 = new Dictionary<string, bool>();

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
        foreach (var item in FindObjectsOfType<InterActiveBase>())
        {
            if (!itemAvailableDict2.ContainsKey(item.name))
            {
                itemAvailableDict2.Add(item.name, item.isDone);
            }
            else
            {
                itemAvailableDict2[item.name] = item.isDone;
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
        foreach (var item in FindObjectsOfType<InterActiveBase>())
        {
            if (!itemAvailableDict2.ContainsKey(item.name))
            {
                itemAvailableDict2.Add(item.name, item.isDone);
            }
            else
            {
                item.isDone=itemAvailableDict2[item.name];
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
