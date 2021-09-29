using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaoHerb : MonoBehaviour
{
    public GameObject herbArrow;
    public GameObject chaoArrow;
    public GameObject xuanArrow;
    public GameObject bar;
    public GameObject pointer;
    public Transform correctTrans;
    

    public Text herbText;
    public Text chaoText;

    // Use this for initialization
    void Start()
    {
        herbArrow.SetActive(true);
        herbText.enabled = true;

        chaoArrow.SetActive(false);
        xuanArrow.SetActive(false);
        chaoText.enabled = false;
        bar.GetComponent<SpriteRenderer>().enabled = false;
        pointer.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDrag()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 4f &&
            Mathf.Abs(transform.position.y - correctTrans.position.y) <= 4f)
        {
            transform.position = correctTrans.position;

            herbArrow.SetActive(false);
            herbText.enabled = false;

            chaoArrow.SetActive(true);
            xuanArrow.SetActive(true);
            chaoText.enabled = true;
            bar.GetComponent<SpriteRenderer>().enabled = true;
            pointer.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
