using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterface;

public class CursorManager : MonoBehaviour
{
    private Vector3 _mouseWorldPos;


    private void Update()
    {
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Click();
    }

    private bool CanClick()
    {
        return ObjectAtMousePosition();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0)&& CanClick())
        {
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
