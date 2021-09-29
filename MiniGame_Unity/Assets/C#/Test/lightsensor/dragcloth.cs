using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragcloth : MonoBehaviour
{
    public GameObject ArrowCloth;
    public GameObject PutCloth;
    public GameObject ArrowBottle;
    private Vector3 startPoint;
    public GameObject popcloth;
    // Use this for initialization
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDrag()
    {
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getHerbready() && !GameObject.Find("GameManager").GetComponent<RunManager>().getClothready())
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (cursorPos.x > GameObject.Find("ClothEnd").transform.position.x && cursorPos.y < GameObject.Find("ClothUpperBound").transform.position.y && cursorPos.y > GameObject.Find("ClothLowerBound").transform.position.y)
            {
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
        }
    }
    private void OnMouseEnter()
    {
        if (!GameObject.Find("GameManager").GetComponent<RunManager>().getClothready())
        {
            transform.localScale += Vector3.one * 0.07f;
        }
    }
    private void OnMouseExit()
    {
        if (!GameObject.Find("GameManager").GetComponent<RunManager>().getClothready())
        {
            transform.localScale -= Vector3.one * 0.07f;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "panzi")
        {
            // Debug.Log("OnCollisionEnter2D");
            ArrowCloth.SetActive(false);
            PutCloth.SetActive(false);
            popcloth.SetActive(false);
        }
    }
    void OnMouseUp()
    {
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getClothready() == false)
        {
            if (transform.position.x < 7 && transform.position.y >= -1.5 && transform.position.y <= 1.5)
            {
                GameObject.Find("GameManager").GetComponent<RunManager>().setClothready(true);
                ArrowBottle.SetActive(true);
            }
            else
            {
                transform.position = startPoint;
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "panzi")
        {
            //Debug.Log("OnCollisionEnter2D");
            ArrowCloth.SetActive(true);
            PutCloth.SetActive(true);
            popcloth.SetActive(true);
            GameObject.Find("GameManager").GetComponent<RunManager>().setClothready(false);
            ArrowBottle.SetActive(false);
        }
    }
    public void OnClick()
    {
        Debug.Log("1111");
    }
}
