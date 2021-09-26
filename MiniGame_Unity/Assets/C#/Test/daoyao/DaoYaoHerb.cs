using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaoYaoHerb : MonoBehaviour {
    public Text hint;
    [SerializeField] public Transform correctTrans;
    private Vector3 OriginalPos;
    private bool IsFinished = false;
    private Renderer Renderer;

    public static int inCnt = 0;

	// Use this for initialization
	void Start () {
        OriginalPos = transform.position;
        Renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        if (inCnt != 0)
        {
            Debug.Log("请先完成捣药步骤");
            hint.text = "请依次完成捣药";
        }else if (!IsFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    // Update is called once per frame
    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 2f &&
            Mathf.Abs(transform.position.y - correctTrans.position.y) <= 2f)
        {
            //消失
            IsFinished = true;
            Daoyaomanager.change = Daoyaomanager.change + 1;
            inCnt += 1;
            Hide();
            MoveBack();
        }
        else
        {
            MoveBack();
        }
    }

    public void MoveBack()
    {
        transform.position = OriginalPos;
    }

    public void Hide()
    {
        Renderer.enabled = false;
    }
}
