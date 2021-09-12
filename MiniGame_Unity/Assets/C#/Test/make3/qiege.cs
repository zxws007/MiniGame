using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qiege : MonoBehaviour {

    // Use this for initialization
    private Vector2 startPos;
    [SerializeField] private Transform correctTrans;
    [SerializeField] private bool isFinished;


    // Use this for initialization
    private void Start()
    {
        startPos = transform.position;

    }

    private void OnMouseDrag()
    {

        if (!isFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    // Update is called once per frame
    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f)
        {
            transform.position = new Vector2(correctTrans.position.x, correctTrans.position.y);
            Make3Manager.change = Make3Manager.change + 1;
            Debug.Log(Make3Manager.change);
        }
        else
        {
            transform.position = new Vector2(startPos.x, startPos.y);
        }
    }
}
