using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool IsMoving;
    private Vector2 input;

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        IsMoving = true;
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);     

        IsMoving = false;  
    }

}
