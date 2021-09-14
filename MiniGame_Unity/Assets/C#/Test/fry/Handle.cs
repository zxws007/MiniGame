using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Handle : MonoBehaviour {

    [SerializeField] public int TimesToOver; // 拉手拉完的次数
    [SerializeField] public long DurationOnceTime; // 一次拉手持续的时间(毫秒)
    [SerializeField] public Transform CorrectTransform;// 拉手正确的位置
    [SerializeField] public Sprite[] Sprites; // 精灵图
    private SpriteRenderer SpriteRenderer; // renderer对象
    private int FireTimes = 0; // 点火的次数
    private long LastFireTime; // 上次点火时间

    public void RegisterCallbacks()
    {
    }
	// Use this for initialization
	void Start ()
    {
        RegisterCallbacks();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Sprites[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsOver())
        {
            if (IsHandleOut())
            {
                long nowTime = DateTime.Now.Ticks / 10000;
                // 超时则返回原来位置
                if (nowTime - LastFireTime > DurationOnceTime)
                {
                    HandleBack();
                }
            }
        }
        // 判断是否在外出状态，超时收回来
        else if (IsHandleOut())
        {
                long nowTime = DateTime.Now.Ticks / 10000;
                // 超时则返回原来位置
                if (nowTime - LastFireTime > DurationOnceTime)
                {
                    HandleBack();
                }
        }
	}

    
    // 拉手是否在拉出状态
    private bool IsHandleOut()
    {
        return SpriteRenderer.sprite == Sprites[1];
    }

    // 是否已经点火完成
    private bool IsOver()
    {
        return FireTimes >= TimesToOver;
    }
    private void HandleBack()
    {
        SpriteRenderer.sprite = Sprites[0];
    }

    // 每次点火
    private void HandleOut()
    {
        FireTimes += 1;
        SpriteRenderer.sprite = Sprites[1];
        LastFireTime = DateTime.Now.Ticks / 10000;
        if (!IsOver())
            EventCenter.BroadCast(EventType.FRY_HANDLE_OUT);
        else
            EventCenter.BroadCast(EventType.FRY_HANDLE_OVER_TIMES);
    }

    private void OnMouseDrag()
    {
        if (!IsOver() && !IsHandleOut())
        {
            var dragPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            var correctPos = CorrectTransform.position;
            // 如果到达正确区域，则点火
            if (Mathf.Abs(correctPos.x - dragPosition.x) <= 1f && Mathf.Abs(correctPos.y - dragPosition.y) <= 1f)
            {
                HandleOut();
            }
        }
    }

    // Update is called once per frame
    private void OnMouseUp()
    {
    }
}
