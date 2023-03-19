using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    //[SerializeField] float minVelocity = 0.01f;
    
    private Rigidbody2D rb;
    //private Vector3 lastMousePos;
    //private Vector3 mouseVelocity;

    //private Collider2D col;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //col = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        //col.enabled = isMouseMoving();
        
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10; // distance of 10 units from the camera
        
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    /*private bool isMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float moved = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        if (moved > minVelocity)
            return true;
        else
            return false;
    }*/
}
