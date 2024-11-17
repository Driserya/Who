using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterface;
using System;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private RectTransform hand;

    private Vector3 _mouseWorldPos;

    [SerializeField]private ItemName currentItem;

    private bool holdItem;//是否拿着物品

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening<ItemDetails, bool>("拿取UI当前物品", OnItemSelectedEven);
        GameEventManager.MainInstance.AddEventListening<ItemName>("物品使用", OnItemUsedEvent);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent<ItemDetails, bool>("拿取UI当前物品", OnItemSelectedEven);
        GameEventManager.MainInstance.RemoveEvent<ItemName>("物品使用", OnItemUsedEvent);
    }

    private void Update()
    {
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Click();
        HandMove();
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        currentItem = ItemName.None;
        holdItem = false;
        hand.gameObject.SetActive(holdItem);
    }

    private void HandMove()
    {
        if(hand.gameObject.activeInHierarchy)
        {
            hand.position=Input.mousePosition;
        }
    }

    private void OnItemSelectedEven(ItemDetails itemDetails,bool isSelected)
    {
        holdItem = isSelected;
        if (isSelected)
        {
            currentItem = itemDetails.itemName;
        }
        hand.gameObject.SetActive(holdItem);
    }

    private bool CanClick()
    {
        return ObjectAtMousePosition();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0)&& CanClick())
        {
            ObjectAtMousePosition().gameObject?.GetComponent<InterActiveBase>()?.GetHandItem(currentItem);
            ObjectAtMousePosition().gameObject.GetComponent<_Click>().Click();
        }
    }
    
    /// <summary>
    /// 检测鼠标点击范围的碰撞体
    /// </summary>
    /// <returns></returns>
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(_mouseWorldPos);//也就是说可以返回是否成功检测到碰撞体。
        //ObjectAtMousePosition() 返回的是 Collider2D，Collider2D 最终继承了 Object；
        //2、这里的Object 并不是 System.Object ，而是 UnityEngine.Object ;
        //3、UnityEngine.Object 中 声明了隐式的自定义转换类型 bool 源码如下： public static implicit operator bool(Object exists) 所以不会报错。
    }



}
