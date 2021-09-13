using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washdrop : MonoBehaviour {

    // Use this for initialization
    private Vector2 startPos;
    [SerializeField] private Transform correctTrans;
    [SerializeField] private bool isFinished;

    public Animator animator1;
    public Animator animator2;

    // Use this for initialization
    private void Start()
    {
        startPos = transform.position;
        
    }

    private void OnMouseDrag()
    {
        if (WashManager.change ==1)
        {
            animator1.speed = 1;
        }
        if (WashManager.change == 2)
        {
            animator2.speed = 1;
        }

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
            isFinished = true;
            WashManager.change = WashManager.change + 1;
            //Debug.Log(FirstManager.change);
        }
        else
        {
            transform.position = new Vector2(startPos.x, startPos.y);
        }
    }
}
