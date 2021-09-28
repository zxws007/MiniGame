using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cc : MonoBehaviour
{
    public float speed = 10;
    private Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * speed;
        float mouseY = Input.GetAxis("Mouse Y") * speed;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log(mousePos + "" + mouseY);
    }
}
