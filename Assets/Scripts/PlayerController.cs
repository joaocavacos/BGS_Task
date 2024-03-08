using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float hInput;
    private float vInput;

    public float moveSpeed = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();        
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    private void GetInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMove()
    {
        var movement = new Vector2(hInput, vInput);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;
    }
    
}
