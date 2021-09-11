using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

    [SerializeField] public bool IsPlaying; // 是否正在播放
    [SerializeField] public int FPS; // Flames Per Second 每秒播放频率
    [SerializeField] public List<Sprite> Frames; // 所有帧的图片
    [SerializeField] public int CurrFrameIdx = 0; // 当前播放的帧idx
    [SerializeField] public bool IsReapted = false; // 是否循环播放

    private SpriteRenderer spriteRenderer; // 当前精灵renderer对象
    private long startTime; // 游戏开始时间(毫秒)，用于计算当前的帧数

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetCurrFrame(CurrFrameIdx);
        UpdateStartTime();
	}

    // 更新动画开始播放的时间
    void UpdateStartTime()
    {
        startTime = DateTime.Now.Ticks;
    }
	
	// Update is called once per frame
	void Update () {
        // 如果正在播放，根据FPS更新精灵图片
        if (IsPlaying)
        {
            long deltaTime = (DateTime.Now.Ticks - startTime)/10000;
            // 计算当前的帧index
            int currFrameIdx = (int)(((long)((deltaTime / ((1.0f / FPS)*1000))))%Frames.Count);
            Debug.Log(currFrameIdx);
            if (currFrameIdx != CurrFrameIdx) {
                SetCurrFrame(currFrameIdx);
            }
            // 如果不重复，则在最后一帧停止
            if (currFrameIdx == Frames.Count - 1 && !IsReapted)
            {
                IsPlaying = false;
            }
        }
	}

    // 播放动画
    void Play()
    {
        // 如果是重复播放类型的，则从第一帧开始重新播放；否则，从上次停止的帧开始播放
        if (IsPlaying == false)
        {
            IsPlaying = true;
            if (IsReapted)
                SetCurrFrame(0);
            UpdateStartTime();
        }
    }

    // 停止动画
    void Stop()
    {
        IsPlaying = false;
    }

    // 设置当前的显示帧
    void SetCurrFrame(int idx)
    {
        spriteRenderer.sprite = Frames[idx];
        CurrFrameIdx = idx;
    }
}
