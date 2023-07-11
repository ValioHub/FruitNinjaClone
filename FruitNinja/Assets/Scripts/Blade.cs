using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;
    
    private Rigidbody2D rb;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
    }
    private void FixedUpdate()
    {
        col.enabled = isMouseMoving();
    }
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        // Distance from the camera
        mousePos.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private bool isMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        if (traveled > minVelo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
