using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    private static Dictionary<EventType, Delegate> eventTable = new Dictionary<EventType, Delegate>();
    private static void OnLinstenerAdding(EventType eventType, Delegate callBack)
    {
        //如果没有 新建一个委托
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable.Add(eventType, null);
        }
        Delegate _delegate = eventTable[eventType];
        if (null != _delegate && _delegate.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("【添加】监听报错！不能为事件{0}添加不同类型的委托，当前事件的委托为{1}，要添加的委托为{2}", eventType, _delegate.GetType(), callBack.GetType()));
        }
    }
    private static void OnLinstenerRemoving(EventType eventType, Delegate callBack)
    {
        if (eventTable.ContainsKey(eventType))
        {
            Delegate _delegate = eventTable[eventType];
            if (null == _delegate)
            {
                throw new Exception(string.Format("【移除】监听报错！事件{0}没有对应的委托！", eventType));
            }
            else if (_delegate.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("【移除】监听报错！尝试为事件{0}移除不同类型的委托！当前委托类型为{1}，要移除的委托类型为{2}", eventType, _delegate.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("【移除】监听报错！没有事件{0}！", eventType));
        }
    }
    private static void OnLinstenerRemoved(EventType eventType)
    {
        if (null == eventTable[eventType])
        {
            eventTable.Remove(eventType);
        }
    }
    //无参
    public static void AddListener(EventType eventType, CallBack callBack)
    {
        OnLinstenerAdding(eventType, callBack);
        //这里必须强转
        eventTable[eventType] = (CallBack)eventTable[eventType] + callBack;
    }
    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        OnLinstenerRemoving(eventType, callBack);
        CallBack _callBack = eventTable[eventType] as CallBack;
        //链式设计
        if (null != _callBack)
        {
            eventTable[eventType] = _callBack - callBack;
            OnLinstenerRemoved(eventType);
        }
    }
    public static void BroadCast(EventType eventType)
    {
        Delegate _delegate;
        if (eventTable.TryGetValue(eventType, out _delegate))
        {
            CallBack _callBack = _delegate as CallBack;
            if (null != _callBack)
            {
                _callBack();
            }
            else
            {
                throw new Exception(string.Format("【广播】监听报错！事件{0}的委托类型不对应！", eventType));
            }
        }
    }
    //一个参数
    public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnLinstenerAdding(eventType, callBack);
        //这里必须强转
        eventTable[eventType] = (CallBack<T>)eventTable[eventType] + callBack;
    }
    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnLinstenerRemoving(eventType, callBack);
        CallBack<T> _callBack = eventTable[eventType] as CallBack<T>;
        //链式设计
        if (null != _callBack)
        {
            eventTable[eventType] = _callBack - callBack;
            OnLinstenerRemoved(eventType);
        }
    }
    public static void BroadCast<T>(EventType eventType, T arg)
    {
        Delegate _delegate;
        if (eventTable.TryGetValue(eventType, out _delegate))
        {
            CallBack<T> _callBack = _delegate as CallBack<T>;
            if (null != _callBack)
            {
                _callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("【广播】监听报错！事件{0}的委托类型不对应！", eventType));
            }
        }
    }
    //两个参数
    public static void AddListener<T, A>(EventType eventType, CallBack<T, A> callBack)
    {
        OnLinstenerAdding(eventType, callBack);
        //这里必须强转
        eventTable[eventType] = (CallBack<T, A>)eventTable[eventType] + callBack;
    }
    public static void RemoveListener<T, A>(EventType eventType, CallBack<T, A> callBack)
    {
        OnLinstenerRemoving(eventType, callBack);
        CallBack<T, A> _callBack = eventTable[eventType] as CallBack<T, A>;
        //链式设计
        if (null != _callBack)
        {
            eventTable[eventType] = _callBack - callBack;
            OnLinstenerRemoved(eventType);
        }
    }
    public static void BroadCast<T, A>(EventType eventType, T arg0, A arg1)
    {
        Delegate _delegate;
        if (eventTable.TryGetValue(eventType, out _delegate))
        {
            CallBack<T, A> _callBack = _delegate as CallBack<T, A>;
            if (null != _callBack)
            {
                _callBack(arg0, arg1);
            }
            else
            {
                throw new Exception(string.Format("【广播】监听报错！事件{0}的委托类型不对应！", eventType));
            }
        }
    }
    //三个参数
    public static void AddListener<T, A, B>(EventType eventType, CallBack<T, A, B> callBack)
    {
        OnLinstenerAdding(eventType, callBack);
        //这里必须强转
        eventTable[eventType] = (CallBack<T, A, B>)eventTable[eventType] + callBack;
    }
    public static void RemoveListener<T, A, B>(EventType eventType, CallBack<T, A, B> callBack)
    {
        OnLinstenerRemoving(eventType, callBack);
        CallBack<T, A, B> _callBack = eventTable[eventType] as CallBack<T, A, B>;
        //链式设计
        if (null != _callBack)
        {
            eventTable[eventType] = _callBack - callBack;
            OnLinstenerRemoved(eventType);
        }
    }
    public static void BroadCast<T, A, B>(EventType eventType, T arg0, A arg1, B arg2)
    {
        Delegate _delegate;
        if (eventTable.TryGetValue(eventType, out _delegate))
        {
            CallBack<T, A, B> _callBack = _delegate as CallBack<T, A, B>;
            if (null != _callBack)
            {
                _callBack(arg0, arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("【广播】监听报错！事件{0}的委托类型不对应！", eventType));
            }
        }
    }
    //四个参数
    public static void AddListener<T, A, B, C>(EventType eventType, CallBack<T, A, B, C> callBack)
    {
        OnLinstenerAdding(eventType, callBack);
        //这里必须强转
        eventTable[eventType] = (CallBack<T, A, B, C>)eventTable[eventType] + callBack;
    }
    public static void RemoveListener<T, A, B, C>(EventType eventType, CallBack<T, A, B, C> callBack)
    {
        OnLinstenerRemoving(eventType, callBack);
        CallBack<T, A, B, C> _callBack = eventTable[eventType] as CallBack<T, A, B, C>;
        //链式设计
        if (null != _callBack)
        {
            eventTable[eventType] = _callBack - callBack;
            OnLinstenerRemoved(eventType);
        }
    }
    public static void BroadCast<T, A, B, C>(EventType eventType, T arg0, A arg1, B arg2, C arg3)
    {
        Delegate _delegate;
        if (eventTable.TryGetValue(eventType, out _delegate))
        {
            CallBack<T, A, B, C> _callBack = _delegate as CallBack<T, A, B, C>;
            if (null != _callBack)
            {
                _callBack(arg0, arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("【广播】监听报错！事件{0}的委托类型不对应！", eventType));
            }
        }
    }
    //五个参数
    public static void AddListener<T, A, B, C, D>(EventType eventType, CallBack<T, A, B, C, D> callBack)
    {
        OnLinstenerAdding(eventType, callBack);
        //这里必须强转
        eventTable[eventType] = (CallBack<T, A, B, C, D>)eventTable[eventType] + callBack;
    }
    public static void RemoveListener<T, A, B, C, D>(EventType eventType, CallBack<T, A, B, C, D> callBack)
    {
        OnLinstenerRemoving(eventType, callBack);
        CallBack<T, A, B, C, D> _callBack = eventTable[eventType] as CallBack<T, A, B, C, D>;
        //链式设计
        if (null != _callBack)
        {
            eventTable[eventType] = _callBack - callBack;
            OnLinstenerRemoved(eventType);
        }
    }
    public static void BroadCast<T, A, B, C, D>(EventType eventType, T arg0, A arg1, B arg2, C arg3, D arg4)
    {
        Delegate _delegate;
        if (eventTable.TryGetValue(eventType, out _delegate))
        {
            CallBack<T, A, B, C, D> _callBack = _delegate as CallBack<T, A, B, C, D>;
            if (null != _callBack)
            {
                _callBack(arg0, arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("【广播】监听报错！事件{0}的委托类型不对应！", eventType));
            }
        }
    }

}
