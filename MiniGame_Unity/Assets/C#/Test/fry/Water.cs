using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private SpriteRenderer SpriteRenderer;
    [SerializeField] public Sprite[] Sprites; // 精灵图

    public void RegisterCallbacks()
    {
        EventCenter.AddListener(EventType.FRY_HANDLE_OVER_TIMES, SetBoiling);
    }
	// Use this for initialization
	void Start () {
        RegisterCallbacks();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SetCalm();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // 设置为沸腾
    public void SetBoiling()
    {
        SpriteRenderer.sprite = Sprites[1];
    }

    // 设置为未沸腾
    public void SetCalm()
    {
        SpriteRenderer.sprite = Sprites[0];
    }
}
