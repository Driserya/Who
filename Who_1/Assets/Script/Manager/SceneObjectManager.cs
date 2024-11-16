using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectManager : MonoBehaviour
{
    private Dictionary<ItemName,bool> itemAvailableDict = new Dictionary<ItemName,bool>();

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening("场景物品数据存储", BeforeSceneUnLoadEvent);
        GameEventManager.MainInstance.AddEventListening("添加场景物品数据", AfterSceneLoadedEvent);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent("场景物品数据存储", BeforeSceneUnLoadEvent);
        GameEventManager.MainInstance.RemoveEvent("添加场景物品数据", AfterSceneLoadedEvent);
    }


    private void BeforeSceneUnLoadEvent()
    {

    }

    private void AfterSceneLoadedEvent()
    {

    }


}
