using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterface;

public abstract class ItemBase : MonoBehaviour,_Click
{
    [SerializeField]private ItemName _itemName;
    public void Click()
    {
        //道具物品的点击效果都是，点击后放入背包,然后隐藏物品
        InventoryManager.MainInstance.AddItem(_itemName);
        this.gameObject.SetActive(false);

    }

}
