using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour {

    [SerializeField] public BoxCollider2D[] trailColliders; // 滑动的轨迹碰撞区域
    private Stack<int> colliderTrailIdxs;
    private Vector3 originalPos; // 原始位置
    private bool IsCanMove = false; // 是否可移动
    private bool IsMoving = false; // 是否正在移动
    private Collider2D CollisionDomain; // 与轨迹点的碰撞区域

    private int num = 0;
    public GameObject show1;
    public GameObject show2;

    private void RegisterCallbacks()
    {
        EventCenter.AddListener(EventType.FRY_HANDLE_OVER_TIMES, SetCanMove);
    }
	// Use this for initialization
	void Start () {
        RegisterCallbacks();
        originalPos = transform.position;
        CollisionDomain = GetComponents<BoxCollider2D>()[1];

        colliderTrailIdxs = new Stack<int>(trailColliders.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCanMove()
    {
        IsCanMove = true;
    }

    public void MoveToOriginalPos()
    {
        transform.position = originalPos;
    }

    private void OnMouseDrag()
    {
        if (IsCanMove)
        {
            IsMoving = true;
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            // 判断碰撞
        }
    }
    private void OnMouseUp()
    {
        if (IsCanMove)
        {
            transform.position = originalPos;
        }
        colliderTrailIdxs.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        var idx = 0;
        foreach (var collider in trailColliders)
        {
            if (collider == collidedObject)
            {
                if (colliderTrailIdxs.Count == idx)
                {
                    colliderTrailIdxs.Push(idx);
                }
                // 可重入
                else if (colliderTrailIdxs.Count - 1 == idx)
                {
                    return;
                }
                // 如果idx小于当前Count，从idx开始
                else if (idx < colliderTrailIdxs.Count - 1)
                {
                    while (colliderTrailIdxs.Pop() != idx);
                } else
                {
                    colliderTrailIdxs.Clear();
                    Debug.Log("轨迹错误，需要重新绘制");
                }
            }
            idx++;
        }
        if (colliderTrailIdxs.Count == trailColliders.Length)
        {
            Debug.Log("轨迹正确");
            EventCenter.BroadCast(EventType.FRY_SHOVEL_DRAG_CORRECT);
            num = num + 1;
            if (num == 3)
            {
                show1.SetActive(true);
                show2.SetActive(true);
            }
        }
    }

    private void OnTrigerExit2D(Collider2D collidedObject)
    {
    }
}
