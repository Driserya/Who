using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActiveBase : MonoBehaviour
{
    [SerializeField] private ItemName requireItem;

    [SerializeField]private bool isDone;

    public void CheckItem(ItemName itemName)
    {
        if(itemName ==requireItem&&!isDone)
        {
            isDone = true;
            OnClickedAction();
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
}
