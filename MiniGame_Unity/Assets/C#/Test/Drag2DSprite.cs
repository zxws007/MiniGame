using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag2DSprite : MonoBehaviour
{
     #region VERSION 1
    //[SerializeField] private bool isSelected;//MARKER Default Value is False

    //private void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //        isSelected = true;
    //    if (Input.GetMouseButtonUp(0))
    //        isSelected = false;
    //}

    //private void Update()
    //{
    //    //Debug.Log(Input.mousePosition.x + "-" +  Input.mousePosition.y);//MARKER Watch first

    //    if (isSelected)
    //    {
    //        Vector2 cursorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        transform.position = new Vector2(cursorWorldPos.x, cursorWorldPos.y);
    //    }
    //}
    #endregion

    #region VERSION 2
    [SerializeField] private bool isSelected;

    private void OnMouseDrag()
    {
               Vector2 cursorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               transform.position = new Vector2(cursorWorldPos.x, cursorWorldPos.y);
    }
    #endregion

    private void OnMouseEnter()
    {
        //变形操作 体现交互效果
        //transform.localScale += Vector3.one * 0.1f;
    }

    private void OnMouseExit()
    {
        //变形操作 体现交互效果
        //transform.localScale -= Vector3.one * 0.1f;
    }
}
