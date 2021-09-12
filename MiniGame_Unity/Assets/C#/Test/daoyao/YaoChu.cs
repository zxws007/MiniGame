using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaoChu : MonoBehaviour {
    [SerializeField] public int TimesToOver; // 拉手拉完的次数
    [SerializeField] public float distanceToChange; // 变换状态的滑动距离
    [SerializeField] public Sprite[] Sprites; // 精灵图
    private SpriteRenderer SpriteRenderer; // renderer对象
    private Vector3 mouseDownPos; // 鼠标按下的位置，用于判断距离
    private bool IsUp = true;
    private bool IsFinished = false;
    private int DownTimes = 0; // 捣的次数

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
	}

    
    // 按下时记下当前位置
    private void OnMouseDown()
    {
        mouseDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (!IsFinished) {
            // up 状态判断下的距离
            var currMousePos = Input.mousePosition;
            Debug.Log(currMousePos);
            if (IsUp)
            {
                var distance = mouseDownPos.y - currMousePos.y;
                Debug.Log(distance);
                // 大于距离，改变状态
                if (distance > distanceToChange)
                {
                    SetDown();
                }
            }
            else
            {
                var distance = currMousePos.y - mouseDownPos.y;
                Debug.Log(distance);
                // 大于距离，改变状态
                if (distance > distanceToChange)
                {
                    SetUp();
                }
            }
        }
    }

    // Update is called once per frame
    private void OnMouseUp()
    {
    }

    // 设置为up状态
    private void SetUp()
    {
        IsUp = true;
        SpriteRenderer.sprite = Sprites[0];
    }

    // 设置为down状态
    private void SetDown()
    {
        IsUp = false;
        SpriteRenderer.sprite = Sprites[1];
        DownTimes++;
        if (DownTimes == TimesToOver)
        {
            IsFinished = true;
        }
    }
}
