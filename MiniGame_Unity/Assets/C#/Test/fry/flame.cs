using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {

    private Renderer Renderer;
    [SerializeField] public long MillisecToShowOnceTime; // 每次显示持续的时间(毫秒）
    private long FireTime; // 点火的时间
    private bool IsOneShot; // 是否点亮一次

    // 注册事件
    private void RegisterCallbacks()
    {
        EventCenter.AddListener(EventType.FRY_HANDLE_OUT, OnHandleOut);
        EventCenter.AddListener(EventType.FRY_HANDLE_OVER_TIMES, OnHandleOverTimes);
    }

	// Use this for initialization
	void Start ()
    {
        RegisterCallbacks();
        Renderer = GetComponent<Renderer>();
        OutFire();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Renderer.enabled == true)
        {
            if (IsOneShot)
            {
                long nowTime = DateTime.Now.Ticks / 10000;
                if (nowTime - FireTime > MillisecToShowOnceTime)
                {
                    OutFire();
                }
            }
        }
	}

    // 拉手拉出一次的事件，触发FireForAWhile()
    public void OnHandleOut()
    {
        FireForAWhile();
    }

    // 拉手拉完后的事件，触发FireForever()
    public void OnHandleOverTimes()
    {
        FireForever();
    }

    // 点亮一次
    public void FireForAWhile()
    {
        Renderer.enabled = true;
        FireTime = DateTime.Now.Ticks / 10000;
        IsOneShot = true;
    }

    // 持续点亮
    public void FireForever()
    {
        Renderer.enabled = true;
        IsOneShot = false;
    }

    // 灭火
    public void OutFire()
    {
        Renderer.enabled = false;
    }
}
