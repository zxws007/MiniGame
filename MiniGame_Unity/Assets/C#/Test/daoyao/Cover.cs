using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cover : MonoBehaviour {
    [SerializeField] public Transform correctTrans;
    public GameObject whole;
    public GameObject pointer;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject bar;
    public GameObject bottom;
    public Text hint;

    private Vector3 OriginalPos;
    private bool IsFinished = false;
    private Renderer Renderer;

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
        if (DaoYaoHerb.inCnt==0)
        {
            hint.text = "请放入药材";
        }
        else if (!IsFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        }

    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 2f &&
            Mathf.Abs(transform.position.y - correctTrans.position.y) <= 2f)
        {
            //消失
            IsFinished = true;
            Hide();
            MoveBack();
            whole.GetComponent<Renderer>().enabled = true;
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
        
        whole.GetComponent<Renderer>().enabled = true;
        bar.SetActive(true);
        pointer.SetActive(true);

        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
        bottom.SetActive(false);
        Renderer.enabled = false;
    }

}
