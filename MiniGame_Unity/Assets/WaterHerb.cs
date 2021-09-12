using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHerb : MonoBehaviour {


    public List<Collider2D> herbColliders = new List<Collider2D>(); // 药材的collider,世界坐标
    [SerializeField] public long DurationTime; // 动画持续时间(毫秒数)
    [SerializeField] public int RotateTimes; // 一次旋转次数
    private long RotateStartTime; // 旋转开始时间(毫秒)
    private bool IsRotating = false; // 是否在旋转

    void RegisterCallbacks()
    {
        EventCenter.AddListener(EventType.FRY_SHOVEL_DRAG_CORRECT, Rotate);
    }

	// Use this for initialization
	void Start () {
        RegisterCallbacks();
        InitAllHerbPositions();
	}

    // 初始化所有药材能存放的位置
    void InitAllHerbPositions()
    {
        var objects = GameObject.FindGameObjectsWithTag("HerbPosition");
        foreach (var obj in objects) {
            herbColliders.Add(obj.GetComponent<Collider2D>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (IsRotating)
        {
            // 超过时间强制复原
            if (DateTime.Now.Ticks/10000 - RotateStartTime > DurationTime)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                IsRotating = false;
            }
            // 否则旋转
            float rotateAngle = (Time.deltaTime*1000 / DurationTime)*360*RotateTimes;
            Debug.Log(rotateAngle);
            Debug.Log(transform.rotation);
            transform.Rotate(0, 0, rotateAngle);
        }
	}

    // 添加药材到位置
    public bool PutHerbInPosition(int idx)
    {
        if (!IsRotating && herbColliders.Count > idx)
        {
            herbColliders.RemoveAt(idx);
            return true;
        }
        return false;
    }

    // 旋转
    public void Rotate()
    {
        if (!IsRotating)
        {
            RotateStartTime = DateTime.Now.Ticks / 10000;
            IsRotating = true;
        }
    }
}
