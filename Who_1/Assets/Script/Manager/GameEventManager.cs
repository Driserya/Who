using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GGG.Tool;
using GGG.Tool.Singleton;

public class GameEventManager : SingletonNonMono<GameEventManager>
{
    //首先写一个接口，统一管理不同的事件
    private interface IEventHelp//事件接口
    {

    }




    //类
    //无参委托
    private class EventHelp : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action _action;

        public EventHelp(Action action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action action)
        {
            _action += action;
        }

        //调用事件
        public void Call()//呼叫事件
        {
            _action?.Invoke();
        }

        //移除事件
        public void Remove(Action action)//获取需要注销的函数
        {
            _action -= action;
        }
    }

    //一个参数的委托
    private class EventHelp<T> : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action<T> _action;

        public EventHelp(Action<T> action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action<T> action)
        {
            _action += action;
        }

        //调用事件
        public void Call(T value)//呼叫事件
        {
            _action?.Invoke(value);
        }

        //移除事件
        public void Remove(Action<T> action)//获取需要注销的函数
        {
            _action -= action;
        }
    }

    //两个参数的委托
    private class EventHelp<T1, T2> : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action<T1, T2> _action;

        public EventHelp(Action<T1, T2> action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action<T1, T2> action)
        {
            _action += action;
        }

        //调用事件
        public void Call(T1 value1, T2 value2)//呼叫事件
        {
            _action?.Invoke(value1, value2);
        }

        //移除事件
        public void Remove(Action<T1, T2> action)//获取需要注销的函数
        {
            _action -= action;
        }
    }

    //三个参数的委托
    private class EventHelp<T1, T2, T3> : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action<T1, T2, T3> _action;

        public EventHelp(Action<T1, T2, T3> action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action<T1, T2, T3> action)
        {
            _action += action;
        }

        //调用事件
        public void Call(T1 value1, T2 value2, T3 value3)//呼叫事件
        {
            _action?.Invoke(value1, value2, value3);
        }

        //移除事件
        public void Remove(Action<T1, T2, T3> action)//获取需要注销的函数
        {
            _action -= action;
        }
    }


    //四个参数的委托
    private class EventHelp<T1, T2, T3, T4> : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action<T1, T2, T3, T4> _action;

        public EventHelp(Action<T1, T2, T3, T4> action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action<T1, T2, T3, T4> action)
        {
            _action += action;
        }

        //调用事件
        public void Call(T1 value1, T2 value2, T3 value3, T4 value4)//呼叫事件
        {
            _action?.Invoke(value1, value2, value3, value4);
        }

        //移除事件
        public void Remove(Action<T1, T2, T3, T4> action)//获取需要注销的函数
        {
            _action -= action;
        }
    }



    //五个参数的委托
    private class EventHelp<T1, T2, T3, T4, T5> : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action<T1, T2, T3, T4, T5> _action;

        public EventHelp(Action<T1, T2, T3, T4, T5> action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action<T1, T2, T3, T4, T5> action)
        {
            _action += action;
        }

        //调用事件
        public void Call(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)//呼叫事件
        {
            _action?.Invoke(value1, value2, value3, value4, value5);
        }

        //移除事件
        public void Remove(Action<T1, T2, T3, T4, T5> action)//获取需要注销的函数
        {
            _action -= action;
        }
    }

    //六个参数的委托
    private class EventHelp<T1, T2, T3, T4, T5, T6> : IEventHelp//让类继承接口
    {
        //回调函数
        private event Action<T1, T2, T3, T4, T5, T6> _action;

        public EventHelp(Action<T1, T2, T3, T4, T5, T6> action)
        {
            //这是第一次实例的时候，也就是说只会执行这一次
            _action = action;
        }

        //增加事件的注册函数
        public void AddCall(Action<T1, T2, T3, T4, T5, T6> action)
        {
            _action += action;
        }

        //调用事件
        public void Call(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)//呼叫事件
        {
            _action?.Invoke(value1, value2, value3, value4, value5, value6);
        }

        //移除事件
        public void Remove(Action<T1, T2, T3, T4, T5, T6> action)//获取需要注销的函数
        {
            _action -= action;
        }
    }





    private Dictionary<string, IEventHelp> _eventCenter = new Dictionary<string, IEventHelp>();





    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="eventname">事件名称</param>
    /// <param name="action">回调函数</param>
    public void AddEventListening(string eventname, Action action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp(action));
        }
    }

    public void AddEventListening<T>(string eventname, Action<T> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T>)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp<T>(action));
        }
    }

    public void AddEventListening<T1, T2>(string eventname, Action<T1, T2> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2>)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp<T1, T2>(action));
        }
    }


    public void AddEventListening<T1, T2, T3>(string eventname, Action<T1, T2, T3> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3>)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp<T1, T2, T3>(action));
        }
    }

    public void AddEventListening<T1, T2, T3, T4>(string eventname, Action<T1, T2, T3, T4> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4>)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp<T1, T2, T3, T4>(action));
        }
    }


    public void AddEventListening<T1, T2, T3, T4, T5>(string eventname, Action<T1, T2, T3, T4, T5> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4, T5>)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp<T1, T2, T3, T4, T5>(action));
        }
    }

    public void AddEventListening<T1, T2, T3, T4, T5, T6>(string eventname, Action<T1, T2, T3, T4, T5, T6> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4, T5, T6>)?.AddCall(action);
        }
        else
        {
            //如果事件中心不存在叫eventname这个名字的事件
            _eventCenter.Add(eventname, new EventHelp<T1, T2, T3, T4, T5, T6>(action));
        }
    }




    //调用事件
    public void CallEvent(string eventname)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp)?.Call();
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }

    public void CallEvent<T>(string eventname, T value)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T>)?.Call(value);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }

    public void CallEvent<T1, T2>(string eventname, T1 value1, T2 value2)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2>)?.Call(value1, value2);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }

    public void CallEvent<T1, T2, T3>(string eventname, T1 value1, T2 value2, T3 value3)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3>)?.Call(value1, value2, value3);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }

    public void CallEvent<T1, T2, T3, T4>(string eventname, T1 value1, T2 value2, T3 value3, T4 value4)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4>)?.Call(value1, value2, value3, value4);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }

    public void CallEvent<T1, T2, T3, T4, T5>(string eventname, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4, T5>)?.Call(value1, value2, value3, value4, value5);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }

    public void CallEvent<T1, T2, T3, T4, T5, T6>(string eventname, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4, T5, T6>)?.Call(value1, value2, value3, value4, value5, value6);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法执行该事件");
        }
    }



    //移除事件
    public void RemoveEvent(string eventname, Action action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

    public void RemoveEvent<T>(string eventname, Action<T> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T>)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

    public void RemoveEvent<T1, T2>(string eventname, Action<T1, T2> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2>)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

    public void RemoveEvent<T1, T2, T3>(string eventname, Action<T1, T2, T3> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3>)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

    public void RemoveEvent<T1, T2, T3, T4>(string eventname, Action<T1, T2, T3, T4> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4>)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

    public void RemoveEvent<T1, T2, T3, T4, T5>(string eventname, Action<T1, T2, T3, T4, T5> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4, T5>)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

    public void RemoveEvent<T1, T2, T3, T4, T5, T6>(string eventname, Action<T1, T2, T3, T4, T5, T6> action)
    {
        if (_eventCenter.TryGetValue(eventname, out var e))//判断事件中心有没有叫eventname这个事件
        {
            (e as EventHelp<T1, T2, T3, T4, T5, T6>)?.Remove(action);
        }
        else
        {
            DevelopmentToos.WTF($"当前未找到{eventname}的事件，无法移除该事件");
        }
    }

}
