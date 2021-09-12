using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour {

    private WaterHerb WaterHerb;
    private bool IsFinished = false; // 是否已经存放到炉子
    private Vector4 originalPos;

	// Use this for initialization
	void Start () {
        WaterHerb = GameObject.Find("水面药材").GetComponent<WaterHerb>();
        originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDrag()
    {
        if (!IsFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    // Update is called once per frame
    private void OnMouseUp()
    {
        if (!IsFinished)
        {
            // 判断是否在剩余的药品位置区域
            var colliderIdx = 0;
            foreach (var collider in WaterHerb.herbColliders)
            {
                var colliderPos = collider.transform.position;
                if (Mathf.Abs(colliderPos.x - transform.position.x) <= 0.5f &&
                    Mathf.Abs(colliderPos.y - transform.position.y) <= 0.5f)
                {
                    if (WaterHerb.PutHerbInPosition(colliderIdx))
                    {
                        // 变成WaterHerb的子组件
                        transform.parent = WaterHerb.transform;
                        transform.position = collider.transform.position;
                        IsFinished = true;
                        return;
                    }
                    else
                    {
                        MoveBack();
                        return;
                    }
                }
                colliderIdx++;
            }
            MoveBack();
        }
    }

    private void MoveBack()
    {
        transform.position = originalPos;
    }

}
