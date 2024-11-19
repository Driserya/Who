using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterface;

public class InterActiveBase : MonoBehaviour , _Click 
{
    [SerializeField] private ItemName requireItem;//目标物品

    [SerializeField]public bool isDone;//开启状态

    [SerializeField]private ItemName currentItem;

    private void CheckItem(ItemName itemName)
    {
        if(itemName ==requireItem&&!isDone)
        {
            isDone = true;
            OnClickedAction();

            GameEventManager.MainInstance.CallEvent("物品使用", requireItem);
        }
        else if(itemName != requireItem && !isDone)
        {
            EmptyClicked();
        }
    }

    /// <summary>
    /// 默认是对应目标物品的使用方法
    /// </summary>
    protected virtual void OnClickedAction()
    {

    }

    protected virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }

    public void GetHandItem(ItemName itemName)
    {
        currentItem = itemName;
    }

    public void Click()
    {
        if(!isDone)
        {
            CheckItem(currentItem);
        }
    }
}
